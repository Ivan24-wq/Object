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
    }
}