using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Plane
    {
        double[] dimensions = new double[2];

        public double width
        {
            get { return dimensions[0]; }
            set { dimensions[0] = value;}
        }
        public double height
        {
            get { return dimensions[1]; }
            set { dimensions[1] = value; }
        }

        public Plane(double width, double height)
        {
            dimensions[0]=width;
            dimensions[1]=height;
        }

        public bool checkIfPointOnPlane(double x, double y)
        {
            if (x >= 0 && x <= dimensions[0] && y >= 0 && y <= dimensions[1]) return true;
            return false;
        }
    }
}
