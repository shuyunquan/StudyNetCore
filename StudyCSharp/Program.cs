using DomainModels;
using System;
using System.Runtime.InteropServices;

namespace StudyCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ref out
            //var s = ("许嵩", "阿萨", "方式");
            //Console.WriteLine(s.Item1);

            //int salary = 5000;
            //jiangJin(ref salary);
            //Console.WriteLine(salary);

            //int a = 1;
            //int b;
            //int asd = Calcu(a,out b);
            //Console.WriteLine(asd + " : " + b);
            #endregion

            #region 泛型
            //StudyT<string> studyT = new StudyT<string>();
            //studyT.Add("许嵩");
            #endregion

            #region 委托
            //Calcu(6, 4, MyCalcu);
            //jjjjj("大蛋",MyCalcu);
            //vae("许嵩",vaeasd);

            StudyDelegate<int> studyDelegate = new StudyDelegate<int>();
            studyDelegate.Sword(,);

            #endregion

            Console.Read();
        }

        public static int SwordAdd(int x)
        {
            return x + y;
        }

        public static int SwordSquare(int x)
        {
            return x + y;
        }


        public static int MyCalcu(int x, int y)
        {
            return x + y;
        }
           

        public static void Calcu(int x, int y, Func<int,int,int> calculate)
        {
            int result = calculate(x, y);

            Console.WriteLine("委托调用的结果:" + result.ToString());
        }


        public static string MyCalcu(string name)
        {
            return name + "太牛逼了";
        }

        public delegate string MyDelegate(string name);

        public static void jjjjj(string name,MyDelegate myDelegate)
        {
           string asd = myDelegate(name);
            Console.WriteLine(asd);
        }



        public static void vaeasd(string name)
        {
            Console.WriteLine(name + "太牛逼了,没有返回值的牛逼!");
        }

        public delegate void VaeDelegate(string name);

        public static void vae(string name, VaeDelegate myDelegate)
        {
            myDelegate(name);
        }


        public static void asd(string name)
        {
            Console.WriteLine("你好啊:"+ name);
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
