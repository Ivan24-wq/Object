using stein;

namespace SteinTest
{
    [TestClass]
    public sealed class Algorihtm
    {
        [TestMethod]
        public void Test_Al()
        {
            int u = 298467352;
            int v = 569484;
            int expected = 4;

            int actual = SteinAlgorightm.FindGSDStrein(u, v);
            Assert.AreEqual(4, actual);
        }
    }
}
