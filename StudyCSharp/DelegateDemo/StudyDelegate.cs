using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp
{
    /// <summary>
    /// 学习委托的类,弃用
    /// </summary>
    public class StudyDelegate<T>
    {
        public delegate T Mydelegate(T value);

        public T Sword(T value, Mydelegate mydelegate)
        {
            Console.WriteLine("此乃上古神兵,青釭剑 基础攻击力20");
            var result = mydelegate(value);
            return result;
        }

    }

    public class Thermostat
    {
        public Action<float> OnTemperatureChange { get; set; }

        private float _CurrentTemperature;
        public float CurrentTemperature 
        { 
            get { return _CurrentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    //不用这种的原因是,有一个订阅者出错,其他的订阅者就收不到消息了,所以需要遍历
                    //_CurrentTemperature = value;
                    //OnTemperatureChange?.Invoke(value);

                    Action<float> onTemperatureChange = OnTemperatureChange;
                    if (onTemperatureChange != null)
                    {
                        List<Exception> exceptionCollection = new List<Exception>();
                        foreach (Action<float> handler in onTemperatureChange.GetInvocationList())
                        {
                            try
                            {
                                handler?.Invoke(value);
                            }
                            catch (Exception ex)
                            {
                                exceptionCollection.Add(ex);
                            }
                        }
                        //所有异常都得到报告，同时所有订阅者都不会错过通知
                        if (exceptionCollection.Count > 0)
                        {
                            throw new AggregateException("发布订阅有订阅者出错了,",exceptionCollection);
                        }
                    }
                }
            }
        }

    }

    public class Cooler
    {
        public Cooler(float temperature)
        {
            Temperature = temperature;
        }
        public float Temperature { get; set; }
        
        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature > Temperature)
            {
                Console.WriteLine("开启冷却");
            }
            else
            {
                Console.WriteLine("关闭冷却");
            }
        }
    }

    public class Heater
    {
        public Heater(float temperature)
        {
            Temperature = temperature;
        }
        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature < Temperature)
            {
                Console.WriteLine("开启加热");
            }
            else
            {
                Console.WriteLine("关闭加热");
            }
        }
    }

}
