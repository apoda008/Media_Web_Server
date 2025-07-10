using System;
using System.Windows.Forms;
using Media_Web_Server.Classes;

namespace Media_Web_Server.Classes
{
    public partial class MyForm : Form
    {
        public MyForm() 
        {
            Text = "Media Repository";
            Size = new System.Drawing.Size(600, 300);

            //TextBox textBox = new TextBox() 
            //{ 
            //    Text = "Begin Repo?",
            //    Visible = true,
            //    Dock = DockStyle.Fill,
            //    ForeColor = Color.Black,
            //    Enabled = false,

            //};

            Label infoLabel = new Label()
            {
                Text = "Begin Repo?",
                Location = new System.Drawing.Point(this.ClientSize.Width - 350, this.ClientSize.Height - 150),
                AutoSize = true,
                Font = new Font("Segoe UI",20),
                ForeColor = Color.Black
            };


            Button btn = new Button()
            {
                Text = "Begin",
                Dock = DockStyle.Fill,
                Size = new Size(100, 40),
                Anchor = AnchorStyles.Bottom & AnchorStyles.Left,
                Location = new Point(this.ClientSize.Width -110, this.ClientSize.Height - 50)
            };
            //btn.Click += (s, e) => ;

            Controls.Add(infoLabel);
            Controls.Add(btn);
        }
    
    }
}

public partial class FolderForm : Form 
{
    public FolderForm() 
    {
        Text = "Folder initialization";
        Size = new System.Drawing.Size(600, 300);
    }

    Label infolabel = new Label()
    {
        Text = "Please select where you would like the repository to exist.",
        //Location = new System.Drawing.Point(ClientSize.Width - 350, ClientSize.Height - 150),
        AutoSize = true,
        Font = new Font("Segoe UI", 20),
        ForeColor = Color.Black
    };

    Button btn = new Button()
    {
        Text = "Begin",
        Dock = DockStyle.Fill,
        Size = new Size(100, 40),
        Anchor = AnchorStyles.Bottom & AnchorStyles.Left,
        //Location = new Point(this.ClientSize.Width - 110, this.ClientSize.Height - 50)
    };
    


}
