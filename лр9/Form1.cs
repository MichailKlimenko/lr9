using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр9
{
    public partial class Form1 : Form
    {
        private List<bool[]> inputValues = new List<bool[]>();
        private List<bool[]> operationResults = new List<bool[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsValidBinaryValue(string value)
        {
            foreach (char c in value)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, что введено двоичное значение
            if (IsValidBinary(textBox1.Text))
            {
                // Парсим введенное значение и добавляем в список
                var binaryValue = textBox1.Text.Select(c => c == '1').ToArray();
                inputValues.Add(binaryValue);

                // Отображаем введенное значение в листбоксе
                listBox1.Items.Add(string.Join("", binaryValue.Select(b => b ? "1" : "0")));
            }
            else
            {
                MessageBox.Show("Введите двоичное значение (0 и 1)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputValues.Count < 2)
            {
                MessageBox.Show("Для операции AND требуется как минимум два введенных значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Применяем операцию AND к первым двум значениям
            var result = inputValues[0].Zip(inputValues[1], (x, y) => x && y).ToArray();

            // Удаляем первые два значения из списка и добавляем результат
            inputValues.RemoveRange(0, 2);
            operationResults.Add(result);

            // Обновляем листбоксы
            UpdateListBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inputValues.Count < 2)
            {
                MessageBox.Show("Для операции OR требуется как минимум два введенных значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Применяем операцию OR к первым двум значениям
            var result = inputValues[0].Zip(inputValues[1], (x, y) => x || y).ToArray();

            // Удаляем первые два значения из списка и добавляем результат
            inputValues.RemoveRange(0, 2);
            operationResults.Add(result);

            // Обновляем листбокс
            UpdateListBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Очищаем список и листбокс
            inputValues.Clear();
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Сортируем список по убыванию длины двоичных значений
            operationResults.Sort((x, y) => y.Length.CompareTo(x.Length));

            // Обновляем ListBox2
            UpdateListBoxes();
        }

        private void UpdateListBoxes()
        {
            // Очищаем листбоксы
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // Выводим введенные значения в ListBox1
            foreach (var value in inputValues)
            {
                listBox1.Items.Add(string.Join("", value.Select(b => b ? "1" : "0")));
            }

            // Выводим результаты операции в ListBox2
            foreach (var result in operationResults)
            {
                listBox2.Items.Add(string.Join("", result.Select(b => b ? "1" : "0")));
            }
        }

        private bool IsValidBinary(string text)
        {
            return text.All(c => c == '0' || c == '1');
        }

    }
}
