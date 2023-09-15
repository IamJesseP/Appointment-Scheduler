using C969Jesse.Database;
using C969Jesse.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Controller
{
    public class LoginController
    {
        public bool TryLogin(MySqlConnection conn, string username, string password)
        {
            MySqlDataReader reader;
            using (var loginCMD = new MySqlCommand(Queries.GetLoggedinUserQuery, conn))
            {
                loginCMD.Parameters.AddWithValue("@username", username);
                loginCMD.Parameters.AddWithValue("@password", password);
                reader = loginCMD.ExecuteReader();
            }
            if (reader.HasRows)
            {
                LoginSuccessful();
                UserActivityLogger.LogUserActivity(username); // Logging user info
                UserSession.CurrentUserName = username; // Setting username for data logging
                MainForm mainForm = new MainForm();
                mainForm.Show();
                return true;
            }
            else
            {
                LoginFail();
                return false;
            }
        }
        private void LoginFail()
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
        private void LoginSuccessful()
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
    }
}
