using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Fb.Form4;
using static Fb.Form2;
using System.Net.NetworkInformation;

namespace Fb
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadUserData();
        }
        public static List<User> RegisteredUsers { get; } = new List<User>();

        public class User
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string Gender { get; set; }
            public DateTime Birthdate { get; set; }
            public DateTime RegisterTime { get; set; }

            public string CoverPicturePath { get; set; }
            public string ProfilePicturePath { get; set; }
            public string Bio { get; set; }
            public int FriendsNum { get; set; }

            public User()
            {
                Name = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
                Gender = string.Empty;
                Bio = string.Empty;
                FriendsNum = 0;
                Birthdate = DateTime.MinValue;
                ProfilePicturePath = "C:\\Users\\user\\Desktop\\Fb\\Fb\\Fb\\bin\\Debug\\Pictures\\profile.jpg"; 
                CoverPicturePath = "C:\\Users\\user\\Desktop\\Fb\\Fb\\Fb\\bin\\Debug\\Pictures\\cover.jpg";
                RegisterTime = DateTime.MinValue;
            }
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Name = UserName.Text,
                Email = Email.Text,
                Password = Pass.Text,
                Gender = Gender.Text,
                Birthdate = BirthDate.Value,
                RegisterTime = DateTime.Now
            };
            if (string.IsNullOrEmpty(UserName.Text))
            {
                MessageBox.Show("Please enter your name");
                return; 
            }

            else if (string.IsNullOrEmpty(Email.Text))
            {
                MessageBox.Show("Please enter your email");
                return; 
            }
            else if (string.IsNullOrEmpty(Pass.Text))
            {
                MessageBox.Show("Please enter your Password");
                return;
            }
            else if (string.IsNullOrEmpty(Gender.Text))
            {
                MessageBox.Show("Please enter your Gender");
                return;
            }
            else if (IsEmailAlreadyRegistered(Email.Text))
            {
                MessageBox.Show("Email already registered. Please choose a different email.");
                return;
            }
          
                RegisteredUsers.Add(newUser);
                SaveUserData();
                MessageBox.Show("Registration Successful!");
                Form1 form1 = new Form1();
                form1.Show();
                Hide();
        }
        private bool IsEmailAlreadyRegistered(string emailToCheck)
        {
            foreach (User user in RegisteredUsers)
            {
                if (user.Email == emailToCheck)
                {
                    return true;
                }
            }

            return false;
        }

        public void LoadUserData()
        {
            RegisteredUsers.Clear();
            if (File.Exists("Users\\user_data.txt"))
            {
                try
                {
                    string[] lines = File.ReadAllLines("Users\\user_data.txt");

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 9)
                        {
                            User newUser = new User
                            {
                                Name = parts[0],
                                Email = parts[1],
                                Password = parts[2],
                                Gender = parts[3],
                                Birthdate = DateTime.Parse(parts[4]),
                                ProfilePicturePath = parts[5],
                                CoverPicturePath = parts[6],
                                RegisterTime = DateTime.Parse(parts[7]),
                                FriendsNum = int.Parse(parts[8])
                            };

                            RegisteredUsers.Add(newUser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading user data: {ex.Message}");
                }
            }
        }

        public void SaveUserData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("Users\\user_data.txt"))
                {
                    foreach (User user in RegisteredUsers)
                    {
                        string line = $"{user.Name},{user.Email},{user.Password},{user.Gender},{user.Birthdate},{user.ProfilePicturePath},{user.CoverPicturePath},{user.RegisterTime},{user.FriendsNum}";
                        writer.WriteLine(line);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user data: {ex.Message}");
            }
        }





    }
}
