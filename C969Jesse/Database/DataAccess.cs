﻿using C969Jesse.Database;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using System;
using System.Data.Common;


namespace C969Jesse.Database
{
    public class DataAccess
    {
        public DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                DBConnection.StartConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

            return dataTable;
        }
    }
}