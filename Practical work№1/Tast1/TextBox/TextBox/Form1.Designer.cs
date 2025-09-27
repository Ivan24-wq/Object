namespace TextBox
{
    partial class From
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new System.Windows.Forms.TextBox();
            label2 = new Label();
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label5 = new Label();
            comboFrom = new ComboBox();
            label6 = new Label();
            comboTo = new ComboBox();
            button7 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 77);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(347, 77);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(117, 26);
            button1.TabIndex = 2;
            button1.Text = "Проверить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(0, 7);
            button2.Name = "button2";
            button2.Size = new Size(157, 29);
            button2.TabIndex = 3;
            button2.Text = "Явное преобразование";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(0, 332);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(904, 180);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(8, 307);
            label2.Name = "label2";
            label2.Size = new Size(101, 22);
            label2.TabIndex = 6;
            label2.Text = "Результат:";
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(163, 7);
            button4.Name = "button4";
            button4.Size = new Size(178, 29);
            button4.TabIndex = 8;
            button4.Text = "Неявное преобразование";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(347, 7);
            button3.Name = "button3";
            button3.Size = new Size(194, 29);
            button3.TabIndex = 9;
            button3.Text = "Безопасное преобразование";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(547, 7);
            button5.Name = "button5";
            button5.Size = new Size(191, 29);
            button5.TabIndex = 10;
            button5.Text = "Пользовательское преобразование";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(744, 7);
            button6.Name = "button6";
            button6.Size = new Size(167, 29);
            button6.TabIndex = 11;
            button6.Text = "Convert/parse/TryParse";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(8, 81);
            label1.Name = "label1";
            label1.Size = new Size(97, 17);
            label1.TabIndex = 12;
            label1.Text = "Введите число:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(8, 136);
            label3.Name = "label3";
            label3.Size = new Size(269, 17);
            label3.TabIndex = 13;
            label3.Text = "Динамическое преобразование(dynamic)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(76, 19);
            label4.TabIndex = 14;
            label4.Text = "Значение:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(94, 175);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(87, 19);
            textBox3.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(206, 175);
            label5.Name = "label5";
            label5.Size = new Size(71, 18);
            label5.TabIndex = 16;
            label5.Text = "Из типа:";
            // 
            // comboFrom
            // 
            comboFrom.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboFrom.FormattingEnabled = true;
            comboFrom.Location = new Point(283, 175);
            comboFrom.Name = "comboFrom";
            comboFrom.Size = new Size(93, 27);
            comboFrom.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(393, 175);
            label6.Name = "label6";
            label6.Size = new Size(55, 19);
            label6.TabIndex = 18;
            label6.Text = "В тип:";
            // 
            // comboTo
            // 
            comboTo.FormattingEnabled = true;
            comboTo.Location = new Point(454, 178);
            comboTo.Name = "comboTo";
            comboTo.Size = new Size(94, 23);
            comboTo.TabIndex = 19;
            // 
            // button7
            // 
            button7.Location = new Point(598, 179);
            button7.Name = "button7";
            button7.Size = new Size(120, 23);
            button7.TabIndex = 20;
            button7.Text = "Преобразовать";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // From
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 524);
            Controls.Add(button7);
            Controls.Add(comboTo);
            Controls.Add(label6);
            Controls.Add(comboFrom);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "From";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private Label label2;
        private Button button4;
        private Button button3;
        private Button button5;
        private Button button6;
        private Label label1;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private Label label5;
        private ComboBox comboFrom;
        private Label label6;
        private ComboBox comboTo;
        private Button button7;
    }
}
