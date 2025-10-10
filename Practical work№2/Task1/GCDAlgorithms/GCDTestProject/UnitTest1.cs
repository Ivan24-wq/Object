using Xunit;
using GCDAlgorithms;
namespace GCDTestProject

{
    public class UnitTest1
    {
        [Fact]
        public void GCDTest()
        {
            //Ввожу входные данные
            int a = 2806;
            int b = 345;
            int expented = 23;

            //Вызов метода проверки
            int Actual = EuclidAlgorithm.FindGCDEuclid(a, b);

            //Проверка результата
            Assert.Equal(expented, Actual);
        }
    }
}