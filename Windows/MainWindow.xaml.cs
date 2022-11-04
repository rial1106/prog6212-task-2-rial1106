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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6212
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            StudyTrackerContext context = new StudyTrackerContext();

            User rial = new User()
            {
                username = "st100s83422@vcconnect.edu.za",
                password = ComputeSha256Hash("Rial1106")
            };

            context.Add(rial);
            context.SaveChanges();
            //Semester.StartDate = DatePickerStartDate.SelectedDate;

            ModuleListWindow win = new ModuleListWindow();
            win.Show();
            this.Close();
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (System.Security.Cryptography.SHA256 sha256Hash = SHA256.Create())
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
    }
}
