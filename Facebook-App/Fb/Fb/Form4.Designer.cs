using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Fb
{
    partial class Form4 : Form
    {
        private Panel PostPanel;
        private PictureBox userProfilePicture;
        private TextBox postTextBox;
        private Button postButton;
        private Button logoutButton;
        public Panel profilePanel;
        private PictureBox coverPicture;
        private CircularPictureBox profilePicture;
        private Label userNameLabel;
        private Button friendsButton;
        private Button uploadButton;
        private Panel postsContainer;

        private Label name;
        private Label email;
        private Label bio;
        private Label Friends;
        private Label birthday;
        private Label registertime;
        private Label likescounter;
        private Label repostcounter;

        private PictureBox like;
        private PictureBox repost;
        public class CircularPictureBox : PictureBox
        {
            public CircularPictureBox()
            {
                // Set some properties for a circular appearance
                this.BackColor = Color.Transparent;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                    this.Region = new Region(path);
                    base.OnPaint(pe);

                    // Draw a black border
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        pe.Graphics.DrawEllipse(pen, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        private void InitializeComponent()
        {
            // main form
            ClientSize = new Size(1200, 600); 
            Text = "Facebook Page";
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            BackColor = Color.FromArgb(218, 224, 230);
            FormClosing += Form4_FormClosing;

            logoutButton = new Button();
            logoutButton.Text = "Logout ?";
            logoutButton.Size = new Size(200, 50);
            logoutButton.Location = new Point(20, 700);
            logoutButton.BackColor = Color.FromArgb(52, 152, 219);
            logoutButton.ForeColor = Color.White;
            logoutButton.Font = new Font("Arial", 14, FontStyle.Bold);
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Click += logoutButton_Click;
            Controls.Add(logoutButton);

            // Post Panel
            PostPanel = new Panel();
            PostPanel.Size = new Size(800, 80);
            PostPanel.Location = new Point(500, 20);
            PostPanel.BackColor = Color.White;
            Controls.Add(PostPanel);

     
            // Post TextBox in Create Post Panel
            postTextBox = new TextBox();
            postTextBox.Size = new Size(680, 60);
            postTextBox.Location = new Point(10, 10);
            postTextBox.Multiline = true;
            postTextBox.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            PostPanel.Controls.Add(postTextBox);


            // Post Button in Create Post Panel
            postButton = new Button();
            postButton.Text = "Post";
            postButton.Size = new Size(80, 45);
            postButton.Location = new Point(710, 17);
            postButton.BackColor = Color.FromArgb(52, 152, 219);
            postButton.ForeColor = Color.White;
            postButton.Font = new Font("Arial", 14, FontStyle.Bold);
            postButton.FlatStyle = FlatStyle.Flat;
            postButton.Click += PostButton_Click;
            PostPanel.Controls.Add(postButton);



            // Profile Panel
            profilePanel = new Panel();
            profilePanel.Size = new Size(400, 300);
            profilePanel.Location = new Point(20, 20); 
            profilePanel.BackColor = Color.White;
            Controls.Add(profilePanel);


            // Profile Picture
            profilePicture = new CircularPictureBox();
            profilePicture.Size = new System.Drawing.Size(80, 80);
            profilePicture.Location = new System.Drawing.Point(10, 90);
            profilePicture.Cursor = Cursors.Hand;
            profilePicture.Click += update_profilePicture;
            profilePicture.Image = Image.FromFile(user.ProfilePicturePath);    
            profilePanel.Controls.Add(profilePicture);


            // Cover Picture
            coverPicture = new PictureBox();
            coverPicture.Size = new Size(400, 130);
            coverPicture.Location = new Point(0, 0);
            coverPicture.Cursor = Cursors.Hand;
            coverPicture.Click += update_coverPicture;
            coverPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            coverPicture.Image = Image.FromFile(user.CoverPicturePath);
            profilePanel.Controls.Add(coverPicture);

            name = new Label();
            name.Size = new Size(100, 20); 
            name.Text = user.Name;
            name.Font = new Font(name.Font.FontFamily, 12, FontStyle.Bold);
            name.Location = new Point(10, 180);
            profilePanel.Controls.Add(name);

            email = new Label();
            email.Size = new Size(300, 20);
            email.Text = user.Email;
            email.Location = new Point(10, 205);
            email.Font = new Font(email.Font.FontFamily, 10, FontStyle.Regular);
            profilePanel.Controls.Add(email);


            Friends = new Label();
            Friends.Size = new Size(100, 20);
            Friends.Text = $" Your Friends";
            Friends.Font = new Font(Friends.Font.FontFamily, 10, FontStyle.Underline);
            Friends.Location = new Point(10, 230);
            Friends.Cursor = Cursors.Hand;
            Friends.Click += FriendsShow;
            profilePanel.Controls.Add(Friends);


            birthday = new Label();
            birthday.Text = $"Birthday : {user.Birthdate:M/d/yyyy}";
            birthday.Size = new Size(150, 20);
            birthday.Font = new Font(birthday.Font.FontFamily, 10, FontStyle.Regular);
            birthday.Location = new Point(10, 255);
            profilePanel.Controls.Add(birthday);

            registertime = new Label();
            registertime.Text = $"Joined : {user.RegisterTime:M/d/yyyy}";
            registertime.Size = new Size(150, 20);
            registertime.Font = new Font(birthday.Font.FontFamily, 10, FontStyle.Regular);
            registertime.Location = new Point(200, 255);
            profilePanel.Controls.Add(registertime);



            // Posts Container Panel
            postsContainer = new Panel();
            postsContainer.Size = new Size(800, 640); 
            postsContainer.Location = new Point(500, 140);
            postsContainer.BackColor = Color.White;
            postsContainer.AutoScroll = true; 
            Controls.Add(postsContainer);
        }

       

        private void AddPostPanel(int index, CircularPictureBox postAuthorPicture, string authorName, string postText)
        {
            Panel postPanel = new Panel();
            postPanel.Size = new Size(750, 300);
            postPanel.Location = new Point(20, (index * (postPanel.Height + 10)) + 10);
            postPanel.BackColor = Color.White;
            postsContainer.Controls.Add(postPanel);


            CircularPictureBox profpic = new CircularPictureBox();
            profpic.Image = Image.FromFile(@"C:\Users\user\Desktop\Fb\Fb\Fb\bin\Debug\Pictures\profile.jpg");
            profpic.Location = new Point(20, 10);
            profpic.Size = new Size(60, 60);
            postPanel.Controls.Add(profpic);

            Label postAuthorName = new Label();
            postAuthorName.Text = authorName;
            postAuthorName.Size = new Size(150, 30);
            postAuthorName.Location = new Point(90, 15);
            postAuthorName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            postPanel.Controls.Add(postAuthorName);
            
            Label time = new Label();
            time.Text = DateTime.Now.ToString();
            time.Size = new Size(150, 15);
            time.Location = new Point(90, 40);
            time.ForeColor = Color.DarkGray;
            time.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            postPanel.Controls.Add(time);

            TextBox content = new TextBox();
            content.Text = postText;
            content.Size = new Size(650, 100);
            content.ReadOnly = true;
            content.Multiline = true;
            content.BackColor = Color.White;
            content.ScrollBars = ScrollBars.Both;
            content.Location = new Point(20, 100);
            content.Font = new Font("Segoe UI", 15, FontStyle.Regular);
            postPanel.Controls.Add(content);

            // like
            like = new PictureBox();
            like.Size = new Size(30, 30);
            like.Image = Image.FromFile(@"C:\Users\user\Desktop\Fb\Fb\Fb\bin\Debug\Icons\like.png");
            like.Location = new Point(30, 220);
            postPanel.Controls.Add(like);

            // likescounter
            likescounter = new Label();
            likescounter.Text = "12";
            likescounter.Size = new Size(30, 30);
            likescounter.Location = new Point(65, 230);
            likescounter.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            postPanel.Controls.Add(likescounter);

            repost = new PictureBox();
            repost.Size = new Size(30, 30);
            repost.Image = Image.FromFile(@"C:\Users\user\Desktop\Fb\Fb\Fb\bin\Debug\Icons\share.png");
            repost.Location = new Point(110, 220);
            postPanel.Controls.Add(repost);

            // repostcounter
            repostcounter = new Label();
            repostcounter.Text = "15";
            repostcounter.Size = new Size(30, 30);
            repostcounter.Location = new Point(140, 230);
            repostcounter.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            postPanel.Controls.Add(repostcounter);

            Post newPost = new Post(user.Name, DateTime.Now, postTextBox.Text, 0, 0);
            posts.Add(newPost);
            SavePosts();

        }
     
        private void PostButton_Click(object sender, EventArgs e)
        {
            AddPostPanel(postsContainer.Controls.Count ,profilePicture ,user.Name, postTextBox.Text);
            postTextBox.Clear();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
