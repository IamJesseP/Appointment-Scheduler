﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse
{
    public static class UserActivityLogger
    {
        private static string logFilePath = "UserActivityLog.txt";

        public static void LogUserActivity(string userName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - User '{userName}' logged in.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during the file writing process
                MessageBox.Show($"Error logging user activity: {ex.Message}");
            }
        }
    }
}