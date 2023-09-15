using C969Jesse.Controller;
using C969Jesse.Database;
using C969Jesse.Model;
using C969Jesse.Model.Enums;
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
    public partial class AppointmentForm : Form
    {
        private DbManager dbManager = new DbManager();

        private AppointmentController appointmentController = new AppointmentController();

        public MainForm MainFormInstance { get; set; }

        private bool isUpdate = true;

        private string appointmentId;
        public AppointmentForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            // Requirement F: Using combobox picker and dbManager to prevent
            // invalid customer and user data
            var customers = dbManager.GetCustomerNames();
            var users = dbManager.GetUserNames();
            comboBoxCustomers.DataSource = new BindingSource(customers, null);
            comboBoxUsers.DataSource = new BindingSource(users, null);
            comboBoxCustomers.DisplayMember = "Value";
            comboBoxCustomers.ValueMember = "Key";
            comboBoxUsers.DisplayMember = "Value";
            comboBoxUsers.ValueMember = "Key";

            // Requirement F: Using combobox picker and appointmentController that
            // filters only available appointment times and 9-5pm business hours
            DateTime selectedDate = dateTimePicker1.Value;
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);
            
            comboBoxAppointmentTime.DataSource = availableSlots;
            comboBoxLocations.DataSource = Enum.GetNames(typeof(Locations));
            comboBoxVisitTypes.DataSource = Enum.GetNames(typeof(VisitTypes));
        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            string selectedTimeStr = comboBoxAppointmentTime.SelectedValue.ToString();
       

            var appointmentData = new Dictionary<string, string>
            {
                { "CustomerId", ((KeyValuePair<int, string>)comboBoxCustomers.SelectedItem).Key.ToString() },
                { "UserId", ((KeyValuePair<int, string>)comboBoxUsers.SelectedItem).Key.ToString() },
                { "CustomerName", comboBoxCustomers.Text },
                { "ConsultantName", comboBoxUsers.Text },
                { "Description", txtDescription.Text },
                { "Location", comboBoxLocations.Text },
                { "VisitType", comboBoxVisitTypes.Text },
                { "AppointmentId", appointmentId }
            };
            var startEndTime = appointmentController.ConvertStringToDateTime(selectedDate, selectedTimeStr);

            if (MainFormInstance.isUpdate)
            {
                dbManager.SaveAppointment(appointmentData, startEndTime, MainFormInstance.isUpdate);
            }
            else
            {
                dbManager.SaveAppointment(appointmentData, startEndTime, MainFormInstance.isUpdate);
            }
            MainFormInstance?.RefreshTable("Appointments");
            MainFormInstance?.RefreshTableSettings();
            MainFormInstance?.GiveUserFeedBack(MainFormInstance.isUpdate);
            this.Hide();
        }

        public void PopulateFields(DataGridViewRow row)
        {
            // Bug: users original appointment does not show due to getbookedslots logic
            var customerKeyValuePair = new KeyValuePair<int, string>
            (
            Convert.ToInt32(row.Cells[1].Value),
            row.Cells[10].Value.ToString()
            );

            var userKeyValuePair = new KeyValuePair<int, string>
            (
                Convert.ToInt32(row.Cells[2].Value),
                row.Cells[9].Value.ToString()
            );

            comboBoxCustomers.SelectedItem = customerKeyValuePair;
            comboBoxUsers.SelectedItem = userKeyValuePair;
            txtDescription.Text = row.Cells[3].Value.ToString();
            comboBoxLocations.Text = row.Cells[4].Value.ToString();
            comboBoxVisitTypes.Text = row.Cells[5].Value.ToString();
            comboBoxAppointmentTime.Text = row.Cells[8].Value.ToString();
            
            
            DateTime appointmentDate = Convert.ToDateTime(row.Cells[8].Value);
            dateTimePicker1.Value = appointmentDate;

    
            appointmentId = row.Cells[0].Value.ToString();
        }

        public void UpdateAppointmentFormTitle(bool isUpdate)
        {
            appointmentFormTitle.Text = isUpdate ? "Update Appointment" : "Add Appointment";
            lblAppointmentTime.Text = isUpdate ? "NEW Appointment Time" : "Appointment Time";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);
            comboBoxAppointmentTime.DataSource = availableSlots;
           
        }
    }
}

