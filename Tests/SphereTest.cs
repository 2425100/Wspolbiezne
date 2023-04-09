using Logika;
namespace Tests;

[TestClass]
public class SphereTest
{
    [TestMethod]
    public void constructorTest()
    {
        Sphere sphere = new Sphere(1, 2, 3);
        Assert.IsTrue(sphere.GetType()!=null);
    }
}