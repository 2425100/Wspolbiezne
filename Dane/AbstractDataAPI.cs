using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class AbstractDataAPI
    {
        public abstract void createPlane (int width, int height, int numberOfSpheres);
        public abstract Plane getPlane();
        public abstract List<Sphere> GetSpheres();
        public static AbstractDataAPI createAPI()
        {
            return new DataAPI();
        }
    }
    internal class DataAPI : AbstractDataAPI
    {
        private Plane plane;
        public override void createPlane(int width, int height, int numberOfSpheres)
        {
            this.plane = new Plane(width, height);
            this.plane.spawnSpheres(numberOfSpheres);
        }
        public override Plane getPlane() {  return this.plane; }
        public override List<Sphere> GetSpheres() { return this.plane.getSphereList; }
    }
}
