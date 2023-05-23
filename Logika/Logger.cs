using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace Logika
{
    internal class Logger
    {
        /* private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };*/
        private static List<SphereLogic> spheres;
        private readonly Stopwatch watch = new Stopwatch();
        private bool enable = false;
        FileStream stream;


        public List<SphereLogic> Spheres
        {
            get { return spheres; }
            set { spheres = value; }
        }
        public bool Enable
        {
            get => enable;
        }
        public Logger(List<SphereLogic> spheres)
        {
            Spheres = spheres;
            startLogger();
        }
        public Logger() { }

        public void startLogger()
        {
            enable = true;
            Task loggSpheres = new Task(async () =>
            {
                while (enable)
                {
                    string fileName = "log.json";
                    stream = File.Create(fileName);

                    /*await createStream.DisposeAsync();*/
                    watch.Start();
                    if (watch.ElapsedMilliseconds > 1000)
                    {
                        watch.Restart();
                        foreach (SphereLogic sphereLogic in spheres)
                        {
                            await JsonSerializer.SerializeAsync(stream, sphereLogic);
                        }

                    }

                }
            }
                        );
        }
        public void Stop()
        {
            enable = false;
            stream.Dispose();

        }
    }
}
