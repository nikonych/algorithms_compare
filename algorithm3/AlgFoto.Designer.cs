namespace algorithm3
{
    partial class AlgFoto
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(77, 639);
            button1.Name = "button1";
            button1.Size = new Size(121, 47);
            button1.TabIndex = 1;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.db1234_09072e676bec4d7fa0c1a5ae3695a885_mv2__1_;
            pictureBox1.Location = new Point(306, 191);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(609, 377);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(176, 73);
            label1.Name = "label1";
            label1.Size = new Size(931, 45);
            label1.TabIndex = 3;
            label1.Text = "Представление алгоритма, в виде визуальных элементов";
            // 
            // button2
            // 
            button2.Location = new Point(973, 639);
            button2.Name = "button2";
            button2.Size = new Size(121, 47);
            button2.TabIndex = 4;
            button2.Text = "Далее";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AlgFoto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "AlgFoto";
            Size = new Size(1200, 800);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        public PictureBox pictureBox1;
        private Label label1;
        private Button button2;
    }
}
