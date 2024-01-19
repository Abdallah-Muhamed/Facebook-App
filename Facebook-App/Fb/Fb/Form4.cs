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
using System.IO;
using static Fb.Form2;
using System.Runtime.CompilerServices;

namespace Fb
{
    public partial class Form4 : Form
    {
        public static User user;
        List<Post> posts = new List<Post>();
        public class Post
        {
            public string AuthorName { get; set; }
            public DateTime Time { get; set; }
            public string Content { get; set; }
            public int Likes { get; set; }
            public int Shares { get; set; }

            public Post(string authorName, DateTime time, string content, int likes, int shares)
            {
                AuthorName = authorName;
                Time = time;
                Content = content;
                Likes = likes;
                Shares = shares;
            }
        }

        public Form4(User me)
        {
            user = me;
            InitializeComponent();
            LoadUserPosts();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
        private void LoadPosts()
        {
            posts.Clear();
            string filePath = Path.Combine("Posts", "user_posts.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 5)
                        {
                            Post newPost = new Post
                                (
                                  parts[0],
                                  DateTime.Parse(parts[1]),
                                  parts[2],
                                  int.Parse(parts[3]),
                                  int.Parse(parts[4])
                                );

                            posts.Add(newPost);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading posts: {ex.Message}");
                }
            }
        }


        private void SavePosts()
        {
            List<string> lines = new List<string>();

            foreach (Post post in posts)
            {
                if (post.Content == string.Empty) continue;
                lines.Add($"{post.AuthorName},{post.Time},{post.Content},{post.Likes},{post.Shares}");
            }

            File.WriteAllLines("Posts\\user_posts.txt", lines);
        }
        private void LoadUserPosts()
        {
            LoadPosts();
            postsContainer.Controls.Clear();

            foreach (Post post in posts.ToList())
            {
                if (post.Content == string.Empty) continue;
                AddPostPanel(postsContainer.Controls.Count, profilePicture, post.AuthorName, post.Content);
            }
        }

        private void update_profilePicture(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newImagePath = openFileDialog.FileName;

                user.ProfilePicturePath = newImagePath;

                try
                {
                    profilePicture.Image = Image.FromFile(newImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            SaveUserData();
        }
        private void update_coverPicture(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newImagePath = openFileDialog.FileName;

                user.CoverPicturePath = newImagePath;

                try
                {
                    coverPicture.Image = Image.FromFile(newImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            SaveUserData();
        }

        private void FriendsShow(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(user);
            form5.Show();
        }
        public void LoadUserData()
        {
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
                if (RegisteredUsers.Count > 0)
                {
                    User lastUser = RegisteredUsers[RegisteredUsers.Count - 1];
                    string line = $"{lastUser.Name},{lastUser.Email},{lastUser.Password},{lastUser.Gender},{lastUser.Birthdate:M/d/yyyy},{lastUser.ProfilePicturePath},{lastUser.CoverPicturePath},{lastUser.RegisterTime:M/d/yyyy},{lastUser.FriendsNum}";

                    File.WriteAllText("Users\\user_data.txt", line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user data: {ex.Message}");
            }
        }

    }
}
