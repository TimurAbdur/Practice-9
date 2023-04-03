using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Калькулятор_строк
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void HistoryRecord(string mes)
        {
            StreamWriter his = new StreamWriter("history.txt", true);
            his.WriteLine(mes);
            his.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistoryRecord("Пользователь нажал посчитать;");
            double a, b, res = 0;
            try
            {
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox2.Text);
                if(b == 0) MessageBox.Show("На ноль делить нельзя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0: res = a + b; break;
                        case 1: res = a - b; break;
                        case 2: res = a * b; break;
                        case 3: res = a / b; break;
                        default: MessageBox.Show("Вы не выбрали операцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    }
                    HistoryRecord($"Результат: {res};");
                    textBox3.Text = res.ToString();
                }
                
            }
            catch
            {
                HistoryRecord("Ошибка на ввод данных;");
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Вы ничего не ввели!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Вы ввели не число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HistoryRecord("Пользователь нажал очистить;");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistoryRecord("Пользователь нажал выйти;");
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                HistoryRecord($"Пользователь ввел: {textBox1.Text}");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                HistoryRecord($"Пользователь ввел: {textBox2.Text}");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            HistoryRecord($"Пользователь выбрал: {comboBox1.Text};");
        }
    }
}
