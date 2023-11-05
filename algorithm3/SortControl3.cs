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
    public partial class SortControl3 : UserControl
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

        public SortControl3(Form1 parentForm)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.parentForm = parentForm;
        }


        public async void StartSorting()
        {
            if (myint == null)
                return;

            if (sorting)
                return;
            is_run = true;
            sorting = true;
            button_step_back.Enabled = false;
            await InsertionSort(myint);
            sorting = false;
        }

        private bool sortingComplete = false; // Флаг, отслеживающий завершение сортировки

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (myint != null)
            {
                Graphics g = e.Graphics;
                int rectWidth = (Width - 10) / myint.Length;
                int fontSize = 12; // Размер шрифта
                Font font = new Font("Arial", fontSize);

                // Увеличьте верхний отступ (top) для поднятия прямоугольников
                int top = 300;

                for (int i = 0; i < myint.Length; i++)
                {
                    int rectHeight = myint[i] * (Height - fontSize - 20 - top) / (myint.Max()); // Уменьшено на 1/4 и добавлен top
                    Rectangle rect = new Rectangle(i * rectWidth + 10, Height - rectHeight - fontSize - top, rectWidth - 15, rectHeight);

                    if (sorting)
                    {
                        if (i >= leftSortedBoundary && i <= rightSortedBoundary)
                        {
                            if (i == currentIndex)
                            {
                                g.FillRectangle(Brushes.Purple, rect); // Текущий элемент
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Silver, rect); // Отсортированные элементы зеленые
                            }
                        }
                        else
                        {
                            if (i == currentIndex)
                            {
                                g.FillRectangle(Brushes.Purple, rect); // Текущий элемент
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Silver, rect); // Отсортированные элементы зеленые
                            }
                        }
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Silver, rect); // Отсортированные элементы зеленые
                    }

                    // Отображение чисел под прямоугольниками с увеличенным верхним отступом
                    string numberText = myint[i].ToString();
                    SizeF textSize = g.MeasureString(numberText, font);
                    PointF textLocation = new PointF(rect.Left + rectWidth / 2 - textSize.Width / 2, rect.Bottom); // Увеличен верхний отступ
                    g.DrawString(numberText, font, Brushes.Black, textLocation);
                }
            }
        }



        public void SortingComplete()
        {
            sortingComplete = true; // Установить флаг завершения сортировки
            Invalidate();
        }


        private async Task InsertionSort(int[] arr)
        {
            if (sorting)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (sorting)
                    {
                        int currentElement = arr[i];
                        int j = i - 1;

                        while (j >= 0 && arr[j] > currentElement)
                        {
                            if (sorting)
                            {
                                Swap(arr, j, j + 1);
                                j--;
                                currentIndex = j + 1; // Перемещается влево
                                await Task.Delay(10); // Анимация с задержкой
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                leftSortedBoundary = 0;
                rightSortedBoundary = arr.Length - 1;
                // Вызываем Invalidate(), чтобы обновить отображение
                Invalidate();
            }
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
            sortingComplete = false;
            leftSortedBoundary = -1;
            // Восстановите исходный массив
            myint = originalArray.Clone() as int[];
            rightSortedBoundary = myint.Length - 1;
            button_stop.Text = "Стоп";
            // Запустите сортировку
            StartSorting();
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
            parentForm.resultControl.alg_type = 3;
            
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
                    sortingComplete = false;
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
                StartSorting();
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
