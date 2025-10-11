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

namespace computationByoverload
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
        private void gcd_Click(object sender, RoutedEventArgs e)
        {
           // Проверка ввели ли нужно количество чисел
           if(numberSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                int cout = int.Parse(selectedItem.Tag.ToString());

                //Делим введённую строку на пробелы
                string[] parts = input_number.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Проверяем ввели ли скольно нужно чисел
                if(parts.Length != cout)
                {
                    output_response.Content = $"Введите столько чисел, сколько {cout}";
                    return;
                }

                //Проверка на целочисленные
                if(!parts.All(p => int.TryParse(p, out _)))
                {
                    output_response.Content = "Введите целое число!";
                    return;
                }
            }
        }
    }
}