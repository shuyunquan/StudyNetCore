using DomainModels;
using StudyCSharp.DelegateDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace StudyCSharp
{

    static class X
    {
        public static string Name { get; set; }
        public static string PassWord { get; set; }

        public static void Test() 
        {
            Console.WriteLine("测试");
        }

    }

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

            //文豪讲的发布订阅模式,很棒
            //Server server = new Server();
            //Client client = new Client("文豪",true);
            //Client client1 = new Client("大蛋");
            //Client client2 = new Client("权权");
            //server.PublishInfo("好消息,许嵩发新歌啦");

            #endregion

            #region Linq
            IEnumerable<string> list = new List<string>(){
                "许嵩", "刘备", "诸葛亮"
            };

            var result = list.Where( a => a.Contains("刘备") );


            #endregion

            #region 线程

            Thread thread = new Thread(DoWork);
            thread.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write('-');
            }
            thread.Join();
            #endregion

            #region 反射

            ////反射第一种:GetType()  有实例对象,可以调用获取属性,方法,字段
            //DateTime dateTime = new DateTime();
            //Type type = dateTime.GetType();
            //PropertyInfo[] propertyInfos = type.GetProperties(); //所有的属性
            //MethodInfo[] methodInfos = type.GetMethods(); //所有的方法
            //FieldInfo[] fieldInfos = type.GetFields(); //所有的字段

            ////反射第二种:typeof()   没有实例对象的情况,比如静态类或单纯的类名
            //Type type1 = typeof(X);
            //PropertyInfo[] xpropertyInfos = type1.GetProperties(); //所有的属性
            //MethodInfo[] xmethodInfos = type1.GetMethods(); //所有的方法
            //FieldInfo[] xfieldInfos = type1.GetFields(); //所有的字段

            //Type type2 = typeof(StudyThread);
            //MethodInfo[] tmethodInfos = type2.GetMethods(); //所有的方法
            //StudyThread studyThread = (StudyThread)Activator.CreateInstance(type2);//Activator是根据Type获取实例对象
            //studyThread.Test();

            #endregion

            Console.Read();
        }

        public static void DoWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write('+');
            }
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
