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

namespace Converting_decimal_numbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Начинаем с двоичное системы
        private int selectedBase = 2;
        public MainWindow()
        {
            InitializeComponent();
            systemSelected.SelectedIndex = 0;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            binaryLabel.Content = "";
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(systemSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedBase = int.Parse((string)selectedItem.Tag);
            }
        }

        //Проверка на целочисленность
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(inputText.Text, out int number))
            {
                binaryLabel.Content = "Введите десятичное число!";
                return;
            }
            //Проверка на отрицательное число
            if(number < 0)
            {
                binaryLabel.Content = "Введите пожайлуста положительное число!";
                return;
            }
            //Если 0 -> вывод 0
            if(number == 0)
            {
                binaryLabel.Content = "0";
                return;
            }
            //Сбор результатов строкой
            StringBuilder result = new StringBuilder();

            int temp = number;
            do
            {
                int remainder = temp % selectedBase;
                temp /= selectedBase; // уменьшаем при делении

                //Если система выше десятиричной
                if (remainder >= 10)
                {
                    result.Insert(0, (char)('A' + (remainder - 10)));
                }
                else
                {
                    result.Insert(0, remainder.ToString());
                }
            }
            while (temp > 0);
                binaryLabel.Content = result.ToString();
            


        }
    }
}