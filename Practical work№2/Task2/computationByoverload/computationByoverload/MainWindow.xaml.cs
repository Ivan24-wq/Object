using System.Windows;
using System.Windows.Controls;
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
            if (numberSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                int cout = int.Parse(selectedItem.Tag.ToString());

                //Делим введённую строку на пробелы
                string[] parts = input_number.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Проверяем ввели ли скольно нужно чисел
                if (parts.Length != cout)
                {
                    output_response.Content = $"Введите столько чисел, сколько {cout}";
                    return;
                }

                //Проверка на целочисленные
                if (!parts.All(p => int.TryParse(p, out _)))
                {
                    output_response.Content = "Введите целое число!";
                    return;
                }

                //Преобразовываем ввод в массив
                int[] nums = parts.Select(int.Parse).ToArray();

                //Задание 3 Тест для перегрузок
                if(sender == gcd)
                {
                    int res = EuclidAlgorithm.FindGCDEuclid(nums[0], nums[1]);
                    output_response.Content = $"НОД: {res}";
                } else if(sender == gcd)
                {
                    int res = EuclidAlgorithm.FindGCDEuclid(nums[0], nums[1], nums[2]);
                    output_response.Content = $"НОД: {res}";
                }else if(sender == gcd)
                {
                    int res = EuclidAlgorithm.FindGCDEuclid(nums[0], nums[1], nums[2], nums[3]);
                    output_response.Content = $"НОД: {res}";
                }else if(sender == gcd)
                {
                    int res = EuclidAlgorithm.FindGCDEuclid(nums[0], nums[1], nums[2], nums[3], nums[4]);
                    output_response.Content = $"НОД: {res}";
                }
                else
                {
                    output_response.Content = "Выбери число!";
                }
            }
        }
    }
}