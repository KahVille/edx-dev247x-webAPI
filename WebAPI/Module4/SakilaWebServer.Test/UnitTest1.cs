using System;
using Xunit;

namespace SakilaWebServer.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, 0);
        }
    }
}
