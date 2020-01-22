using Web.Models;
using Xunit;

namespace WebTest
{
    public class CalculatorTest
    {
        [Fact]
        public void ShouldAdd()
        {
            //xUnit���Է�Ϊ3��
            //1.Arrange ���Ⱦ�����,���紴������ʵ��,���������
            var sut = new Calculator(); //sut�� System Under Test
            //2.Act ִ�в��Դ��벢���ؽ��
            var result = sut.Add(1, 2); 
            //3.Assert �����,���Գɹ�����ʧ��
            Assert.Equal(3, result);
        }

        //������������,Theory�������Կ��Զ༸���������
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(5,5,10)]
        [InlineData(6,2,8)]
        public void ShouldAddMany(int x,int y,int expected)
        {
            //xUnit���Է�Ϊ3��
            //1.Arrange ���Ⱦ�����,���紴������ʵ��,���������
            var sut = new Calculator(); //sut�� System Under Test
            //2.Act ִ�в��Դ��벢���ؽ��
            var result = sut.Add(x, y);
            //3.Assert �����,���Գɹ�����ʧ��
            Assert.Equal(expected, result);
        }
    }
}
