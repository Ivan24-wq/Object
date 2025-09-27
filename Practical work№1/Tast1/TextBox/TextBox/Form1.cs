using System.Globalization;

namespace TextBox
{
    public partial class From : Form
    {


        public From()
        {
            InitializeComponent();
            string[] types = { "int", "string", "double", "bool", "char", "float" };
            comboFrom.Items.AddRange(types);
            comboTo.Items.AddRange(types);
            comboFrom.SelectedIndex = 0;
            comboTo.SelectedIndex = 1;
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

        //Пример явного
        private void button2_Click(object sender, EventArgs e)
        {
            string result = "Явное преобразование " + Environment.NewLine;
            int i = 100;
            double d = 123.45;
            char ch = 'A';

            //Вывод
            result += $"int -> byte: {i} -> {(byte)i}" + Environment.NewLine;
            result += $"double -> int: {d} -> {(int)d}" + Environment.NewLine;
            result += $"double -> float: {d} -> {(float)d}" + Environment.NewLine;
            result += $"char -> byte: {ch} -> {(byte)ch}" + Environment.NewLine;
            result += $"int -> char: {i} -> '{(char)i}'\n" + Environment.NewLine;
            textBox2.Text = result;
        }

        //Пример неявного
        private void button4_Click(object sender, EventArgs e)
        {
            string result = "Неявное преобразование " + Environment.NewLine;
            int i = 100;
            double f = 123.45;
            char ch = 'A';

            result += $"int -> byte: {i} -> {(byte)i}" + Environment.NewLine;
            result += $"int -> long: {i} -> {(long)i}" + Environment.NewLine;
            result += $"long -> float: {i} -> {(float)f}" + Environment.NewLine;
            result += $"float -> double: {f} -> {(double)f}" + Environment.NewLine;
            result += $"char -> int: {ch} -> '{(int)i}'" + Environment.NewLine;
            textBox2.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = "Безопасное преобразование: <is>" + Environment.NewLine;

            object obj1 = "Hello wolrd";
            object obj2 = 52;
            object obj3 = 3.14;
            //С помощью оператора IS
            if (obj1 is string s1)
            {
                result += $"obj1 is  string: {s1}" + Environment.NewLine;
            }
            if (obj2 is int i2)
            {
                result += $"obj2 is int: {i2}" + Environment.NewLine;
            }
            if (obj3 is int)
            {
                result += $"obj3 is int" + Environment.NewLine;
            }
            else
            {
                result += $"obj3 is not int" + Environment.NewLine;
            }

            //С помощью оператора as
            result += "Безопасное преобразование: <as>" + Environment.NewLine;

            string str1 = obj1 as string;
            string str2 = obj2 as string;
            string str3 = obj3 as string;
            result += $"obj1  as string: {(str1 ?? "null")}" + Environment.NewLine;
            result += $"obj2 as string: {(str2 ?? "null")}" + Environment.NewLine;
            result += $"obj3 нелья преобразовать в string тк {obj3.GetType().Name}" + Environment.NewLine;
            textBox2.Text = result;

        }
        //Пользовательское преобразование
        private void button5_Click(object sender, EventArgs e)
        {

            string result = "Пользовательское преобразование" + Environment.NewLine;

            //Создадим экземпляр класса
            Temperatue t = new Temperatue(25.5);
            double d1 = t;
            result += $"Temperature -> double (implicit): {t} -> {d1}" + Environment.NewLine;

            double d2 = 37.8;
            Temperatue t2 = (Temperatue)d2;
            result += $"double -> Temperature (explicit): {d2} -> {t2}" + Environment.NewLine;

            //Проверка на -
            Temperatue t3 = new Temperatue(-5);
            double d3 = t3;
            result += $"Temperature -> double: {t3} -> {d3}" + Environment.NewLine;
            textBox2.Text = result;

        }

        //Создадим класс Температура
        public class Temperatue
        {
            private double Celcium { get; set; } //Инкапсулируем
            public Temperatue(double celcium)
            {
                Celcium = celcium;
            }

            //неявное преобразование
            public static implicit operator double(Temperatue t)
            {
                return t.Celcium;
            }

            //Явное преобразование
            public static explicit operator Temperatue(double d)
            {
                return new Temperatue(d);
            }
            public override string ToString()
            {
                return $"{Celcium}C";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string result = "Convert, Parse " + Environment.NewLine;

            string str1 = "456,12";
            double d1 = Convert.ToDouble(str1);
            result += $"Convert.ToDouble: \"{str1}\" -> {d1}" + Environment.NewLine;

            //Преобразуем int с помощью Parse
            string str2 = "45";
            int i1 = int.Parse(str2);
            result += $"int.Parse: \"{str2}\" -> {i1}" + Environment.NewLine;

            //Проверка на ошибку при Parse
            string strR = "ert7";
            try
            {
                int.Parse(strR);
            }
            catch (FormatException)
            {
                result += $"TryParse: " + Environment.NewLine;
                result += $"Ошибка!!! Введённая строка: \"{strR}\" не является числом!" + Environment.NewLine;
            }

            //Tryparse
            string str3 = "7983";
            if (int.TryParse(str3, out int i2))
            {
                result += $"int.TryParse: \"{str3}\" -> {i2}" + Environment.NewLine;
            }
            else
            {
                result += $"int.TryParse: \"{str3}\" -> ошибка!" + Environment.NewLine;
            }
            textBox2.Text = result;
        }

        // Реализация дополнительного задания
        private void button7_Click(object sender, EventArgs e)
        {
            string fromType = comboFrom.SelectedItem.ToString();
            string toType = comboTp.SwlwctedItem.ToString();
            string input = TextBox3.Text;

            // Преобразование ввода в dynamic
            dynamic value = ParseToDynamic(input, fromType);
            //Преобразование в целочисленный тип
            object result = ConvertTo(value, toType);
        }
    }
}
