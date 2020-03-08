using System;
using System.Runtime.InteropServices;

namespace StudyCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = ("许嵩", "阿萨", "方式");
            Console.WriteLine(s.Item1);

            int salary = 5000;
            jiangJin(ref salary);
            Console.WriteLine(salary);

            int a = 1;
            int b;
            int asd = Calcu(a,out b);
            Console.WriteLine(asd + " : " + b);

            Console.Read();
        }

        static void jiangJin(ref int salary)
        {
            salary += 500;
        }

        static int Calcu(int a, out int b)
        {
            b = a;
            return a + b;
        }

    }
}
