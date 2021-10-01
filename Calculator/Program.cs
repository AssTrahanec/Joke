using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "1+1+1";
            //var str = "(1+(1+1)*(2+2)*9)+7";
            //var str = "(1+(1+1)*2)*2";
            var str = "1+2*4*9+7";
            //var str = "(-5)*2";
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