using Web.Models;
using Xunit;

namespace WebTest
{
    public class CalculatorTest
    {
        [Fact]
        public void ShouldAdd()
        {
            //xUnit测试分为3步
            //1.Arrange 做先决条件,例如创建对象实例,数据输入等
            var sut = new Calculator(); //sut是 System Under Test
            //2.Act 执行测试代码并返回结果
            var result = sut.Add(1, 2); 
            //3.Assert 检查结果,测试成功或者失败
            Assert.Equal(3, result);
        }

        //数据驱动测试,Theory这种特性可以多几组测试数据
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(5,5,10)]
        [InlineData(6,2,8)]
        public void ShouldAddMany(int x,int y,int expected)
        {
            //xUnit测试分为3步
            //1.Arrange 做先决条件,例如创建对象实例,数据输入等
            var sut = new Calculator(); //sut是 System Under Test
            //2.Act 执行测试代码并返回结果
            var result = sut.Add(x, y);
            //3.Assert 检查结果,测试成功或者失败
            Assert.Equal(expected, result);
        }
    }
}
