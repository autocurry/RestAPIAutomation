using System;
using Xunit;

namespace RestAPIAutomation
{
    public class APIAutomation :BaseClass
    {
        public APIAutomation:BaseClass
        {
            BaseClass();
        }
        [Fact]
        public void GetAPIAutomation()
        {
            Console.WriteLine("inside the first test");
            Assert.True(true);
        }
    }
}
