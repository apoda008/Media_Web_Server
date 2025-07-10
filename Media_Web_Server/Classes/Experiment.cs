using System;
using System.Drawing;
using System.Windows.Forms;

namespace Media_Web_Server.Classes
{
    public class PanelSwitcherForm : Form
    {
        #region Properties

        private Panel homePanel;
        private Panel settingsPanel;
        //private Button pickFolderButton;
        //private Label selectedPathLabel;

        #endregion
        public PanelSwitcherForm()
        {
            Text = "Media Repository Menu";
            Size = new Size(400, 300);

            // Home Panel
            homePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightBlue
            };
            Label homeLabel = new Label
            {
                Text = "Welcome to the Home Panel!",
                AutoSize = true,
                Location = new Point(150, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            homePanel.Controls.Add(homeLabel);

            // Settings Panel
            settingsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGreen,
                Visible = false // Start hidden
            };
            Label settingsLabel = new Label
            {
                Text = "Please select folder.",
                AutoSize = true,
                Location = new Point(150, 10)
            };
            settingsPanel.Controls.Add(settingsLabel);

            // Navigation Buttons
            Button btnHome = new Button
            {
                Text = "Go to Home",
                Size = new Size(100, 20),
                Location = new Point(10, 10),
                Anchor = AnchorStyles.Left
            };
            btnHome.Click += (s, e) => ShowPanel(homePanel);

            //To start repo set up
            Button btnInitialize = new Button
            {
                Text = "Initialize",
                Size = new Size(100, 20),
                Location = new Point(10, 50),
                Anchor = AnchorStyles.Left
            };
            btnInitialize.Click += (s, e) => ShowPanel(settingsPanel);



            Button pickFolderButton = new Button
            {
                Text = "Pick Folder",
                Location = new Point(0, 0),
                Size = new Size(150, 150),
                Anchor = AnchorStyles.Right
                
            };

            settingsPanel.Controls.Add(pickFolderButton);
            
            pickFolderButton.Click += PickFolderButton_Click;


            Controls.Add(btnHome);
            Controls.Add(btnInitialize);
            Controls.Add(homePanel);
            Controls.Add(settingsPanel);


        }



        #region Methods
        private void ShowPanel(Panel target)
        {
            homePanel.Visible = false;
            settingsPanel.Visible = false;

            target.Visible = true;
        }

        private void PickFolderButton_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() => 
            { 


            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to write to";
                folderDialog.UseDescriptionForTitle = true;
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string path = folderDialog.SelectedPath;
                    //selectedPathLabel.Text = "Selected Path: " + path;

                    // Example: write a test file
                    //System.IO.File.WriteAllText(System.IO.Path.Combine(path, "test.txt"), "Hello folder!");
                }
            }
            
            
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            //staThread.Join();

        }
        #endregion
    }
}
