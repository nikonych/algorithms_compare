namespace algorithm3

{


    partial class EnterNumbersModal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxNumbers = new TextBox();
            buttonOK = new Button();
            numericUpDown1 = new NumericUpDown();
            radioButtonManualInput = new RadioButton();
            radioButtonRandomArray = new RadioButton();
            groupBoxInputMethod = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBoxInputMethod.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxNumbers
            // 
            textBoxNumbers.Location = new Point(176, 46);
            textBoxNumbers.Name = "textBoxNumbers";
            textBoxNumbers.Size = new Size(299, 27);
            textBoxNumbers.TabIndex = 0;
            textBoxNumbers.Tag = "";
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(344, 169);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(131, 46);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click_1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(176, 107);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(299, 27);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // radioButtonManualInput
            // 
            radioButtonManualInput.AutoSize = true;
            radioButtonManualInput.Location = new Point(12, 45);
            radioButtonManualInput.Name = "radioButtonManualInput";
            radioButtonManualInput.Size = new Size(117, 24);
            radioButtonManualInput.TabIndex = 3;
            radioButtonManualInput.TabStop = true;
            radioButtonManualInput.Text = "Ручной ввод";
            radioButtonManualInput.UseVisualStyleBackColor = true;
            radioButtonManualInput.Click += radioButtonManualInput_Click;
            // 
            // radioButtonRandomArray
            // 
            radioButtonRandomArray.AutoSize = true;
            radioButtonRandomArray.Location = new Point(12, 106);
            radioButtonRandomArray.Name = "radioButtonRandomArray";
            radioButtonRandomArray.Size = new Size(83, 24);
            radioButtonRandomArray.TabIndex = 4;
            radioButtonRandomArray.TabStop = true;
            radioButtonRandomArray.Text = "Рандом";
            radioButtonRandomArray.UseVisualStyleBackColor = true;
            radioButtonRandomArray.Click += radioButtonRandomArray_Click;
            // 
            // groupBoxInputMethod
            // 
            groupBoxInputMethod.Controls.Add(radioButtonRandomArray);
            groupBoxInputMethod.Controls.Add(radioButtonManualInput);
            groupBoxInputMethod.Location = new Point(-2, 1);
            groupBoxInputMethod.Name = "groupBoxInputMethod";
            groupBoxInputMethod.Size = new Size(140, 161);
            groupBoxInputMethod.TabIndex = 5;
            groupBoxInputMethod.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 23);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 6;
            label1.Text = "Массив:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 84);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 7;
            label2.Text = "Чанк:";
            // 
            // EnterNumbersModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(490, 232);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonOK);
            Controls.Add(textBoxNumbers);
            Controls.Add(groupBoxInputMethod);
            Name = "EnterNumbersModal";
            Text = "EnterNumbersModal";
            Load += EnterNumbersModal_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBoxInputMethod.ResumeLayout(false);
            groupBoxInputMethod.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNumbers;
        private Button buttonOK;
        private NumericUpDown numericUpDown1;
        private RadioButton radioButtonManualInput;
        private RadioButton radioButtonRandomArray;
        private GroupBox groupBoxInputMethod;
        private Label label1;
        private Label label2;
    }
}