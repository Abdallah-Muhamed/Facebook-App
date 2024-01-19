using System;
using System.Windows.Forms;
using System.Drawing;
namespace Fb
{
    partial class Form1
    {
        private Label Header;
        private TextBox Email;
        private TextBox Pass;
        private Button Login;
        private Label Signup;
        private void InitializeComponent()
        {
            //Header
            Header = new Label();
            Header.Text = "Log in";
            Header.Size = new Size(165, 70);
            Header.Location = new Point(325, 50);
            Header.ForeColor = Color.FromArgb(52, 152, 219);
            Header.Font = new Font("Arial", 28, FontStyle.Bold);
            Controls.Add(Header);

            //Email
            Email = new TextBox();
            Email.Size = new Size(400, 40);
            Email.Location = new Point(200, 150);
            Email.Multiline = true;
            Email.Enter += Email_Enter;
            Email.Leave += Email_Leave;
            Controls.Add(Email);

            //Pass
            Pass = new TextBox();
            Pass.Size = new Size(400, 40);
            Pass.Location = new Point(200, 210);
            Pass.Multiline = true;
            Pass.Enter += Pass_Enter;
            Pass.Leave += Pass_Leave;
            Controls.Add(Pass);

            //Login
            Login = new Button();
            Login.Size = new Size(300, 50);
            Login.Location = new Point(250, 290);
            Login.Text = "Login";
            Login.BackColor = Color.FromArgb(52, 152, 219);
            Login.ForeColor = Color.White;
            Login.Font = new Font("Arial", 14, FontStyle.Bold);
            Login.FlatStyle = FlatStyle.Flat;
            Login.FlatAppearance.BorderSize = 0;
            Login.Click += Login_Click;
            Controls.Add(Login);

            //Signup
            Signup = new Label();
            Signup.Text = "Don't have an account ? Sign up";
            Signup.Size = new Size(250, 20);
            Signup.Location = new Point(295, 350); 
            Signup.ForeColor = Color.FromArgb(44, 62, 80); 
            Signup.Font = new Font("Arial", 10, FontStyle.Regular);
            Signup.Cursor = Cursors.Hand;
            Signup.Click += BtnOpenForm2_Click;
            Controls.Add(Signup);

            //Form1
            ClientSize = new System.Drawing.Size(800, 500);
            Text = "Facebook Management System";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            StartPosition = FormStartPosition.CenterScreen;



        }

        // Event handler for the Email Placeholder 
        private void Email_Enter(object sender, EventArgs e)
        {
            if (Email.Text == "Enter your email")
            {
                Email.Text = "";
                Email.ForeColor = Color.Black;
                Email.Font = new Font("Arial", 12, FontStyle.Regular);
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                Email.Text = "Enter your email";
                Email.ForeColor = Color.Gray;
                Email.Font = new Font("Arial", 12, FontStyle.Italic);
            }

        }

        // Event handler for the Password Placeholder 
        private void Pass_Enter(object sender, EventArgs e)
        {
            if (Pass.Text == "Enter your password")
            {
                Pass.Text = "";
                Pass.ForeColor = Color.Black;
                Pass.Font = new Font("Arial", 12, FontStyle.Regular);
            }
            Pass.PasswordChar = '*';

        }

        private void Pass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Pass.Text))
            {
                Pass.Text = "Enter your password";
                Pass.ForeColor = Color.Gray;
                Pass.Font = new Font("Arial", 12, FontStyle.Italic);
                Pass.PasswordChar = '\0';
            }
        }
        private void BtnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Email_Leave(Email, EventArgs.Empty);
            Pass_Leave(Pass, EventArgs.Empty);

            ActiveControl = Header;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

