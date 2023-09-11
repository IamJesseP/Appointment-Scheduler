using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969Jesse.Database;

namespace C969Jesse
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				DBConnection.StartConnection();
				MessageBox.Show("Connection open");
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
			}

            Application.Run(new Login());
			DBConnection.CloseConnection();
		}
	}
}
