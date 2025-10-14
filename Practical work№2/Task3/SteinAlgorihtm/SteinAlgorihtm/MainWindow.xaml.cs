using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteinAlgorihtm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            string input = input_num.Text;
            if(input.Contains('.') || input.Contains(','))
            {
                output.Text = "Ошибка нужно вводить только целын числа";
                return;
            }
            //Проверка на целочисленность
            if(!int.TryParse(input, out int number))
            {
                output.Text = "Нужно вводить только целые числа!";
                return;
            }

            string result = Prime.ShowShift(number);
            output.Text = result;
        }

        //Обработчик кнопки нажатия
        private void gcd_Click(object sender, RoutedEventArgs e)
        {
            //Вводим числа как строку
            string[] parts = num1.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Вводи 2 числа
            if (parts.Length > 2)
            {
                output_res.Text = "Вводите только два числа!";
                return;
            }
            //Проверка на целые
            if (!int.TryParse(parts[0], out int a) || !int.TryParse(parts[1], out int b))
            {
                output_res.Text = "Введите только целые числа!";
                return;
            }

            //Вызов алгоритма Евклида
            int result = EuclidAlgorithm.FindGCDEuclid(a, b, out long time);
           
            //Вызов алгоритма Штейна
            int res = Stein.FindGSDStrein(a, b, out long timeStein);
            output_res.Text = $"НОД: {result}, Алгоритм Евклида: Time(ticks): {time}\n" + 
                                $"НОД: {res}, Алгоритм Штейна: Time(ticks): {timeStein}";
        }
    }
}