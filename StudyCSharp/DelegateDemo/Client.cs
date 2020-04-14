using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp.DelegateDemo
{
    class Client
    {
        string clientName = "";
        public Client(string name,bool isSub = false)
        {
            clientName = name;
            if (isSub)
            {
                //这里的委托必须是+=,写成=就覆盖了,虽然我知道,但是我又忘了,所以写成事件,事件强制+=,所以事件是安全的委托
                InformationManager.instance.UpdateInformation += ReceiveInfo;
            }
        }

        public void ReceiveInfo()
        {
            Console.WriteLine($"{clientName}用户收到了消息: {InformationManager.instance.Info}");
        }
    }
}
