using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Timers;

namespace Logika
{
    internal class Logger
    {
        /* private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };*/
        private static List<SphereLogic> spheres;
        //private readonly Stopwatch watch = new Stopwatch();
        private System.Timers.Timer timer;
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

       /* public void startLogger(int interval)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            //Console.WriteLine("Tak Logger sie wykonuje..");
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


            //Console.WriteLine(currentDirectory);
            
        



            Task loggSpheres = new Task(async () =>
            {
                while (enable)
                {
                    

                    *//*await createStream.DisposeAsync();*//*
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
*/

        public void startLogger(int interval)
        {
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

            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            //timer.Elapsed += async (sender, e) => await DisplayTimeEvent();
          /*  timer.Elapsed += new ElapsedEventHandler(() => {Task task= new Task(DisplayTimeEvent);
                task.Start();
            });*/
            timer.Interval = 1000; // 1000 ms is one second
            timer.Start();
        }

       

        public  void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            
            // code here will run every second
            foreach (SphereLogic sphereLogic in spheres)
            {
                 JsonSerializer.SerializeAsync(stream, sphereLogic);
                Console.WriteLine("Tak Logger sie wykonuje..");
            }
        }

        public void Stop()
        {
            enable = false;
            stream.Dispose();
            timer.Stop();

        }
    }
}
