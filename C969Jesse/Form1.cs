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
using MySql.Data.MySqlClient;

namespace C969Jesse
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Connect_Click(object sender, EventArgs e)
		{
			//get the connection string
			string conStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
			//make connection
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(conStr);
				conn.Open();
				MessageBox.Show("Connection is open");
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
				}
			}
		}
	}
}
