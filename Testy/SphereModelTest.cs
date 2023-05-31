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
    public class SphereModelTest
    {
        [TestClass]
        public class SphereModelTests
        {
            [TestMethod]
            public void TestProperty()
            {
                // Arrange
                var mockSphere = new Mock<Sphere>(1,2,3);
                mockSphere.SetupAllProperties();
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
        }
    }
}
