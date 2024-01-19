using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fb.Form2;
using System.IO;

namespace Fb
{
    public partial class Form5 : Form
    {

        public Form2.User UserInformation { get; set; }

        public Form5(Form2.User userInformation)
        {
            InitializeComponent();
            UserInformation = userInformation;
            LoadUserData();
            LoadFriendshipData(friendships, UserInformation.Email);
            DisplayFriendsInListBox(friendships);

        }

        class Friendship
        {
            public string User1Email { get; }
            public string User2Email { get; }

            public Friendship(string user1Email, string user2Email)
            {
                User1Email = user1Email;
                User2Email = user2Email;
            }
        }

        List<Friendship> friendships = new List<Friendship>();
        List<User> users = new List<User>();

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = FriendEmail.Text.Trim();

            if (!string.IsNullOrEmpty(selectedUserEmail))
            {
                User selectedUser = users.FirstOrDefault(u => u.Email == selectedUserEmail);

                if (selectedUser != null)
                {
                    if (selectedUser.Email == UserInformation.Email)
                    {
                        MessageBox.Show("You cannot add yourself as a friend.");
                    }
                    else
                    {
                        Friendship newFriendship = new Friendship(UserInformation.Email, selectedUser.Email);
                        friendships.Add(newFriendship);
                        SaveFriendshipData(friendships, UserInformation.Email);
                        MessageBox.Show($"Added {selectedUser.Name} as a friend.");
                    }
                }
                else
                {
                    MessageBox.Show($"User with email {selectedUserEmail} not found.");
                }
            }
            DisplayFriendsInListBox(friendships);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = FriendEmail.Text.Trim();

            if (!string.IsNullOrEmpty(selectedUserEmail))
            {
                User selectedUser = users.FirstOrDefault(u => u.Email == selectedUserEmail);

                if (selectedUser != null)
                {
                    Friendship friendshipToRemove = friendships.Find(f =>
                        (f.User1Email == UserInformation.Email && f.User2Email == selectedUser.Email) ||
                        (f.User1Email == selectedUser.Email && f.User2Email == UserInformation.Email));

                    if (friendshipToRemove != null)
                    {
                        friendships.Remove(friendshipToRemove);
                        SaveFriendshipData(friendships, UserInformation.Email); 
                        MessageBox.Show($"Removed {selectedUser.Name} from friends.");
                    }
                    else
                    {
                        MessageBox.Show($"You are not friends with {selectedUser.Name}.");
                    }
                }
                else
                {
                    MessageBox.Show($"User with email {selectedUserEmail} not found.");
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DisplayFriendsInListBox(List<Friendship> friendships)
        {
            friendsListBox.Items.Clear();

            foreach (Friendship friendship in friendships)
            {
                User friendUser = users.FirstOrDefault(u => u.Email == friendship.User2Email);

                if (friendUser != null)
                {
                    friendsListBox.Items.Add($"{friendUser.Name} ({friendUser.Email})");
                }
            }
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

                            users.Add(newUser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading user data: {ex.Message}");
                }
            }
            DisplayFriendsInListBox(friendships);
        }
        private string GetFriendshipFileName(string userEmail)
        {
            return $"Friendships\\{userEmail}_friend_data.txt";
        }

        private void LoadFriendshipData(List<Friendship> friendships, string userEmail)
        {
            string fileName = GetFriendshipFileName(userEmail);

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        friendships.Add(new Friendship(parts[0], parts[1]));
                    }
                }
            }
        }

        private void SaveFriendshipData(List<Friendship> friendships, string userEmail)
        {
            string fileName = GetFriendshipFileName(userEmail);

            List<string> lines = new List<string>();

            foreach (Friendship friendship in friendships)
            {
                lines.Add($"{friendship.User1Email}:{friendship.User2Email}");
            }

            File.WriteAllLines(fileName, lines);
        }
    }
}
