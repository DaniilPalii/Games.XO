using NUnit.Framework;
using XO.Core;

namespace XO.Tests.UnitTests.CoreTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private Game? game;
    }
}