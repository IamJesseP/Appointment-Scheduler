using C969Jesse.Controller;
using C969Jesse.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Components
{
    public partial class AddAppointmentForm : Form
    {
        private DbManager dbManager = new DbManager();
        private AppointmentController appointmentController = new AppointmentController();

        public AddAppointmentForm()
        {
            InitializeComponent();
            var customers = dbManager.GetCustomerNames();

            comboBoxCustomers.DataSource = new BindingSource(customers, null);
            comboBoxCustomers.DisplayMember = "Value";
            comboBoxCustomers.ValueMember = "Key";

            var users = dbManager.GetUserNames();

            comboBoxUsers.DataSource = new BindingSource(users, null);
            comboBoxUsers.DisplayMember = "Value";
            comboBoxUsers.ValueMember = "Key";

            DateTime selectedDate = dateTimePicker1.Value;
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);

            startTimeComboBox.DataSource = availableSlots;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void startTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

