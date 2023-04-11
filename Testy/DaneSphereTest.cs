using Dane;
namespace Testy
{
    [TestClass]
    public class DaneSphereTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Sphere sphere = new Sphere(1, 2, 3, 4);
            Assert.IsNotNull(sphere);
            Assert.AreEqual(sphere.Radius, 3);
            Assert.AreEqual(sphere.X, 1);
            Assert.AreEqual(sphere.Y, 2);
            Assert.AreEqual(sphere.Mass, 4);
        }
    }
}