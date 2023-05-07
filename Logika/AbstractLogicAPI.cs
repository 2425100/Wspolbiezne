using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class AbstractLogicAPI
    {
        public static AbstractLogicAPI CreateAPI()
        {
            return new LogicAPI(AbstractDataAPI.CreateAPI());
        }
        public abstract void createPlane(int width, int height, int numberOfSpheres);
        public abstract List<SphereLogic> GetSphereLogics();
        public abstract void Stop();
        internal class LogicAPI : AbstractLogicAPI
        {
            private AbstractDataAPI dataAPI;
            private List<SphereLogic> SphereLogics = new List<SphereLogic>();
            bool enabled = false;
            public LogicAPI(AbstractDataAPI abstractDataAPI = null)
            {
                this.dataAPI = AbstractDataAPI.CreateAPI();
            }
            public List<SphereLogic> sphereLogics
            {
                get { return SphereLogics; }
                set { SphereLogics = value; }   
            }

            public bool Enabled { get => enabled; set => enabled = value; }
            public override void createPlane(int width, int height, int numberOfSpheres)
            {
                sphereLogics.Clear();
                dataAPI.CreatePlane(width, height, numberOfSpheres);
                foreach (Dane.Sphere sphere in dataAPI.GetSpheres())
                {
                    this.SphereLogics.Add(new SphereLogic(sphere));
                }
                this.enabled = true;
                foreach (SphereLogic sphereLogic in this.SphereLogics)
                {
                    sphereLogic.randomizeSpeed();
                    Task task = new Task(() =>
                    {
                        //int i = 0;
                        int counter = 10;
                        while (enabled)
                        {
                            //Console.Write(i++);
                            if (counter <= 0)
                            {
                                checkCollisionsWithSpheres(sphereLogic, counter);
                            }
                            
                            //Console.WriteLine(counter);
                            if (sphereLogic.X + sphereLogic.Xspeed >= (width - sphereLogic.Radius))
                            {
                                sphereLogic.Xspeed *= -1;
                            }

                            if (sphereLogic.Y + sphereLogic.Y >= (height - sphereLogic.Radius)*2)

                            {
                                sphereLogic.Yspeed *= -1;
                            }
                            if (sphereLogic.X + sphereLogic.Xspeed <= 0)
                            {
                                sphereLogic.Xspeed *= -1;
                            }
                            if (sphereLogic.Y + sphereLogic.Yspeed <= 0)
                            {
                                sphereLogic.Yspeed *= -1;
                            }
                            sphereLogic.X += sphereLogic.Xspeed;
                            sphereLogic.Y += sphereLogic.Yspeed;
                            counter--;
                            Thread.Sleep(10);
                        }
                    });
                    task.Start();
                }
            }

            void checkCollisionsWithSpheres(SphereLogic sphere,int counter)
            {
                //if (counter != 0) { return counter-1; }
                foreach (SphereLogic secondSphere in this.SphereLogics)
                {
                    if (sphere.Equals(secondSphere))
                    {
                        continue;
                    }
                    
                    lock (secondSphere)
                    {
                        if (CalculateDistance(sphere, secondSphere) <  (sphere.Radius/2 + secondSphere.Radius/2))
                        {
                            //tu sprawdzamy czy kulki już sie nie odbiły
                            int relativeX = secondSphere.Xspeed-sphere.Xspeed;
                            int relativeY= secondSphere.Yspeed - sphere.Yspeed;
                            int relativeProduct = (secondSphere.X - sphere.X) * relativeX + (secondSphere.Y - sphere.Y) * relativeY;
                            if (relativeProduct > 0)
                            {
                                continue;
                            }
                            //wyliczamy nowy kierunek i wartość prędkości
                            int firstSpeedX = sphere.Xspeed;
                            int firstSpeedY = sphere.Yspeed;
                            int secondSpeedX = secondSphere.Xspeed;
                            int secondSpeedY = secondSphere.Yspeed;

                            sphere.Xspeed = ((sphere.Weight - secondSphere.Weight) / (sphere.Weight + secondSphere.Weight))* firstSpeedX
                                + (2 * secondSphere.Weight) / (sphere.Weight + secondSphere.Weight) * secondSpeedX;
                            sphere.Yspeed = ((sphere.Weight - secondSphere.Weight) / (sphere.Weight + secondSphere.Weight)) * firstSpeedY
                                + (2 * secondSphere.Weight) / (sphere.Weight + secondSphere.Weight) * secondSpeedY;
                            secondSphere.Xspeed = ((2 * secondSphere.Weight) / (sphere.Weight + secondSphere.Weight)) * firstSpeedX
                                + ((sphere.Weight - secondSphere.Weight) / (sphere.Weight + secondSphere.Weight)) * secondSpeedX;
                            secondSphere.Yspeed = ((2 * secondSphere.Weight) / (sphere.Weight + secondSphere.Weight)) * firstSpeedY
                                + ((sphere.Weight - secondSphere.Weight) / (sphere.Weight + secondSphere.Weight)) * secondSpeedY;

                           
                        }
                    }
                }
                //return 1;
            }

            private double CalculateDistance(SphereLogic first,SphereLogic second)
            {
                return Math.Sqrt(Math.Pow(first.X - second.X,2)+ Math.Pow(first.Y - second.Y, 2));
            }

            public override void Stop()
            {
                this.enabled = false;
            }
            public override List<SphereLogic> GetSphereLogics()
            {
                return this.SphereLogics;
            }
        }
        
    }
}
