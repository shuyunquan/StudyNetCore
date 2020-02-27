using System;

namespace StudyCShap
{
    class Program
    {
        static void Main(string[] args)
        {

            var s = ("许嵩","阿萨","方式");
            Console.WriteLine(s.Item1);

            Console.WriteLine("我改了名字");
            Console.Read();
        }
    }
}
