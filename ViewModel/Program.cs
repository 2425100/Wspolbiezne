using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace ViewModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            Greeter greeter = new Greeter();
            System.Console.WriteLine(greeter.getText());
            System.Console.ReadKey();

        }
    }
}
