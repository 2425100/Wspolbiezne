using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    [TestClass]
    public class AbstractDataAPITests
    {
        [TestMethod]
        public void TestCreatePlane()
        {
            // arrange
            AbstractDataAPI dataAPI = AbstractDataAPI.CreateAPI();
            int width = 500;
            int height = 500;
            int numberOfSpheres = 10;

            // act
            dataAPI.CreatePlane(width, height, numberOfSpheres);
            Plane plane = dataAPI.GetPlane();
            List<Sphere> spheres = dataAPI.GetSpheres();

            // assert
            Assert.AreEqual(width, plane.Width);
            Assert.AreEqual(height, plane.Height);
            Assert.AreEqual(numberOfSpheres, spheres.Count);
        }
    }
}
