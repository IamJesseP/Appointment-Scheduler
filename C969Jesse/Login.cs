using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969Jesse.Database;
using MySql.Data.MySqlClient;

// TODO: ADD LOGING FILES, CODE ALERTS WITHIN 15MINS OF APPT,


namespace C969Jesse
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		private void userLogin_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				var conn = new MySqlConnection();
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
				conn.Open();

				string username = txtUserLogin.Text;
				string password = txtUserPassword.Text;
				string query = $"SELECT * FROM user WHERE userName='{username}' AND password='{password}'";
				var command = new MySqlCommand(query, conn);
				var reader = command.ExecuteReader();
				if (reader.HasRows)
                {
                    LoginSuccessful();
                }
                else
                {
                    LoginFail();
                }
            }
			catch (MySqlException)
			{
				MessageBox.Show("Server connection error");
			}


		}

        private static void LoginFail()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                MessageBox.Show("Username or Password is incorrect");
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
            {
                MessageBox.Show("El nombre de usuario o la contrasena son incorrectos");
            }
        }

        private static void LoginSuccessful()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                MessageBox.Show("Login successful!");
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
            {
                MessageBox.Show("Inicio de sesion con exito");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}
