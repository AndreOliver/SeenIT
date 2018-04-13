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
            bool success = DataConnection.GetUserLogin(UserName_MaskedTextBox.Text, Password_MaskedTextBox.Text);

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
            if (UserName_MaskedTextBox.Text == string.Empty || Password_MaskedTextBox.Text == string.Empty)
            {
                MessageBox.Show("Error! Missing either Username OR Password");
                UserName_MaskedTextBox.ResetText();
                Password_MaskedTextBox.ResetText();

                return;
            }

            bool success = DataConnection.CreateUserLogin(UserName_MaskedTextBox.Text, Password_MaskedTextBox.Text);

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
    }
}
