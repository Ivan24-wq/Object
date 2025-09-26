using System.Globalization;

namespace TextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

          
            if (char.IsControl(ch))
                return;

            
            if (char.IsDigit(ch))
                return;

            
            if ((ch == '.' || ch == ',') &&
                !textBox1.Text.Contains(",") &&
                !textBox1.Text.Contains("."))
            {
                return;
            }

            
            if ((ch == '+' || ch == '-') && textBox1.SelectionStart == 0 && !textBox1.Text.Contains("+") && !textBox1.Text.Contains("-"))
            {
                return;
            }

            
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double result) ||
                double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out result))
            {
                MessageBox.Show("Верно: " + result);
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
