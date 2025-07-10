namespace RepoWindowsForm
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
            button1 = new Button();
            Intro = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(70, 209);
            button1.Name = "button1";
            button1.Size = new Size(103, 43);
            button1.TabIndex = 1;
            button1.Text = "Yes";
            button1.UseVisualStyleBackColor = true;
            // 
            // Intro
            // 
            Intro.BackColor = SystemColors.ControlLightLight;
            Intro.BorderStyle = BorderStyle.None;
            Intro.Font = new Font("Segoe UI", 15F);
            Intro.Location = new Point(70, 53);
            Intro.Multiline = true;
            Intro.Name = "Intro";
            Intro.Size = new Size(408, 104);
            Intro.TabIndex = 2;
            Intro.Text = "Welcome to Home Media Repository!\r\n\r\nBegin repository initialization?";
            // 
            // button2
            // 
            button2.Location = new Point(170, 209);
            button2.Name = "button2";
            button2.Size = new Size(103, 43);
            button2.TabIndex = 3;
            button2.Text = "No";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(103, 43);
            button3.TabIndex = 3;
            button3.Text = "No";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 662);
            Controls.Add(button2);
            Controls.Add(Intro);
            Controls.Add(button1);
            Controls.Add(button3);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox Intro;
        private Button button2;
        private Button button3;

    }
}
