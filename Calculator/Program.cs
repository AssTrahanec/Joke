using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "12.3+22-33+44";
            var calculator = new Calculation(str);
            Console.WriteLine(calculator.Calculate());
        }
    }
}
