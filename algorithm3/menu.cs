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
    public partial class menu : UserControl
    {

        private Form1 parentForm;
        public menu(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);

            parentForm.algInfo.label1.Text = "Сортировка с вставками";
            parentForm.algInfo.algType = 3;
            parentForm.algInfo.label2.Text = "Метод сортировки с вставками (Insertion Sort) - это простой алгоритм сортировки,\r\n\r\nкоторый работает путем пошагового построения отсортированного списка из неотсортированного.\r\n\r\nОн подходит для небольших списков или когда список уже частично упорядочен.\r\n\r\nВот как он работает:\r\n\r\nНачните с первого элемента (первого элемента считается упорядоченным списком).\r\n\r\nВозьмите следующий элемент и вставьте его в упорядоченную часть списка так, чтобы она оставалась упорядоченной.\r\n\r\nДля этого сравните его с элементами в упорядоченной части списка и вставьте его на правильное место.\r\n\r\nПовторяйте этот процесс для каждого следующего элемента, увеличивая размер упорядоченной части списка на один элемент на каждом шаге.\r\n\r\nПродолжайте это до тех пор, пока не пройдете через все элементы.";
            parentForm.Controls.Add(parentForm.algInfo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);

            parentForm.algInfo.label1.Text = "Сортировка перемешиванием";
            parentForm.algInfo.algType = 1;
            parentForm.algInfo.label2.Text = "Сортировка перемешиванием (Cocktail Shaker Sort), также известная как сортировка шейкера,\r\n\r\nсортировка двунаправленным пузырьком или шейкерная сортировка, является вариацией сортировки пузырьком.\r\n\r\nЭтот алгоритм сортировки работает следующим образом:\r\n\r\nНачните с инициализации двух указателей, одного в начале списка и другого в конце списка.\r\n\r\nИтерируйтесь через список, сравнивая и обменивая соседние элементы слева направо, а затем справа налево.\r\n\r\nПовторяйте этот процесс, перемещая указатели и уменьшая область сравнения на каждой итерации,\r\n\r\nпока не выполните полный проход в обоих направлениях без каких-либо обменов. Это показывает, что список отсортирован.";
            parentForm.Controls.Add(parentForm.algInfo);
            parentForm.algInfo.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);

            parentForm.algInfo.label1.Text = "Голубиная сортировка";
            parentForm.algInfo.algType = 2;
            parentForm.algInfo.label2.Text = "Голубиная сортировка (Pigeonhole Sort) - это относительно нестандартный алгоритм сортировки,\r\n\r\nкоторый подходит для сортировки данных, где значения элементов находятся в ограниченном диапазоне.\r\n\r\nОн основан на принципе \"голубиного отверстия\" (pigeonhole principle), который утверждает,\r\n\r\nчто если у вас есть больше \"голубей\" (элементов) чем \"голубиных отверстий\" (уникальных значений),\r\n\r\nто как минимум одно отверстие содержит более одного голубя, и этот принцип можно использовать для сортировки.\r\n\r\nПринцип работы голубиной сортировки:\r\n\r\nСоздайте массив \"голубиных отверстий\" (pigeonholes), соответствующий диапазону значений, которые вы хотите отсортировать.\r\n\r\nПройдитесь по исходному списку элементов и поместите каждый элемент в соответствующее \"голубиное отверстие\".\r\n\r\nЕсли два элемента имеют одно и то то же значение, они будут помещены в одно и то же отверстие.\r\n\r\nЗатем пройдитесь по массиву \"голубиных отверстий\" и извлеките элементы в порядке возрастания из каждого отверстия.\r\n\r\nЭлементы, извлеченные из отверстий в порядке возрастания, образуют отсортированный список.";
            parentForm.Controls.Add(parentForm.algInfo);
            parentForm.algInfo.Dock = DockStyle.Fill;
        }
    }
}
