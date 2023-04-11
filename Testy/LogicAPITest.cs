using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    [TestClass]
    public class LogicAPITests
    {
        [TestMethod]
        public void TestCreatePlane()
        {
            AbstractLogicAPI api = AbstractLogicAPI.CreateAPI();
            api.createPlane(100, 100, 5);
            List<SphereLogic> sphereLogics = api.GetSphereLogics();
            Assert.AreEqual(5, sphereLogics.Count);
            // Test that all spheres are within the plane
            foreach (SphereLogic sphereLogic in sphereLogics)
            {
                Assert.IsTrue(sphereLogic.X >= sphereLogic.Radius && sphereLogic.X <= 100 - sphereLogic.Radius);
                Assert.IsTrue(sphereLogic.Y >= sphereLogic.Radius && sphereLogic.Y <= 100 - sphereLogic.Radius);
            }
        }
    }
}
