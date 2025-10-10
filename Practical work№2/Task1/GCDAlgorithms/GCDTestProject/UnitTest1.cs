using Xunit;
using GCDAlgorithms;
namespace GCDTestProject

{
    public class UnitTest1
    {
        [Fact]
        public void GCDTest()
        {
            //����� ������� ������
            int a = 2806;
            int b = 345;
            int expented = 23;

            //����� ������ ��������
            int Actual = EuclidAlgorithm.FindGCDEuclid(a, b);

            //�������� ����������
            Assert.Equal(expented, Actual);
        }
    }
}