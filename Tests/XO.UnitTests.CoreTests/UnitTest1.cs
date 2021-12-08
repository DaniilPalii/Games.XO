using System.Linq;
using NUnit.Framework;
using XO.Core;
using XO.Core.Internal;

namespace XO.UnitTests.CoreTests
{
    public class GridTests
    {
        [Test]
        public void TestGetDiagonal()
        {
            var grid = new Grid();

            var diagonal = grid.GetDiagonal();

            Assert.AreEqual(
                new Position[] { new(0, 0), new(1, 1), new(2, 2) },
                diagonal.Select(c => c.Position));
        }

        [Test]
        public void TestGetAntidiagonal()
        {
            var grid = new Grid();

            var diagonal = grid.GetAntidiagonal();

            Assert.AreEqual(
                new Position[] { new(0, 2), new(1, 1), new(2, 0) },
                diagonal.Select(c => c.Position));
        }
    }
}
