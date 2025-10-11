using Microsoft.VisualStudio.TestTools.UnitTesting;
using computationByoverload;

namespace computationByoverload.Tests
{
    [TestClass]
    public class EuclidAlgorithmTests
    {
        [TestMethod]
        public void FindGCDEuclidTest1()
        {
          
            int a = 7396, b = 1978, c = 1204;
            int expected = 86;

            int actual = EuclidAlgorithm.FindGCDEuclid(a, b, c);

            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidTest2()
        {
            int a = 7396, b = 1978, c = 1204, d = 430;
            int expected = 86;

            int actual = EuclidAlgorithm.FindGCDEuclid(a, b, c, d);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidTest3()
        {
            int a = 7396, b = 1978, c = 1204, d = 430, e = 258;
            int expected = 86;

            int actual = EuclidAlgorithm.FindGCDEuclid(a, b, c, d, e);

            Assert.AreEqual(expected, actual);
        }
    }
}
