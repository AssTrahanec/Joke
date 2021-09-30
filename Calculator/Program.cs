using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "1+1+1";
            var calculator = new Calculation(str);
            try
            {
                Console.WriteLine(calculator.Calculate());
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero");
            }

            
        }
    }
}
