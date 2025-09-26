using System;
using System.Windows;
using System.Windows.Controls;

namespace Square_root
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal numberDecimal; // Число, для которого ищем корень
        private decimal result;        // Текущее приближение
        private decimal previous;      // Предыдущее значение
        private bool isReady;          // Флаг: метод готов к запуску
        private decimal delta;         // Точность
        private int iterations;        // Количество итераций
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox.Text;

            // Проверка double для Math.Sqrt
            if (!double.TryParse(input, out double numberDouble))
            {
                MessageBox.Show("Ошибка! Введите число типа double");
                return;
            }

            if (numberDouble < 0)
            {
                MessageBox.Show("Ошибка! Число не должно быть отрицательным");
                return;
            }

            // Вычисление квадратного корня стандартным методом
            double squareRoot = Math.Sqrt(numberDouble);
            resultLabel.Content = "Корень: " + squareRoot.ToString("0.######");

            // Проверка decimal для метода Ньютона
            if (!decimal.TryParse(input, out numberDecimal))
            {
                MessageBox.Show("Ошибка! Введите число типа decimal");
                return;
            }

            if (numberDecimal < 0)
            {
                MessageBox.Show("Ошибка! Число не должно быть отрицательным");
                return;
            }

            if (numberDecimal == 0)
            {
                Newtonres.Content = "Результат: 0";
                isReady = false;
                return;
            }

            // Начальное приближение
            string guessInput = inputTextBox1.Text;
            if (!decimal.TryParse(guessInput, out decimal guess))
            {
                MessageBox.Show("Введите корректное приближение типа decimal");
                return;
            }

            if (guess <= 0)
            {
                MessageBox.Show("Начальное приближение должно быть положительным!");
                return;
            }

            result = guess;        // Задаём начальное приближение
            delta = 1e-10m;        // Точность decimal
            iterations = 0;
            isReady = true;

            Newtonres.Content = "Начальное приближение: " + result;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Сначала введите число и нажмите кнопку для начала!");
                return;
            }

            decimal change;
            decimal error;

            // Метод Ньютона
            do
            {
                previous = result;
                result = (previous + numberDecimal / previous) / 2;
                change = result - previous;
                error = Math.Abs(change);
                iterations++;
            } while (error > delta);

            // Вывод результатов
            Newtonres.Content =
                $"Итераций: {iterations}\n" +
                $"Корень: {result:0.#############################}\n" +
                $"Погрешность: {error:E1}\n";

            isReady = false; 
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}
