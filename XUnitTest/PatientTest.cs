using Web.Models;
using Xunit;
using Xunit.Abstractions;

namespace WebTest
{
    public class PatientTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Patient _patient; //使用这个可以减少重复代码,不用每个测试方法都new了

        public PatientTest(ITestOutputHelper output)
        {
            _output = output;
            _patient = new Patient();
        }

        [Fact]
        [Trait("Category","New")]
        public void ShouldBeOkWhereCreate()
        {
            _output.WriteLine("自定义测试输出,雷军发问");
            //老样子,xUnit测试三步走
            //1.Arrange 做先决条件,例如创建对象实例,数据输入等
            //var sut = new Patient(); //sut是 System Under Test
            //2.Act 执行测试代码并返回结果
            var result = _patient.AreYouOK;
            //3.Assert 检查结果,测试成功或者失败
            Assert.True(result);
        }

        [Fact]
        public void HaveCorrectFullName()
        {
            //var sut = new Patient
            //{
            //    FirstName = "许嵩",
            //    LastName = "Vae"
            //};
            _patient.FirstName = "许嵩";
            _patient.LastName = "Vae";

            var fullName = _patient.FullName;
            Assert.Equal("许嵩 Vae", fullName); //等
            Assert.StartsWith("许嵩", fullName);//开始包含
            Assert.EndsWith("Vae", fullName);//结尾包含
            Assert.Contains("许嵩 Vae", fullName);//包含
            Assert.Contains("嵩 V", fullName);//包含
            Assert.NotEqual("蜀云泉", fullName);//不等
        }

        [Fact]
        public void HaveIllHistory()
        {
            //针对集合的Assert测试
            //var sut = new Patient();
            _patient.History.Add("感冒");
            _patient.History.Add("咳嗽");
            _patient.History.Add("腹泻");
            Assert.Contains("感冒", _patient.History);
            Assert.DoesNotContain("心脏病", _patient.History);
            Assert.Contains(_patient.History, x => x.StartsWith("感")); //集合中包含至少一个是以 感 开头的
        }

        [Fact]
        [Trait("Category", "New")]
        public void BePatient()
        {
            //var sut = new Patient();
            Assert.IsType<Patient>(_patient);
        }

        [Fact(Skip = "忽略心率测试")]
        public void ShouldCalculateHeartBeatRate()
        {
            //var sut = new Patient();
            var result = _patient.CalculateHeartBeatRate();
            Assert.InRange<int>(result, 1, 100);
        }
    }
}
