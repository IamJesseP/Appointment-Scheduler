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

// TODO: ADD LOGING FILES, CODE ALERTS WITHIN 15MINS OF APPT,


namespace C969Jesse
{
	public partial class Login : Form
	{
        LoginController loginController = new LoginController();
		public Login()
		{
			InitializeComponent();
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                string username = txtUserLogin.Text;
                string password = txtUserPassword.Text;
                loginController.TryLogin(conn, username, password);
                this.Hide();
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
    }
}
