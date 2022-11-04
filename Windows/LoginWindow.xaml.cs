using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using PROG6212.Data;
using PROG6212.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG6212.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // This is function is called to create a user in the database.
        private async void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Spinner.IsLoading = true;
            TextBlockResponse.Text = "";
            StudyTrackerContext context = new StudyTrackerContext();

            User user = new User()
            {
                username = TextBoxUsername.Text,
                password = ComputeSha256Hash(TextBoxPassword.Text)
            };

            context.Add(user);

            try
            {
                int response = await context.SaveChangesAsync();
                TextBlockResponse.Text = "Successfully created account" + TextBoxUsername.Text;

            } catch (UniqueConstraintException ex)
            {
                TextBlockResponse.Text = ex.Message;
            }
            Spinner.IsLoading = false;

        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private async void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            Spinner.IsLoading = true;
            TextBlockResponse.Text = "";
            string hashedPassword = ComputeSha256Hash(TextBoxPassword.Text);
            StudyTrackerContext context = new StudyTrackerContext();
            var user = await(context.users.FirstOrDefaultAsync(b => b.username == TextBoxUsername.Text && b.password == hashedPassword));
            
            if(user == null)
            {
                TextBlockResponse.Text = "You have inputted incorrect details!";
            }
            else
            {
                TextBlockResponse.Text = "Success! Welcome " + user.username;
            }
            Spinner.IsLoading = false;
        }
    }
}
