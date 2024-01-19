using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fb;
using System.Security.Cryptography.X509Certificates;

namespace Fb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2.User Me = null;

        private void Login_Click(object sender, EventArgs e)
        {
            bool ok = false;

            foreach (Form2.User user in Form2.RegisteredUsers)
            {
                if ((Email.Text == user.Email) && (Pass.Text == user.Password))
                {
                    Me = user;
                    ok = true;
                    break;
                }
            }

            if (ok)
            {
                Form4 form4 = new Form4(Me);
                form4.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password. Try again.");
            }
        }

      
    }
}
