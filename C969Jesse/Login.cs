using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969Jesse.Database;
using MySql.Data.MySqlClient;

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
				MessageBox.Show("Login succcessful!");
			}
			else
			{
				MessageBox.Show("Invalid username or password");			
			}


		}
	}
}
