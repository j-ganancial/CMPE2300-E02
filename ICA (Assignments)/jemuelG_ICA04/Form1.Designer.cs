namespace jemuelG_ICA04
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
            UI_AddBalls_Btn = new Button();
            UI_ProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // UI_AddBalls_Btn
            // 
            UI_AddBalls_Btn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UI_AddBalls_Btn.Location = new Point(12, 12);
            UI_AddBalls_Btn.Name = "UI_AddBalls_Btn";
            UI_AddBalls_Btn.Size = new Size(776, 77);
            UI_AddBalls_Btn.TabIndex = 0;
            UI_AddBalls_Btn.Text = "Add Balls:";
            UI_AddBalls_Btn.UseVisualStyleBackColor = true;
            UI_AddBalls_Btn.MouseDown += UI_AddBalls_Btn_MouseDown;
            // 
            // UI_ProgressBar
            // 
            UI_ProgressBar.Location = new Point(12, 95);
            UI_ProgressBar.Maximum = 1000;
            UI_ProgressBar.Name = "UI_ProgressBar";
            UI_ProgressBar.Size = new Size(776, 69);
            UI_ProgressBar.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 176);
            Controls.Add(UI_ProgressBar);
            Controls.Add(UI_AddBalls_Btn);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Button UI_AddBalls_Btn;
        private ProgressBar UI_ProgressBar;
    }
}
