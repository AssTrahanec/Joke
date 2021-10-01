using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var str1 = "(1+(1+1)*(2+2)*9)+7";
            var str2 = "(1+(1+1)*2)*2";
            var str3 = "1+2*4*9+7";
            var str4 = "(-5)*2";
            Console.WriteLine("{0}={1}",str1,new Calculation(str1).Calculate());
            Console.WriteLine("{0}={1}",str2,new Calculation(str2).Calculate());
            Console.WriteLine("{0}={1}",str3,new Calculation(str3).Calculate());
            Console.WriteLine("{0}={1}",str4,new Calculation(str4).Calculate());
        }
    }
}