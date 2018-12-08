using System;
using Xunit;

namespace RestAPIAutomation
{
    public class APIAutomation :BaseClass
    {
        public  APIAutomation() : base()
        {
            Console.Write("inside class cons");
        }
        [Fact]
        public void GetAPIAutomation()
        {
            Console.WriteLine("inside the first test");
            Assert.True(true);
        }
    }
}
