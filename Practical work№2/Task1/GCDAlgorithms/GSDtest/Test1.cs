using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCDAlgorithmsLib;
namespace GSDtest
{
    [TestClass]
    public class GCDAlorihtmTest
    {
        [TestMethod]
        public void GCD_Zero()
        {
            //Входные данные
            int actual = EuclidAlgorithm.FindGCDEuclid(0, 0);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GCD_TEN()
        {
            int actual = EuclidAlgorithm.FindGCDEuclid(10, 10);
            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void GSD_TEN_T()
        {
            int actual = EuclidAlgorithm.FindGCDEuclid(25, 10);
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void GSD_HUNDRED()
        {
            int actual = EuclidAlgorithm.FindGCDEuclid(25, 100);
            Assert.AreEqual(25, actual);
        }

        [TestMethod]
        public void GSD_TWENTY_SIX()
        {
            int actual = EuclidAlgorithm.FindGCDEuclid(26, 100);
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void GSD_TWENTY_SEVEN()
        {
            int actual = EuclidAlgorithm.FindGCDEuclid(27, 100);
            Assert.AreEqual(1, actual);
        }
    }
}
