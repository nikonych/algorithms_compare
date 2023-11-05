namespace algorithm3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuForm = new menu(this);
            algInfo = new AlgInfo(this);
            algFoto = new AlgFoto(this);
            sortControl = new SortControl(this);
            sortControl2 = new SortControl2(this);
            sortControl3 = new SortControl3(this);
            resultControl = new ResultControl(this);
            finalControl = new Final(this);
            Controls.Add(menuForm);
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        public menu menuForm;
        public AlgInfo algInfo;
        public AlgFoto algFoto;
        public SortControl sortControl;
        public SortControl2 sortControl2;
        public SortControl3 sortControl3;
        public ResultControl resultControl;
        public Final finalControl;
    }
}