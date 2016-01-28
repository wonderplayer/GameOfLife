using Game_of_Life;
using NUnit.Framework;
using Moq;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var mock = new Mock<Game>();
            mock.Verify();
        }
    }
}
