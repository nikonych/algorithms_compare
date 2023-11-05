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
    public partial class AlgInfo : UserControl
    {

        private Form1 parentForm;

        public int algType;
        public AlgInfo(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            parentForm.Controls.Add(parentForm.menuForm);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Controls.Remove(this);
            if (algType == 1)
            {
                parentForm.algFoto.pictureBox1.Image = Properties.Resources.cocktail2_1024x728;
                parentForm.algFoto.algType = 1;
            }
            else if (algType == 2)
            {
                parentForm.algFoto.pictureBox1.Image = Properties.Resources.db1234_09072e676bec4d7fa0c1a5ae3695a885_mv2__1_;
                parentForm.algFoto.algType = 2;
            }
            else if (algType == 3)
            {
                parentForm.algFoto.pictureBox1.Image = Properties.Resources.insertionpass;
                parentForm.algFoto.algType = 3;
            }
            parentForm.Controls.Add(parentForm.algFoto);
        }
    }
}
