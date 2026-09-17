namespace ICA01_TrekLight
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
            components = new System.ComponentModel.Container();
            UI_TImer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // UI_TImer
            // 
            UI_TImer.Enabled = true;
            UI_TImer.Tick += UI_TImer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer UI_TImer;
    }
}
