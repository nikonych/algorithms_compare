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
    public partial class SortControl2 : UserControl
    {
        private int[] myint;
        private int[] originalArray;
        private bool sorting = false;
        private int currentIndex = -1;
        private int chunk = 0;
        private int sortedIndex = -1;
        private bool is_run = false;
        int left = 0;
        int right = 0;
        private int leftSortedBoundary = -1;
        private int rightSortedBoundary;
        private Form1 parentForm;
        private List<int[]> stateHistory = new List<int[]>();


        public void SetChunk(int chunk)
        {
            this.chunk = chunk;
        }
        public void SetArray(int[] array)
        {
            myint = array;
            rightSortedBoundary = myint.Length - 1;
            originalArray = array.Clone() as int[];

            // Сохраните копию исходного массива
            stateHistory.Clear();
            stateHistory.Add(array.Clone() as int[]);
        }

        public SortControl2(Form1 parentForm)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.parentForm = parentForm;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Location = new Point(100, 100);
            pictureBox.Name = "pictureBox1";
            pictureBox.Size = new Size(1000, 377);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // Задайте размеры PictureBox в зависимости от вашего окна или размещения.
            pictureBox.Image = Properties.Resources.wircowxsbt7nauhkqurxoqvbyzo;
            Controls.Add(pictureBox);
            button2.Visible = false;
            button_step_back.Visible = false;
            button_stop.Visible = false;
        }


        


        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            stateHistory.Add(arr.Clone() as int[]);
            Invalidate();
            Thread.Sleep(200);
        }

        public void RestartSorting()
        {
            if (sorting)
            {
                // Если сортировка выполняется, остановите ее
                StopSorting();
            }
            // Сброс состояния и восстановление исходного массива
            currentIndex = -1;
            sortedIndex = -1;
            leftSortedBoundary = -1;
            // Восстановите исходный массив
            myint = originalArray.Clone() as int[];
            rightSortedBoundary = myint.Length - 1;
            button_stop.Text = "Стоп";
            // Запустите сортировку
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartSorting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            parentForm.Controls.Add(parentForm.algFoto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            parentForm.resultControl.SetChunk(chunk);
            parentForm.resultControl.alg_type = 2;
            
            parentForm.resultControl.myint = originalArray.Clone() as int[];
            parentForm.resultControl.updateText(originalArray.Clone() as int[]);
            parentForm.Controls.Add(parentForm.resultControl);
        }

        // Метод для перехода к предыдущему шагу сортировки
        private async Task StepBack()
        {

            if (currentIndex > 0)
            {
                currentIndex--;
                sortedIndex--;
                leftSortedBoundary = Math.Max(leftSortedBoundary, currentIndex);
                rightSortedBoundary = Math.Min(rightSortedBoundary, currentIndex + 1);

                // Восстановите предыдущее состояние из истории
                if (stateHistory.Count > 1)
                {
                    stateHistory.RemoveAt(stateHistory.Count - 1);
                    myint = stateHistory.Last().Clone() as int[];
                }
                else
                {
                    button_step_back.Enabled = false;
                }

                Invalidate();
                await Task.Delay(10); // Добавьте задержку для анимации
            }
        }


        // Метод для остановки сортировки
        private void StopSorting()
        {
            if (sorting)
            {
                // Если сортировка выполняется, остановите ее
                sorting = false;
                button_stop.Text = "Старт";
                button_step_back.Enabled = true;
            }
            else
            {
                button_stop.Text = "Стоп";
                button_step_back.Enabled = false;
            }

        }



        private void button_step_back_Click(object sender, EventArgs e)
        {
            StepBack();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            StopSorting();
        }

        private void SortControl_Load(object sender, EventArgs e)
        {
            button_step_back.Enabled = false;
        }
    }
}
