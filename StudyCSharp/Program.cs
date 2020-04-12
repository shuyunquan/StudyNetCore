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
            //jjjjj("海伦凯勒","大蛋", MyCalcu);
            ////Lambda表达式
            //jjjjj("海伦凯勒", "大蛋", (FirstName, LastName) => { return FirstName + LastName + "哈哈"; });
            //vae("许嵩", vaeasd);

            //下面这一段是发布订阅模式,是观察者模式
            //Thermostat thermostat = new Thermostat();
            //Heater heater = new Heater(60);
            //Cooler cooler = new Cooler(80);
            //thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
            //thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;
            //Console.WriteLine("请输入当前温度:");
            //string currentTemperature = Console.ReadLine();
            //thermostat.CurrentTemperature = int.Parse(currentTemperature);

            #endregion

            #region 线程


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

        public static string MyCalcu(string FirstName, string LastName)
        {
            return FirstName + LastName + "太牛逼了";
        }

        public delegate string MyDelegate(string FirstName, string LastName);

        public static void jjjjj(string FirstName, string LastName, MyDelegate myDelegate)
        {
           string asd = myDelegate(FirstName, LastName);
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
