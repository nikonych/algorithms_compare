namespace algorithm3
{
    partial class SortControl
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
            button2 = new Button();
            button3 = new Button();
            button_stop = new Button();
            button_step_back = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(56, 571);
            button1.Name = "button1";
            button1.Size = new Size(129, 51);
            button1.TabIndex = 0;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(278, 571);
            button2.Name = "button2";
            button2.Size = new Size(129, 51);
            button2.TabIndex = 1;
            button2.Text = "Заново";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(988, 571);
            button3.Name = "button3";
            button3.Size = new Size(129, 51);
            button3.TabIndex = 2;
            button3.Text = "Результаты";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button_stop
            // 
            button_stop.Location = new Point(783, 571);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(129, 51);
            button_stop.TabIndex = 4;
            button_stop.Text = "Старт";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // button_step_back
            // 
            button_step_back.Location = new Point(527, 571);
            button_step_back.Name = "button_step_back";
            button_step_back.Size = new Size(129, 51);
            button_step_back.TabIndex = 5;
            button_step_back.Text = "Шаг Назад";
            button_step_back.UseVisualStyleBackColor = true;
            button_step_back.Click += button_step_back_Click;
            // 
            // SortControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button_step_back);
            Controls.Add(button_stop);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "SortControl";
            Size = new Size(1200, 800);
            Load += SortControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button_stop;
        private Button button_step_back;
    }
}
