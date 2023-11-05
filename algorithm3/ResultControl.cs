using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace algorithm3
{
    public partial class ResultControl : UserControl
    {

        private Form1 parentForm;
        private int chunk = 0;
        public int alg_type = 1;
        public int[] myint;
        private int[] originalArray;
        public string results;
        public ResultControl(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        public void SetChunk(int chunk)
        {
            this.chunk = chunk;
        }

        // Свойство для установки результатов сортировки и параметров алгоритма
        public string ResultsText
        {
            get { return textBox1.Text; }
            set
            {
                // Добавьте отступы и стиль текста
                string formattedText = $"======== Результаты сортировки =======\r\n{value}\r\n============================\r\n";
                textBox1.Text = formattedText;
            }
        }

        public void updateText(int[] myint)
        {
            originalArray = myint.Clone() as int[];
            Stopwatch stopwatch = new Stopwatch();
            int iter_count = 1;
            results = "\r\n\r\n";
            int n = myint.Length;
            if (alg_type == 1)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (myint[i] > myint[i + 1])
                        {
                            // Поменять элементы местами
                            int temp = myint[i];
                            myint[i] = myint[i + 1];
                            myint[i + 1] = temp;

                            swapped = true;
                        }
                    }

                    results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    iter_count++;
                    if (!swapped)
                    {
                        // Если на данной итерации не было обменов, то массив уже отсортирован
                        break;
                    }

                    for (int i = n - 1; i > 0; i--)
                    {
                        if (myint[i] < myint[i - 1])
                        {
                            // Поменять элементы местами
                            int temp = myint[i];
                            myint[i] = myint[i - 1];
                            myint[i - 1] = temp;

                            swapped = true;
                        }
                    }

                    results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    iter_count++;
                } while (swapped);
            }
            else if (alg_type == 2)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;

                    // Инициализируем массив pigeonholes
                    int min = myint.Min();
                    int max = myint.Max();
                    int range = max - min + 1;
                    int[] pigeonholes = new int[range];

                    // Распределение элементов по "голубятням" (подсчет элементов)
                    for (int i = 0; i < myint.Length; i++)
                    {
                        pigeonholes[myint[i] - min]++;
                    }

                    int currentIndex = 0;

                    // Восстановление элементов обратно в исходный массив
                    for (int i = 0; i < range; i++)
                    {
                        while (pigeonholes[i] > 0)
                        {
                            if (myint[currentIndex] != i + min)
                            {
                                // Меняем элементы местами, если текущий элемент находится не на своем месте
                                int temp = myint[currentIndex];
                                myint[currentIndex] = myint[Array.IndexOf(myint, i + min)];
                                myint[Array.IndexOf(myint, i + min)] = temp;
                                swapped = true;
                                iter_count++;
                                results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                            }

                            pigeonholes[i]--;
                            currentIndex++;
                        }
                    }
                } while (swapped);
            }
            else if (alg_type == 3)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;

                    for (int i = 1; i < myint.Length; i++)
                    {
                        int current = myint[i];
                        int j = i - 1;

                        // Перемещаем элементы, пока не найдем правильное место для текущего элемента
                        while (j >= 0 && myint[j] > current)
                        {
                            myint[j + 1] = myint[j];
                            j--;
                            swapped = true;
                        }

                        // Вставляем текущий элемент на правильное место
                        myint[j + 1] = current;

                        iter_count++;
                        results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    }
                } while (swapped);
            }
            stopwatch.Stop(); // Остановить отсчет времени

            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = string.Format("Время сортировки: {0} мс", elapsed.TotalMilliseconds);

            this.IterCountText = $"{elapsedTime}\r\n\r\nИтериций: {iter_count - 1}";
            // Установите результаты и параметры алгоритма в пользовательском элементе управления
            this.ResultsText = results;
        }

        public string IterCountText
        {
            get { return label2.Text; }
            set
            {
                // Добавьте отступы и стиль текста
                string formattedText = $"{value}";
                label2.Text = formattedText;
            }
        }




        private void ResultControl_Load(object sender, EventArgs e)
        {
            originalArray = myint.Clone() as int[];
            Stopwatch stopwatch = new Stopwatch();
            int iter_count = 1;
            results = "\r\n\r\n";
            int n = myint.Length;
            if (alg_type == 1)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (myint[i] > myint[i + 1])
                        {
                            // Поменять элементы местами
                            int temp = myint[i];
                            myint[i] = myint[i + 1];
                            myint[i + 1] = temp;

                            swapped = true;
                        }
                    }

                    results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    iter_count++;
                    if (!swapped)
                    {
                        // Если на данной итерации не было обменов, то массив уже отсортирован
                        break;
                    }

                    for (int i = n - 1; i > 0; i--)
                    {
                        if (myint[i] < myint[i - 1])
                        {
                            // Поменять элементы местами
                            int temp = myint[i];
                            myint[i] = myint[i - 1];
                            myint[i - 1] = temp;

                            swapped = true;
                        }
                    }

                    results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    iter_count++;
                } while (swapped);
            }
            else if (alg_type == 2)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;

                    // Инициализируем массив pigeonholes
                    int min = myint.Min();
                    int max = myint.Max();
                    int range = max - min + 1;
                    int[] pigeonholes = new int[range];

                    // Распределение элементов по "голубятням" (подсчет элементов)
                    for (int i = 0; i < myint.Length; i++)
                    {
                        pigeonholes[myint[i] - min]++;
                    }

                    int currentIndex = 0;

                    // Восстановление элементов обратно в исходный массив
                    for (int i = 0; i < range; i++)
                    {
                        while (pigeonholes[i] > 0)
                        {
                            if (myint[currentIndex] != i + min)
                            {
                                // Меняем элементы местами, если текущий элемент находится не на своем месте
                                int temp = myint[currentIndex];
                                myint[currentIndex] = myint[Array.IndexOf(myint, i + min)];
                                myint[Array.IndexOf(myint, i + min)] = temp;
                                swapped = true;
                                iter_count++;
                                results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                            }

                            pigeonholes[i]--;
                            currentIndex++;
                        }
                    }
                } while (swapped);
            }
            else if (alg_type == 3)
            {
                bool swapped;
                stopwatch.Start(); // Начать отсчет времени
                do
                {
                    swapped = false;

                    for (int i = 1; i < myint.Length; i++)
                    {
                        int current = myint[i];
                        int j = i - 1;

                        // Перемещаем элементы, пока не найдем правильное место для текущего элемента
                        while (j >= 0 && myint[j] > current)
                        {
                            myint[j + 1] = myint[j];
                            j--;
                            swapped = true;
                        }

                        // Вставляем текущий элемент на правильное место
                        myint[j + 1] = current;

                        iter_count++;
                        results += $"Итерация {iter_count}: {string.Join(", ", myint)}\r\n\r\n";
                    }
                } while (swapped);
            }
            stopwatch.Stop(); // Остановить отсчет времени

            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = string.Format("Время сортировки: {0} мс", elapsed.TotalMilliseconds);

            this.IterCountText = $"{elapsedTime}\r\n\r\nИтериций: {iter_count - 1}";
            // Установите результаты и параметры алгоритма в пользовательском элементе управления
            this.ResultsText = results;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            if (alg_type == 1)
            {
                parentForm.Controls.Add(parentForm.sortControl);
            }
            else if (alg_type == 2)
            {
                parentForm.Controls.Add(parentForm.sortControl2);
            }
            else if (alg_type == 3)
            {
                parentForm.Controls.Add(parentForm.sortControl3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            parentForm.finalControl.initArray(originalArray);
            parentForm.finalControl.initChunk(chunk);
            parentForm.finalControl.initAlgType(alg_type);
            parentForm.Controls.Add(parentForm.finalControl);
        }
    }
}
