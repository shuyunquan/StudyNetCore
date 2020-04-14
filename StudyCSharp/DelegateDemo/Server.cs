using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp.DelegateDemo
{
    class Server
    {
        public void PublishInfo(string info)
        {
            Console.WriteLine($"服务器发布了新消息: {info}");
            InformationManager.instance.Info = info;
            //InformationManager.instance.UpdateInformation?.Invoke(); 如果是委托需要调用
        }
    }
}
