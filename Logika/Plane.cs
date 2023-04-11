using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Plane
    {
        private int width;
        private int height;
        private bool visibility = true;
        private List<Sphere> sphereList = new List<Sphere>();

        public Plane(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public bool Visibility { get => visibility; set => visibility = value; }
        public List<Sphere> getSphereList { get => sphereList; }

        public void spawnSpheres(int numberOfSpheres)
        {
            Random random = new Random();
            int radius = 50;
            int x, y;
            for(int i = 0; i < numberOfSpheres; i++)
            {
                do
                {
                    x = random.Next(radius, this.width - radius);
                    y = random.Next(radius, this.height - radius);
                }
                while (!checkIfPointOnPlane(x, y));
                sphereList.Add(new Sphere(x,y,radius));
            }
        }

        public bool checkIfPointOnPlane(double x, double y)
        {
            if (x >= 0 && x <= width && y >= 0 && y <= height) return true;
            return false;
        }

    }
}
