using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algorithm3
{


    public partial class EnterNumbersModal : Form
    {
        public EnterNumbersModal()
        {
            InitializeComponent();
        }
        public enum UserChoice
        {
            ManualInput,
            RandomArray
        }

        public UserChoice Choice { get; private set; }

        public int[] EnteredNumbers { get; private set; }

        public int NumberForRandom { get; private set; }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Отмена ввода
            Close();
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            // Разделите введенную строку на числа
            string[] numberStrings = textBoxNumbers.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            EnteredNumbers = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (int.TryParse(numberStrings[i], out int number))
                {
                    EnteredNumbers[i] = number;
                }
                else
                {
                    // Если введены неверные данные, можно сделать обработку ошибки
                    MessageBox.Show("Ошибка ввода числа.");
                    return;
                }
            }

            DialogResult = DialogResult.OK; // Устанавливаем результат диалога как OK
            Close(); // Закрываем модальное окно
        }

        private void EnterNumbersModal_Load(object sender, EventArgs e)
        {
            radioButtonManualInput.Checked = true;
            numericUpDown1.Value = 4;
            numericUpDown1.Enabled = false;
            Choice = UserChoice.ManualInput;

        }

        private void radioButtonManualInput_Click(object sender, EventArgs e)
        {
            radioButtonRandomArray.Checked = false;
            numericUpDown1.Enabled = false;
            textBoxNumbers.Enabled = true;
            Choice = UserChoice.ManualInput;
        }

        private void radioButtonRandomArray_Click(object sender, EventArgs e)
        {
            radioButtonManualInput.Checked = false;
            numericUpDown1.Enabled = true;
            textBoxNumbers.Enabled = false;
            Choice = UserChoice.RandomArray;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumberForRandom = (int)numericUpDown1.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
