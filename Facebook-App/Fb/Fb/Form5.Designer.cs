using System;
using System.Windows.Forms;
using System.Drawing;

namespace Fb
{
    partial class Form5 : Form
    {
        private TextBox FriendEmail;
        private Button addButton;
        private Button removeButton;
        private ListBox friendsListBox;
        private Button backButton;

        private void InitializeComponent()
        {
            // Form5
            ClientSize = new System.Drawing.Size(800, 540);
            Text = "Friends";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(245, 245, 245);
            StartPosition = FormStartPosition.CenterScreen;

            // Search Label
            Label searchLabel = new Label();
            searchLabel.Text = "Search by Email:";
            searchLabel.Size = new Size(150, 20); 
            searchLabel.Location = new Point(50, 20);
            searchLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            Controls.Add(searchLabel);

            // Search TextBox
            FriendEmail = new TextBox();
            FriendEmail.Size = new Size(300, 30); 
            FriendEmail.Location = new Point(50, 50);
            FriendEmail.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(FriendEmail);

            // Add Button
            addButton = new Button();
            addButton.Size = new Size(80, 30);
            addButton.Location = new Point(360, 50);
            addButton.Text = "Add";
            addButton.BackColor = Color.FromArgb(52, 152, 219);
            addButton.ForeColor = Color.White;
            addButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddButton_Click;
            Controls.Add(addButton);

            // Remove Button
            removeButton = new Button();
            removeButton.Size = new Size(80, 30); // Adjusted size
            removeButton.Location = new Point(450, 50);
            removeButton.Text = "Remove";
            removeButton.BackColor = Color.FromArgb(192, 57, 43);
            removeButton.ForeColor = Color.White;
            removeButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Click += RemoveButton_Click;
            Controls.Add(removeButton);

            // Friends Label
            Label friendsLabel = new Label();
            friendsLabel.Text = "Friends List:";
            friendsLabel.Size = new Size(150, 20); 
            friendsLabel.Location = new Point(50, 100);
            friendsLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            Controls.Add(friendsLabel);

            // Friends ListBox
            friendsListBox = new ListBox();
            friendsListBox.Size = new Size(500, 300); 
            friendsListBox.Location = new Point(50, 130);
            friendsListBox.Font = new Font("Arial", 12, FontStyle.Regular);
            friendsListBox.BackColor = Color.White;
            friendsListBox.BorderStyle = BorderStyle.None;
            friendsListBox.FormattingEnabled = true;
            Controls.Add(friendsListBox);

            // Back Button
            backButton = new Button();
            backButton.Size = new Size(80, 30); 
            backButton.Location = new Point(50, 440);
            backButton.Text = "Back";
            backButton.BackColor = Color.FromArgb(52, 152, 219);
            backButton.ForeColor = Color.White;
            backButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += BackButton_Click;
            Controls.Add(backButton);

        }


    }
}
