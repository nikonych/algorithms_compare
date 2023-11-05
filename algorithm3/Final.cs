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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace algorithm3
{
    public partial class Final : UserControl
    {
        private Form1 parentForm;
        private int chunk = 0;
        private int alg_type = 0;
        private int[] myint = { 4 };
        private int[] originalArray = { 5 };

        public Final(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        public void initArray(int[] myint)
        {
            this.myint = myint;
            originalArray = myint.Clone() as int[];
        }

        public void initChunk(int chunk)
        {
            this.chunk = chunk;
        }


        // Добавьте алгоритм сортировки выбором
        private SortingResult PigeonholeSort(int[] arr)
        {
            int iter_count = 0;
            bool swapped;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Начать отсчет времени
            do
            {
                swapped = false;

                // Инициализируем массив pigeonholes
                int min = arr.Min();
                int max = arr.Max();
                int range = max - min + 1;
                int[] pigeonholes = new int[range];

                // Распределение элементов по "голубятням" (подсчет элементов)
                for (int i = 0; i < arr.Length; i++)
                {
                    pigeonholes[arr[i] - min]++;
                }

                int currentIndex = 0;

                // Восстановление элементов обратно в исходный массив
                for (int i = 0; i < range; i++)
                {
                    while (pigeonholes[i] > 0)
                    {
                        if (arr[currentIndex] != i + min)
                        {
                            // Меняем элементы местами, если текущий элемент находится не на своем месте
                            int temp = arr[currentIndex];
                            arr[currentIndex] = arr[Array.IndexOf(arr, i + min)];
                            arr[Array.IndexOf(arr, i + min)] = temp;
                            swapped = true;
                            iter_count++;
                        }

                        pigeonholes[i]--;
                        currentIndex++;
                    }
                }
            } while (swapped);

            stopwatch.Stop();

            var workingSetCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            float memoryUsedMB = workingSetCounter.NextValue() / (1024 * 1024); // в мегабайтах

            var result = new SortingResult
            {
                ExecutionTime = stopwatch.Elapsed.TotalMilliseconds,
                Iterations = iter_count,
                MemoryUsageMB = memoryUsedMB
            };
            return result;
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Добавьте алгоритм Shaker Sort
        private SortingResult ShakerSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int iter_count = 0;
            int n = arr.Length;
            bool swapped;
            stopwatch.Start(); // Начать отсчет времени
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // Поменять элементы местами
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                       
                        swapped = true;
                    }
                }

                iter_count++;
                if (!swapped)
                {
                    // Если на данной итерации не было обменов, то массив уже отсортирован
                    break;
                }

                for (int i = n - 1; i > 0; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        // Поменять элементы местами
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        swapped = true;
                    }

                }

                iter_count++;
            } while (swapped);
            stopwatch.Stop();

            var workingSetCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            float memoryUsedMB = workingSetCounter.NextValue() / (1024 * 1024); // в мегабайтах

            var result = new SortingResult
            {
                ExecutionTime = stopwatch.Elapsed.TotalMilliseconds,
                Iterations = iter_count,
                MemoryUsageMB = memoryUsedMB
            };
            return result;
        }

        // Добавьте алгоритм сортировки вставками
        private SortingResult InsertionSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool swapped;
            int iter_count = 0;
            stopwatch.Start(); // Начать отсчет времени
            do
            {
                swapped = false;

                for (int i = 1; i < arr.Length; i++)
                {
                    int current = arr[i];
                    int j = i - 1;

                    // Перемещаем элементы, пока не найдем правильное место для текущего элемента
                    while (j >= 0 && arr[j] > current)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        swapped = true;
                    }

                    // Вставляем текущий элемент на правильное место
                    arr[j + 1] = current;

                    iter_count++;
                }
            } while (swapped);
            stopwatch.Stop();

            var workingSetCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            float memoryUsedMB = workingSetCounter.NextValue() / (1024 * 1024); // в мегабайтах

            var result = new SortingResult
            {
                ExecutionTime = stopwatch.Elapsed.TotalMilliseconds,
                Iterations = iter_count,
                MemoryUsageMB = memoryUsedMB
            };
            return result;
        }

        private void CreateComparisonChart()
        {

            SortingResult pigeonholeSortResult, shakerSortResult, insertionSortResult;
            int[] arr1 = originalArray.Clone() as int[];
            int[] arr2 = originalArray.Clone() as int[];
            int[] arr3 = originalArray.Clone() as int[];
            // Вызовите SelectionSort и сохраните результат
            pigeonholeSortResult = PigeonholeSort(arr1);

            // Вызовите ShakerSort и сохраните результат
            shakerSortResult = ShakerSort(arr2);

            // Вызовите InsertionSort и сохраните результат
            insertionSortResult = InsertionSort(arr3);
            // Создайте панель TableLayoutPanel
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.ColumnCount = 3;
            panel.RowCount = 1;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            this.Controls.Add(panel);

            // Создайте название для диаграммы итераций
            Title iterationsTitle = new Title("Итерации");
            iterationsTitle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Создайте диаграмму для итераций
            Chart iterationsChart = new Chart();
            iterationsChart.Size = new Size(300, 300);
            ChartArea iterationsChartArea = new ChartArea();
            iterationsChart.ChartAreas.Add(iterationsChartArea);
            Series iterationsSeries = new Series("Итерации");
            iterationsSeries.Palette = ChartColorPalette.BrightPastel;

            // Добавьте значения для каждого алгоритма
            iterationsSeries.Points.AddXY("Голубиная", pigeonholeSortResult.Iterations);
            iterationsSeries.Points.AddXY("Перемешивание", shakerSortResult.Iterations);
            iterationsSeries.Points.AddXY("Вставки", insertionSortResult.Iterations);

            iterationsChart.Series.Add(iterationsSeries);
            iterationsChart.Titles.Add(iterationsTitle);
            iterationsChart.Anchor = AnchorStyles.None;

            // Добавьте всплывающие подсказки для диаграммы итераций
            iterationsChart.GetToolTipText += (sender, e) =>
            {
                var hit = iterationsChart.HitTest(e.X, e.Y);

                if (hit.ChartElementType == ChartElementType.DataPoint)
                {
                    int pointIndex = hit.PointIndex;
                    e.Text = $"Значение: {iterationsSeries.Points[pointIndex].YValues[0]}";
                }
            };

            // Создайте название для диаграммы использования памяти
            Title memoryTitle = new Title("Память");
            memoryTitle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Создайте диаграмму для использования памяти
            Chart memoryChart = new Chart();
            memoryChart.Size = new Size(300, 300);
            memoryChart.ChartAreas.Add(new ChartArea());
            Series memorySeries = new Series("Память");
            memorySeries.Points.AddXY("Голубиная", pigeonholeSortResult.MemoryUsageMB);
            memorySeries.Points.AddXY("Перемешивание", shakerSortResult.MemoryUsageMB);
            memorySeries.Points.AddXY("Вставки", insertionSortResult.MemoryUsageMB);
            memorySeries.Palette = ChartColorPalette.BrightPastel;
            memoryChart.Series.Add(memorySeries);
            memoryChart.Titles.Add(memoryTitle);
            memoryChart.Anchor = AnchorStyles.None;

            // Добавьте всплывающие подсказки для диаграммы использования памяти
            memoryChart.GetToolTipText += (sender, e) =>
            {
                var hit = memoryChart.HitTest(e.X, e.Y);

                if (hit.ChartElementType == ChartElementType.DataPoint)
                {
                    int pointIndex = hit.PointIndex;
                    e.Text = $"Значение: {memorySeries.Points[pointIndex].YValues[0]}";
                }
            };

            // Создайте название для диаграммы времени выполнения
            Title timeTitle = new Title("Время выполнения");
            timeTitle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Создайте диаграмму для времени выполнения
            Chart timeChart = new Chart();
            timeChart.Size = new Size(300, 600);
            timeChart.ChartAreas.Add(new ChartArea());
            Series timeSeries = new Series("Время выполнения");
            timeSeries.Points.AddXY("Голубиная", pigeonholeSortResult.ExecutionTime);
            timeSeries.Points.AddXY("Перемешивание", shakerSortResult.ExecutionTime);
            timeSeries.Points.AddXY("Вставки", insertionSortResult.ExecutionTime);
            timeSeries.Palette = ChartColorPalette.BrightPastel;
            timeChart.Series.Add(timeSeries);
            timeChart.Titles.Add(timeTitle);
            timeChart.Anchor = AnchorStyles.None;

            // Добавьте всплывающие подсказки для диаграммы времени выполнения
            timeChart.GetToolTipText += (sender, e) =>
            {
                var hit = timeChart.HitTest(e.X, e.Y);

                if (hit.ChartElementType == ChartElementType.DataPoint)
                {
                    int pointIndex = hit.PointIndex;
                    e.Text = $"Значение: {timeSeries.Points[pointIndex].YValues[0]}";
                }
            };

            // Добавьте диаграммы и названия на панель TableLayoutPanel
            panel.Controls.Add(iterationsChart);
            panel.Controls.Add(memoryChart);
            panel.Controls.Add(timeChart);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            parentForm.Controls.Remove(this);
            parentForm.resultControl.SetChunk(chunk);
            parentForm.resultControl.alg_type = alg_type;

            parentForm.resultControl.myint = originalArray.Clone() as int[];
            parentForm.resultControl.updateText(originalArray.Clone() as int[]);
            parentForm.Controls.Add(parentForm.resultControl);
        }

        internal void initAlgType(int alg_type)
        {
            this.alg_type = alg_type;
        }

        private void Final_Load(object sender, EventArgs e)
        {
            CreateComparisonChart();
        }
    }

    internal class SortingResult
    {
        public double ExecutionTime { get; set; }
        public int Iterations { get; set; }
        public float MemoryUsageMB { get; set; }
    }
}
