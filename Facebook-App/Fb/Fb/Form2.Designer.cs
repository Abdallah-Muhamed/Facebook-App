using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fb
{
    partial class Form2 : Form
    {
        private Label Header;
        private Label lblUserName;
        private Label lblEmail;
        private Label lblPass;
        private Label lblGender;
        private Label lblBirthDate;
        private TextBox UserName;
        private TextBox Email;
        private TextBox Pass;
        private ComboBox Gender;
        private DateTimePicker BirthDate;
        private Button Signup;
        private Label LoginLabel;
        private void InitializeComponent()
        {

            // Header 
            Header = new Label();
            Header.Text = "Sign Up";
            Header.Size = new Size(200, 50);
            Header.Location = new Point(300, 30);
            Header.ForeColor = Color.FromArgb(52, 152, 219);
            Header.Font = new Font("Arial", 28, FontStyle.Bold);
            Controls.Add(Header);

            // Label for UserName
            lblUserName = new Label();
            lblUserName.Text = "Username:";
            lblUserName.Size = new Size(100, 30);
            lblUserName.Location = new Point(100, 100);
            lblUserName.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(lblUserName);

            // Label for Email
            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Size = new Size(100, 30);
            lblEmail.Location = new Point(100, 160);
            lblEmail.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(lblEmail);

            // Label for Pass
            lblPass = new Label();
            lblPass.Text = "Password:";
            lblPass.Size = new Size(100, 30);
            lblPass.Location = new Point(100, 220);
            lblPass.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(lblPass);

            // Label for Gender
            lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Size = new Size(100, 30);
            lblGender.Location = new Point(100, 280);
            lblGender.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(lblGender);

            // Label for BirthDate
            lblBirthDate = new Label();
            lblBirthDate.Text = "Birth Date:";
            lblBirthDate.Size = new Size(90, 30);
            lblBirthDate.Location = new Point(370, 285);
            lblBirthDate.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(lblBirthDate);

            // UserName
            UserName = new TextBox();
            UserName.Size = new Size(400, 40);
            UserName.Location = new Point(200, 100);
            UserName.Multiline = true;
            UserName.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(UserName);

            // Email
            Email = new TextBox();
            Email.Size = new Size(400, 40);
            Email.Location = new Point(200, 160);
            Email.Multiline = true;
            Email.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(Email);

            // Pass
            Pass = new TextBox();
            Pass.Size = new Size(400, 40);
            Pass.Location = new Point(200, 220);
            Pass.Multiline = true;
            Pass.Font = new Font("Arial", 12, FontStyle.Regular);
            Pass.PasswordChar = '*';
            Controls.Add(Pass);

            // Gender
            Gender = new ComboBox();
            Gender.Items.AddRange(new object[] { "Male", "Female" });
            Gender.DropDownStyle = ComboBoxStyle.DropDownList;
            Gender.Size = new Size(150, 30);
            Gender.Location = new Point(200, 280);
            Gender.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(Gender);

            // BirthDate
            BirthDate = new DateTimePicker();
            BirthDate.Format = DateTimePickerFormat.Short;
            BirthDate.Size = new Size(140, 30);
            BirthDate.Location = new Point(460, 280);
            BirthDate.Font = new Font("Arial", 12, FontStyle.Regular);
            Controls.Add(BirthDate);

            // Signup button
            Signup = new Button();
            Signup.Size = new Size(300, 50);
            Signup.Location = new Point(250, 350);
            Signup.Text = "Sign up";
            Signup.BackColor = Color.FromArgb(52, 152, 219);
            Signup.ForeColor = Color.White;
            Signup.Font = new Font("Arial", 14, FontStyle.Bold);
            Signup.FlatStyle = FlatStyle.Flat;
            Signup.FlatAppearance.BorderSize = 0;
            Signup.Click += Signup_Click;
            Controls.Add(Signup);

            //Login
            LoginLabel = new Label();
            LoginLabel.Text = "Already have an account ? Log in";
            LoginLabel.Size = new Size(250, 20);
            LoginLabel.Location = new Point(295, 410);
            LoginLabel.ForeColor = Color.FromArgb(44, 62, 80);
            LoginLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            LoginLabel.Cursor = Cursors.Hand;
            LoginLabel.Click += BtnOpenForm2_Click;
            Controls.Add(LoginLabel);

            // Form2
            ClientSize = new System.Drawing.Size(800, 500);
            Text = "Facebook Management System";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            FormClosing += Form1_FormClosing;
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void BtnOpenForm2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
