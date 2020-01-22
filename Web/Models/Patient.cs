using System;
using System.Collections.Generic;

namespace Web.Models
{
    //病人类,仅作为xUnit测试用例
    public class Patient
    {
        public Patient()
        {
            //病人初始化,雷军发问为Ture
            AreYouOK = true;
            History = new List<string>();
        }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 全名,这种=>写法是Lambda表达式,意思是只读,也就是FullName只有get,无法set赋值
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// 雷军发问
        /// </summary>
        public bool AreYouOK { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        public int HeartBeatRate { get; set; }

        /// <summary>
        /// 历史病例
        /// </summary>
        public List<string> History { get; set; }

        /// <summary>
        /// 计算心率,随机返回一个1~100的数字即可
        /// </summary>
        /// <returns></returns>
        public int CalculateHeartBeatRate()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
    }
}