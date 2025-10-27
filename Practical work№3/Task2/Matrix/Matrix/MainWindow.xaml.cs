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

namespace Matrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[,] a, b, c;
        private Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update(object sender = null, RoutedEventArgs e = null)
        {
            try
            {
                int rowsA = Size(aRows.Text);
                int colsA = Size(aCols.Text);
                int colsB = Size(bCols.Text);

                bRows.Text = colsA.ToString();

                a = new double[rowsA, colsA];
                b = new double[colsA, colsB];
                c = new double[rowsA, colsB];

                Draw(aGrid, a);
                Draw(bGrid, b);
                Draw(cGrid, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Random(object sender = null, RoutedEventArgs e = null)
        {
            Random(a);
            Random(b);
            Draw(aGrid, a);
            Draw(bGrid, b);
        }

        //Перемножаем матрицы
        private void Multiply(object sender = null, RoutedEventArgs e = null)
        {
            try
            {
                Get(aGrid, a);
                Get(bGrid, b);

                int rowsA = a.GetLength(0);
                int colsA = a.GetLength(1);
                int rowsB = b.GetLength(0);
                int colsB = b.GetLength(1);

                // проверка на совместимость матриц
                if (colsA != rowsB)
                {
                    throw new ArgumentException("Количество столбцев в первой матрице должно совпадать с количеством сторк во второй!");
                }

                //Проверка матрицы A
                for (int row = 0; row < rowsA; row++)
                {
                    for (int col = 0; col < colsA; col++)
                    {
                        if (a[row, col] <= 0)
                        {
                            string message = string.Format("Матрица 1 содержит недопустимую запись в ячейке[{0}, {1}].", row, col);
                            throw new ArgumentException(message);
                        }
                    }
                }

                //Проверка для матрицы B
                for (int row = 0; row < rowsB; row++)
                {
                    for (int col = 0; col < colsB; col++)
                    {
                        if (b[row, col] <= 0)
                        {
                            string message = string.Format("Матрица 2 содержит недопустимую запись  в ячейке[{0}, {1}].", row, col);
                            throw new ArgumentException(message);
                        }
                    }
                }

                for (int i = 0; i < rowsA; i++)
                    for (int j = 0; j < colsB; j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < colsA; k++)
                            sum += a[i, k] * b[k, j];
                        c[i, j] = sum;
                    }

                Draw(cGrid, c);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Длинна колонки/строки не больше 15
        private int Size(string text) => Math.Min(int.Parse(text), 15);

        //Заносим данные в интерфейс
        private void Draw(Grid grid, double[,] m)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            for (int i = 0; i < cols; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < rows; i++)
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    var box = new TextBox
                    {
                        Text = Format(m[i, j]),
                        Margin = new Thickness(1),
                        TextAlignment = TextAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    Grid.SetRow(box, i);
                    Grid.SetColumn(box, j);
                    grid.Children.Add(box);
                }
        }

        //Форматируем ввод
        private string Format(double num) => num == (int)num ? ((int)num).ToString() : num.ToString("0.##");

        //Случайные числа
        private void Random(double[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] = rnd.Next(-10, 10);
        }

        //Принимаем данные
        private void Get(Grid grid, double[,] m)
        {
            foreach (TextBox box in grid.Children.OfType<TextBox>())
            {
                int row = Grid.GetRow(box);
                int col = Grid.GetColumn(box);
                m[row, col] = double.Parse(box.Text);
            }
        }
    }
}