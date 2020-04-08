using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCSharp
{
    /// <summary>
    /// 学习委托的类,我写一个计算器委托
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
}
