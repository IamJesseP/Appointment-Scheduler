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
using C969Jesse.Controller;
using C969Jesse.Database;
using C969Jesse.Utils;
using MySql.Data.MySqlClient;


namespace C969Jesse
{
	public partial class Login : Form
	{
        LoginController loginController = new LoginController();
        AppointmentController appointmentController = new AppointmentController();
		public Login()
        {
            InitializeComponent();

            CheckLabelLanguages();

            CheckIfDbIsNew();
        }

        #region Event Handlers

        private void BtnLogin_Click(object sender, EventArgs e)
		{
			try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                string username = txtUserLogin.Text;
                string password = txtUserPassword.Text;
                var loginAttempt = loginController.TryLogin(conn, username, password);
                if(loginAttempt)
                {
                    // Requirement H: Check for appointments within 15mins
                    appointmentController.CheckUpcomingAppointment();
                    this.Hide();
                }
            }
            catch (MySqlException)
			{
				MessageBox.Show("Server connection error");
			}
            finally
            {
                DbConnection.CloseConnection();
            }
		}

        private void BtnExit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

        #endregion

        #region Helper Methods

        private void CheckIfDbIsNew()
        {
            bool isDbNew = DbConnection.InitializeDatabase();
            if (isDbNew)
            {
                dbProvider.SetError(dbLabel, "!");
                dbLabel.Text = "Database initialized";
            }
            else
            {
                dbProvider.SetError(dbLabel, "!");
                dbLabel.Text = "Database connected";
            }
        }
        private void CheckLabelLanguages()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                lblLogin.Text = "Username";
                lblPassword.Text = "Password";
                btnExit.Text = "Exit";
                btnLogin.Text = "Login";
                this.Text = "Log In";
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
            {
                lblLogin.Text = "Nombre de usuario";
                lblPassword.Text = "Contraseña";
                btnExit.Text = "Salida";
                btnLogin.Text = "Acceso";
                this.Text = "Acceso";
                
            }
        }

        #endregion
    }
}
