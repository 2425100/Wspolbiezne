using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGreeterConstructor()
        {
            Greeter greeter= new Greeter();
            Assert.AreEqual(greeter.getText(), "Hello, World");
            
        }
        [TestMethod]
        public void TestGreeterSetter() {
            Greeter greeter = new Greeter();
            greeter.setText("hello");
            Assert.AreNotEqual(greeter.getText(), "Hello, World");
            greeter.setText("test");
            Assert.AreEqual(greeter.getText(), "test");


        }
    }
}