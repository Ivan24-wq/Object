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
                MessageBox.Show("�����: " + result);
            }
            else
            {
                MessageBox.Show("������!");
            }
        }

        //������ ������
        private void button2_Click(object sender, EventArgs e)
        {
            string result = "����� �������������� " + Environment.NewLine;
            int i = 100;
            double d = 123.45;
            char ch = 'A';

            //�����
            result += $"int -> byte: {i} -> {(byte)i}" + Environment.NewLine;
            result += $"double -> int: {d} -> {(int)d}" + Environment.NewLine;
            result += $"double -> float: {d} -> {(float)d}" + Environment.NewLine;
            result += $"char -> byte: {ch} -> {(byte)ch}" + Environment.NewLine;
            result += $"int -> char: {i} -> '{(char)i}'\n" + Environment.NewLine;
            textBox2.Text = result;
        }

        //������ ��������
        private void button4_Click(object sender, EventArgs e)
        {
            string result = "������� �������������� " + Environment.NewLine;
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
            string result = "���������� ��������������: <is>" + Environment.NewLine;

            object obj1 = "Hello wolrd";
            object obj2 = 52;
            object obj3 = 3.14;
            //� ������� ��������� IS
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

            //� ������� ��������� as
            result += "���������� ��������������: <as>" + Environment.NewLine;

            string str1 = obj1 as string;
            string str2 = obj2 as string;
            string str3 = obj3 as string;
            result += $"obj1  as string: {(str1 ?? "null")}" + Environment.NewLine;
            result += $"obj2 as string: {(str2 ?? "null")}" + Environment.NewLine;
            result += $"obj3 ����� ������������� � string �� {obj3.GetType().Name}" + Environment.NewLine;
            textBox2.Text = result;

        }
        //���������������� ��������������
        private void button5_Click(object sender, EventArgs e)
        {

            string result = "���������������� ��������������" + Environment.NewLine;

            //�������� ��������� ������
            Temperatue t = new Temperatue(25.5);
            double d1 = t;
            result += $"Temperature -> double (implicit): {t} -> {d1}" + Environment.NewLine;

            double d2 = 37.8;
            Temperatue t2 = (Temperatue)d2;
            result += $"double -> Temperature (explicit): {d2} -> {t2}" + Environment.NewLine;

            //�������� �� -
            Temperatue t3 = new Temperatue(-5);
            double d3 = t3;
            result += $"Temperature -> double: {t3} -> {d3}" + Environment.NewLine;
            textBox2.Text = result;

        }

        //�������� ����� �����������
        public class Temperatue
        {
            private double Celcium { get; set; } //�������������
            public Temperatue(double celcium)
            {
                Celcium = celcium;
            }

            //������� ��������������
            public static implicit operator double(Temperatue t)
            {
                return t.Celcium;
            }

            //����� ��������������
            public static explicit operator Temperatue(double d)
            {
                return new Temperatue(d);
            }
            public override string ToString()
            {
                return $"{Celcium}C";
            }
        }
    }
}
