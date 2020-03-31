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

            Calcu(6, 4, MyCalcu);

            //MyDelegate myDelegate = asd("许嵩");
            //jjjjj(myDelegate);
            #endregion

            Console.Read();
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


        //public Func<string,string> string MyDelegate(string name);
        //public static void jjjjj(MyDelegate myDelegate)
        //{
        //    myDelegate();
        //}

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
