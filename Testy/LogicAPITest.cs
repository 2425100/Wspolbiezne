using Dane;
using Logika;
using Model;
using Moq;
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
        [TestMethod]
        public void TestProperty()
        {
            // Arrange
            var mockSphere = new Mock<Sphere>(1,2,3);
            mockSphere.SetupAllProperties();
            mockSphere.Object.X = 1;
            mockSphere.Object.Y = 2;
            mockSphere.Object.Radius = 3;
            SphereLogic sphereLogic = new SphereLogic(mockSphere.Object);
            var model = new SphereModel(sphereLogic);
            string propertyName = null;
            model.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

            // Act
            model.X = 5;

            // Assert
            Assert.AreEqual(1, mockSphere.Object.X);
            Assert.AreEqual("X", propertyName);
        }

       

        [TestMethod()]
        public void GetSphereLogicsTest()
        {
            // Arrange
            var sphereLogics = new List<SphereLogic>();
            //Dependency Injection!!
            var dataAPI = new Mock<AbstractDataAPI>();
            dataAPI.Setup(x => x.GetSpheres()).Returns(new List<Dane.Sphere>());
            var logicAPI = new LogicAPI(dataAPI.Object);
            logicAPI.sphereLogics = sphereLogics;

            // Act
            var result = logicAPI.GetSphereLogics();

            // Assert
            Assert.AreSame(sphereLogics, result);
        }

        [TestMethod()]
        public void StopTest()
        {
            // Arrange
            var dataAPI = new Mock<AbstractDataAPI>();
            var logicAPI = new LogicAPI(dataAPI.Object);

            // Act
            logicAPI.Stop();

            // Assert
            Assert.IsFalse(logicAPI.Enabled);
        }
    }
}
