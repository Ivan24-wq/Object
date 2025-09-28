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

        private ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(systemSelected.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedBase = int.Parse((string)selectedItem.Tag);
            }
        }

        //Проверка на целочисленность
        private convert_Click(object sender, RoutedCommand e)
        {
            if(!int.TryParse(inputText.Text, out int number))
            {

            }
        }
    }
}