using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лабораторная_1_самостоятельная_часть
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int n;
        public int m;
        public int sum;
        public int[,] ptr;
        private void button2_Click(object sender, EventArgs e)  //при нажатии на кнопку сброс всё сбрасывается л-логично
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            label10.Text = "";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int i, j, m, n, summ,summ2;
            
            if (numericUpDown3.Value < numericUpDown4.Value)
            {
                label10.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }
            if (numericUpDown2.Value < numericUpDown1.Value)
            {
                label10.Text = "Номер строки находится за пределами матрицы!";
                return;
            }
            n = Convert.ToInt32(numericUpDown2.Value);
            m = Convert.ToInt32(numericUpDown2.Value);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int[,] ptr;
            ptr = new int[m, n];
            Random rand = new Random();
            dataGridView1.AutoResizeColumns();
            dataGridView1.ColumnCount = n;
            for (i = 0; i < n; i++)//Создание рандомного массива
            {
                dataGridView1.Rows.Add();
                for (j = 0; j < m; j++)
                {
                    ptr[i, j] = rand.Next(Convert.ToInt32(numericUpDown4.Value), Convert.ToInt32(numericUpDown3.Value));
                    dataGridView1.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
            for (j = 0; j < dataGridView1.Rows.Count; j++)
            {
                int sum = 0;
                //тут пробегаем не по строке, а по столбцу
                for (i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    sum += Convert.ToInt32(dataGridView1[j, i].Value);
                }
                //заносим сумму в лист, и переходим к следующей итерации
                //не забываем перед этим обнулить счетчик
                listBox1.Items.Add(sum);
            }


            //Цикл для проверки на ортогональность
            string a = "";
            int numberStr = Convert.ToInt32(numericUpDown1.Value);
            numberStr--;
            sum = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i == numberStr)
                {
                    i++;
                    if (i > n) { break; }
                }
                for (j = 0; j < m; j++)
                {
                    sum = ptr[i, j] * ptr[numberStr, j] + sum;
                }
                if (sum == 0) { a = a + (i+1).ToString() + ", "; }
                sum = 0;
            }
            numberStr++;
            if (string.IsNullOrEmpty(a)) { label10.Text = "Ортогональных строк нет"; }
            else if (a.Length == 3) { label10.Text = a.Trim(new Char[] { ',' }) + "строка ортогональна строке " + numberStr;  }
            else { label10.Text = a + "строки ортогональны строке " + numberStr; }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            int i, j;
            //Цикл для проверки на ортогональность
            string a = "";
            int numberStr = Convert.ToInt32(numericUpDown1.Value);
            sum = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i == numberStr)
                {
                    i++;
                    if (i > n) { break; }
                }
                for (j = 0; j < m; j++)
                {
                    sum = ptr[i, j] * ptr[numberStr, j] + sum;
                }
                if (sum == 0) { a = a + ", " + i.ToString(); }
                sum = 0;
                
            }
            if (string.IsNullOrEmpty(a)) { label10.Text = "Ортогональных строк нет"; }
            else { label10.Text = a + " строки ортогональны строке " + numberStr; }
            
            

            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            






        }
    }
}
