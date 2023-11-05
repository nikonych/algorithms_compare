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
    public partial class AlgFoto : UserControl
    {
        private Form1 parentForm;
        public int algType;
        public AlgFoto(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            parentForm.Controls.Add(parentForm.algInfo);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (EnterNumbersModal modalForm = new EnterNumbersModal())
            {
                if (modalForm.ShowDialog() == DialogResult.OK)
                {
                    if (modalForm.Choice == EnterNumbersModal.UserChoice.ManualInput)
                    {
                        if (algType == 1)
                        {
                            // Пользователь выбрал "Ручной ввод"
                            int[] enteredNumbers = modalForm.EnteredNumbers;
                            parentForm.Controls.Remove(this);
                            parentForm.sortControl.SetArray(enteredNumbers);
                            parentForm.Controls.Add(parentForm.sortControl);
                        } else if (algType == 2)
                        {
                            // Пользователь выбрал "Ручной ввод"
                            int[] enteredNumbers = modalForm.EnteredNumbers;
                            parentForm.Controls.Remove(this);
                            parentForm.sortControl2.SetArray(enteredNumbers);
                            parentForm.Controls.Add(parentForm.sortControl2);
                        }
                        else if (algType == 3)
                        {
                            // Пользователь выбрал "Ручной ввод"
                            int[] enteredNumbers = modalForm.EnteredNumbers;
                            parentForm.Controls.Remove(this);
                            parentForm.sortControl3.SetArray(enteredNumbers);
                            parentForm.Controls.Add(parentForm.sortControl3);
                        }
                    }
                    else if (modalForm.Choice == EnterNumbersModal.UserChoice.RandomArray)
                    {
                        if (algType == 1)
                        {
                            // Пользователь выбрал "Создать рандомный массив"
                            parentForm.Controls.Remove(this);
                            Random random = new Random(modalForm.NumberForRandom);
                            int[] myint = new int[20];
                            for (int i = 0; i < myint.Length; i++)
                            {
                                myint[i] = random.Next(1, 100);
                            }
                            parentForm.sortControl.SetChunk(modalForm.NumberForRandom);
                            parentForm.sortControl.SetArray(myint);
                            parentForm.Controls.Add(parentForm.sortControl);
                        } else if (algType == 2)
                        {
                            // Пользователь выбрал "Создать рандомный массив"
                            parentForm.Controls.Remove(this);
                            Random random = new Random(modalForm.NumberForRandom);
                            int[] myint = new int[20];
                            for (int i = 0; i < myint.Length; i++)
                            {
                                myint[i] = random.Next(1, 100);
                            }
                            parentForm.sortControl2.SetChunk(modalForm.NumberForRandom);
                            parentForm.sortControl2.SetArray(myint);
                            parentForm.Controls.Add(parentForm.sortControl2);
                        } else if (algType == 3)
                        {
                            // Пользователь выбрал "Создать рандомный массив"
                            parentForm.Controls.Remove(this);
                            Random random = new Random(modalForm.NumberForRandom);
                            int[] myint = new int[20];
                            for (int i = 0; i < myint.Length; i++)
                            {
                                myint[i] = random.Next(1, 100);
                            }
                            parentForm.sortControl3.SetChunk(modalForm.NumberForRandom);
                            parentForm.sortControl3.SetArray(myint);
                            parentForm.Controls.Add(parentForm.sortControl3);
                        }
                    }

                }
            }
        }
    }
}
