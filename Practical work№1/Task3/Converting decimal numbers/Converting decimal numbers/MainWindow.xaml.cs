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
            if (systemSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedBase = int.Parse((string)selectedItem.Tag);
            }
        }

        //Проверка на целочисленность
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(inputText.Text, out int number))
            {
                binaryLabel.Content = "Введите десятичное число!";
                return;
            }
            //Проверка на отрицательное число
            if (number < 0)
            {
                binaryLabel.Content = "Введите пожайлуста положительное число!";
                return;
            }
            //Если 0 -> вывод 0
            if (number == 0)
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

        //Конвертер арабского числа в римские числа
        private string ToRoman(int number)
        {
            if (number < 0)
                return " ";

            var romanNum = new Dictionary<int, string>()
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"}
            };

            //Результат строка
            StringBuilder result = new StringBuilder();
            foreach(var item in romanNum)
            {
                while (number >= item.Key)
                {
                    result.Append(item.Value);
                    number -= item.Key;
                }
            }
            //Ответ преобразуем в строку
            return result.ToString();
        }
        //Переведём римское в арабское
        private int ToArab(string roman)
        {
            var romanMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int number = 0;
            for(int i = 0; i < roman.Length; i++)
            {
                if(i + 1 < roman.Length && romanMap[roman[i]] < romanMap[roman[i + 1]])
                {
                    number += romanMap[roman[i + 1]] - romanMap[roman[i]];
                    i++;
                }
                else
                {
                    number += romanMap[roman[i]];
                }
            }
            return number;
        }
        //Обработчик кнопки
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string input = inputNum.Text.Trim();

            if (nums1selected.SelectedItem is ComboBoxItem fromItem &&
                nums2selected.SelectedItem is ComboBoxItem toItem)
            {
                int fromType = int.Parse((string)fromItem.Tag);
                int toType = toItem.Content.ToString() == "Римские" ? 2 : 1;

                //Проверяем отдельно случай Арабские -> Римские
                if (fromType == 1 && toType == 2) // Арабские -> Римские
                {
                    //Проверяем, что ввод корректный положительный арабский
                    if (!int.TryParse(input, out int number) || number <= 0)
                    {
                        binaryLabel2.Content = "Введите положительное число!"; 
                        return;
                    }
                    //Если число корректное, вызываем ToRoman
                    binaryLabel2.Content = ToRoman(number);
                }
                
                else if (fromType == 2 && toType == 1) // Римские -> Арабские
                {
                    try
                    {
                        int number = ToArab(input.ToUpper()); // Преобразуем римское в арабское
                        binaryLabel2.Content = number.ToString();
                    }
                    catch
                    {
                        binaryLabel2.Content = "Неверное римское число!";
                    }
                }
                
                else 
                {
                    binaryLabel2.Content = input;
                }
            }
        }

    }
}