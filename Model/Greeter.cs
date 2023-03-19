using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Greeter
    {
        string text;
        public Greeter() {
            this.text = "Hello, World";
        }
        public void setText(string text)
        {
            this.text=text;
        }
        public string getText()
        {
            return this.text;
        }
        static void Main()
        {

        }
    }
}
