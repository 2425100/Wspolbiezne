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
            startLogger(1000);
        }
        public Logger() { }

        public void startLogger(int interval)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Tak Logger sie wykonuje..");
            enable = true;

            string directoryPath = "Logs";
            try
            {
                // Create the directory
                if (Directory.Exists(directoryPath))
                {
                    string fileName = ".\\Logs\\log.json";
                    stream = File.Create(fileName);
                }
                else
                {
                    Directory.CreateDirectory(directoryPath);
                    string fileName = ".\\Logs\\log.json";
                    stream = File.Create(fileName);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            Console.WriteLine(currentDirectory);
            
        



            Task loggSpheres = new Task(async () =>
            {
                while (enable)
                {
                    

                    /*await createStream.DisposeAsync();*/
                    watch.Start();
                    if (watch.ElapsedMilliseconds > interval)
                    {
                        watch.Restart();
                        foreach (SphereLogic sphereLogic in spheres)
                        {
                            await JsonSerializer.SerializeAsync(stream, sphereLogic);
                            //Console.WriteLine("Tak Logger sie wykonuje..");
                        }

                    }

                }
            }
                        );
            loggSpheres.Start();

        }
        public void Stop()
        {
            enable = false;
            stream.Dispose();

        }
    }
}
