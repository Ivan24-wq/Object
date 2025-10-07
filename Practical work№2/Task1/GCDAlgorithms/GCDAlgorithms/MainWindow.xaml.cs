using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GCDAlgorithms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчик кнопки
        private void gcd_Click(object sender, RoutedEventArgs e)
        {
            //Обратотка чисел и преобразование в целочисленный тип
            //Нужно вводить только целые числа
            if (!int.TryParse(input_number1.Text, out int a) ||
                !int.TryParse(input_number2.Text, out int b))
            {
                output_response.Text = "Введите целочисленное число!";
                return;
            }


            //Вызов метода нахождения
            int gcd = GCDAlgorithms.FindGCDEuclid(a, b);
            output_response.Text = $"({a}, {b}) = {gcd}";
        }
        //Реализация нахождения НОД
        public static class GCDAlgorithms
        {
            public static int FindGCDEuclid(int a, int b)
            {
                a = Math.Abs(a);
                b = Math.Abs(b);

                // Делим до тех пор пока в остатке не получим ноль
                while (b != 0)
                {
                    int res = a % b;
                    a = b;
                    b = res;
                }
                return a;
            }
        }
    }
}
