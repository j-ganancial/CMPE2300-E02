namespace jemuelG_ICA02_Bouncy
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
            UI_Radius_Lbl = new Label();
            UI_Opacity_Lbl = new Label();
            UI_All_checkBox = new CheckBox();
            UI_Radius_TxtBox = new TextBox();
            UI_TxtBox_All = new TextBox();
            UI_Opacity_TxtBox = new TextBox();
            UI_Timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // UI_Radius_Lbl
            // 
            UI_Radius_Lbl.AutoSize = true;
            UI_Radius_Lbl.BackColor = SystemColors.ControlDarkDark;
            UI_Radius_Lbl.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_Radius_Lbl.ForeColor = SystemColors.HighlightText;
            UI_Radius_Lbl.Location = new Point(40, 43);
            UI_Radius_Lbl.Name = "UI_Radius_Lbl";
            UI_Radius_Lbl.Size = new Size(79, 26);
            UI_Radius_Lbl.TabIndex = 0;
            UI_Radius_Lbl.Text = "Radius :";
            // 
            // UI_Opacity_Lbl
            // 
            UI_Opacity_Lbl.AutoSize = true;
            UI_Opacity_Lbl.BackColor = SystemColors.ControlDarkDark;
            UI_Opacity_Lbl.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_Opacity_Lbl.ForeColor = SystemColors.HighlightText;
            UI_Opacity_Lbl.Location = new Point(274, 43);
            UI_Opacity_Lbl.Name = "UI_Opacity_Lbl";
            UI_Opacity_Lbl.Size = new Size(89, 26);
            UI_Opacity_Lbl.TabIndex = 1;
            UI_Opacity_Lbl.Text = "Opacity :";
            // 
            // UI_All_checkBox
            // 
            UI_All_checkBox.AutoSize = true;
            UI_All_checkBox.BackColor = SystemColors.ControlDarkDark;
            UI_All_checkBox.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_All_checkBox.ForeColor = SystemColors.HighlightText;
            UI_All_checkBox.Location = new Point(40, 131);
            UI_All_checkBox.Name = "UI_All_checkBox";
            UI_All_checkBox.Size = new Size(53, 30);
            UI_All_checkBox.TabIndex = 3;
            UI_All_checkBox.Text = "All";
            UI_All_checkBox.UseVisualStyleBackColor = false;
            // 
            // UI_Radius_TxtBox
            // 
            UI_Radius_TxtBox.BackColor = SystemColors.Info;
            UI_Radius_TxtBox.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_Radius_TxtBox.ForeColor = SystemColors.ControlDarkDark;
            UI_Radius_TxtBox.Location = new Point(125, 46);
            UI_Radius_TxtBox.Name = "UI_Radius_TxtBox";
            UI_Radius_TxtBox.Size = new Size(55, 27);
            UI_Radius_TxtBox.TabIndex = 4;
            UI_Radius_TxtBox.Text = "30";
            // 
            // UI_TxtBox_All
            // 
            UI_TxtBox_All.BackColor = SystemColors.Info;
            UI_TxtBox_All.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_TxtBox_All.ForeColor = SystemColors.ControlDarkDark;
            UI_TxtBox_All.Location = new Point(25, 178);
            UI_TxtBox_All.Name = "UI_TxtBox_All";
            UI_TxtBox_All.Size = new Size(470, 27);
            UI_TxtBox_All.TabIndex = 6;
            // 
            // UI_Opacity_TxtBox
            // 
            UI_Opacity_TxtBox.BackColor = SystemColors.Info;
            UI_Opacity_TxtBox.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UI_Opacity_TxtBox.ForeColor = SystemColors.ControlDarkDark;
            UI_Opacity_TxtBox.Location = new Point(369, 46);
            UI_Opacity_TxtBox.Name = "UI_Opacity_TxtBox";
            UI_Opacity_TxtBox.Size = new Size(55, 27);
            UI_Opacity_TxtBox.TabIndex = 7;
            UI_Opacity_TxtBox.Text = "128";
            // 
            // UI_Timer
            // 
            UI_Timer.Enabled = true;
            UI_Timer.Interval = 20;
            UI_Timer.Tick += UI_Timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(524, 250);
            Controls.Add(UI_Opacity_TxtBox);
            Controls.Add(UI_TxtBox_All);
            Controls.Add(UI_Radius_TxtBox);
            Controls.Add(UI_All_checkBox);
            Controls.Add(UI_Opacity_Lbl);
            Controls.Add(UI_Radius_Lbl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UI_Radius_Lbl;
        private Label UI_Opacity_Lbl;
        private CheckBox UI_All_checkBox;
        private TextBox UI_Radius_TxtBox;
        private TextBox UI_TxtBox_All;
        private TextBox UI_Opacity_TxtBox;
        private System.Windows.Forms.Timer UI_Timer;
    }
}
