using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp
{
    /// <summary>
    /// 学习泛型的类
    /// </summary>
    public class StudyT<T> where T : Movie
    {

        public void Add(T name)
        {
            Console.WriteLine("我是增加方法,变量是:" + name);
        }

    }
}
