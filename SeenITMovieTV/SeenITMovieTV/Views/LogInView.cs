using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;
using SeenITMovieTV.Database;
using System.Net.Mail;
using System.Net;

namespace SeenITMovieTV.Views
{
    public partial class LogInView : MetroForm
    {
        private SQL_Interaction DataConnection;

        public LogInView()
        {
            InitializeComponent();
            
            DataConnection = SQL_Interaction.GetSQL_Connection;
        }

        private void LogIn_Button_Click(object sender, EventArgs e)
        {
            bool success = DataConnection.GetUserLogin(UserName_MaskedTextBox.Text);

            if (success == true)
            {
                this.Hide();
                mainFormView main = new mainFormView();
                main.Show();
            }
            else
            {
                MessageBox.Show("Error, Username OR Password entered is incorrect.");
                UserName_MaskedTextBox.ResetText();
                Password_MaskedTextBox.ResetText();
            }
        }

        private void Create_Account_Button_Click(object sender, EventArgs e)
        {
            if (UserName_MaskedTextBox.Text == string.Empty || Password_MaskedTextBox.Text == string.Empty || Email_MaskedTextbox.Text == string.Empty)
            {
                MessageBox.Show("Error! Missing either Username OR Password");
                UserName_MaskedTextBox.ResetText();
                Password_MaskedTextBox.ResetText();
                Email_MaskedTextbox.ResetText();

                return;
            }

            bool success = DataConnection.CreateUserLogin(UserName_MaskedTextBox.Text, Password_MaskedTextBox.Text, Email_MaskedTextbox.Text);

            if(success == true)
            {
                MessageBox.Show("Success! New User has been Created and Logged In");
                this.Hide();
                mainFormView main = new mainFormView();
                main.Show();
            }
            else
            {
                MessageBox.Show("Error! Could not create a new user");
            }
        }

        private void LogInView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Forgot_Password_Label_Click(object sender, EventArgs e)
        {
            if(Email_MaskedTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please input your email address to recover your login details");
            }
            else
            {
                List<string> FoundDetails = DataConnection.RetrieveLostDetails(Email_MaskedTextbox.Text);

                if (FoundDetails.Count != 0)
                {
                    var message = new MailMessage("seenitmovieseries@gmail.com", Email_MaskedTextbox.Text);

                    message.Subject = "SeenIT - Login Credentials [Contains Sensitive Data]";

                    message.Body = "Hi, you've recently requested that we email you your login credentials for our application. Please Find below your details: \n\n Username:"+FoundDetails[0]+" \n Password: "+FoundDetails[1]+"\n \n Thankyou.";

                    SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
                    mailer.Credentials = new NetworkCredential("seenitmovieseries@gmail.com", "SeenITAaronMoriarty");
                    mailer.EnableSsl = true;
                    mailer.Send(message);

                    MessageBox.Show("We've sent an email to " + Email_MaskedTextbox.Text + " containing your details");
                }
                else
                {
                    MessageBox.Show("Error: No login details associated with that email have been found");
                }
            }
        }
    }
}
