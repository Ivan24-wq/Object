using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Converting_decimal_numbers
{
    /// <summary>
    /// Главное окно WPF-приложения для преобразования чисел:
    /// - из десятичной системы в другие системы счисления,
    /// - из арабских чисел в римские и обратно.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Выбранная система счисления (по умолчанию двоичная).
        /// </summary>
        private int selectedBase = 2;

        /// <summary>
        /// Конструктор окна MainWindow.
        /// Инициализирует компоненты и задаёт начальные значения.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            systemSelected.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик изменения текста в поле ввода.
        /// Очищает содержимое метки для вывода результата.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события изменения текста.</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            binaryLabel.Content = "";
        }

        /// <summary>
        /// Обработчик выбора системы счисления в ComboBox.
        /// Устанавливает основание системы в переменную selectedBase.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события изменения выбора.</param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (systemSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedBase = int.Parse((string)selectedItem.Tag);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Convert".
        /// Выполняет преобразование введённого числа в выбранную систему счисления.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(inputText.Text, out int number))
            {
                binaryLabel.Content = "Введите десятичное число!";
                return;
            }
            if (number < 0)
            {
                binaryLabel.Content = "Введите пожайлуста положительное число!";
                return;
            }
            if (number == 0)
            {
                binaryLabel.Content = "0";
                return;
            }

            StringBuilder result = new StringBuilder();
            int temp = number;

            do
            {
                int remainder = temp % selectedBase;
                temp /= selectedBase;

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

        /// <summary>
        /// Преобразует арабское число в римское.
        /// </summary>
        /// <param name="number">Арабское число.</param>
        /// <returns>Римское число в виде строки.</returns>
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

            StringBuilder result = new StringBuilder();
            foreach (var item in romanNum)
            {
                while (number >= item.Key)
                {
                    result.Append(item.Value);
                    number -= item.Key;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Преобразует римское число в арабское.
        /// </summary>
        /// <param name="roman">Римское число (строка).</param>
        /// <returns>Арабское число.</returns>
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
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && romanMap[roman[i]] < romanMap[roman[i + 1]])
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

        /// <summary>
        /// Обработчик кнопки "Enter".
        /// Выполняет преобразование между арабскими и римскими числами в зависимости от выбранных опций.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события нажатия кнопки.</param>
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string input = inputNum.Text.Trim();

            if (nums1selected.SelectedItem is ComboBoxItem fromItem &&
                nums2selected.SelectedItem is ComboBoxItem toItem)
            {
                int fromType = int.Parse((string)fromItem.Tag);
                int toType = toItem.Content.ToString() == "Римские" ? 2 : 1;

                if (fromType == 1 && toType == 2) // Арабские → Римские
                {
                    if (!int.TryParse(input, out int number) || number <= 0)
                    {
                        binaryLabel2.Content = "Введите положительное число!";
                        return;
                    }
                    binaryLabel2.Content = ToRoman(number);
                }
                else if (fromType == 2 && toType == 1) // Римские → Арабские
                {
                    try
                    {
                        int number = ToArab(input.ToUpper());
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
