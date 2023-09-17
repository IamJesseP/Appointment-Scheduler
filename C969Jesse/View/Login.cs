﻿using System;
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
		}

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
    }
}
