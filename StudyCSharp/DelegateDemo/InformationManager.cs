using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp.DelegateDemo
{
    class InformationManager
    {
        private string mInfo;
        //public Action UpdateInformation; 委托
        public event Action UpdateInformation;

        //单例的消息管理器实例
        private static InformationManager _instance;
        public static InformationManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InformationManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 这个方法是事件的时候才用的,委托是直接调用,事件是触发,所以触发
        /// </summary>
        public string Info
        {
            get => mInfo;
            set
            {
                if (value != mInfo)
                {
                    mInfo = value;
                    if (UpdateInformation != null)
                    {
                        UpdateInformation();
                    }
                }
            }
        }

    }
}
