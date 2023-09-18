namespace C969Jesse
{
    partial class Appointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointment));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CustomerTab = new System.Windows.Forms.ToolStripMenuItem();
            this.AppointmentsTab = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentTypesPerMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultantSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.AddBttn = new System.Windows.Forms.Button();
            this.UpdateBttn = new System.Windows.Forms.Button();
            this.DeleteBttn = new System.Windows.Forms.Button();
            this.ViewReportBttn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.successProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxAppointmentFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterAppointments = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.comboBoxMonths = new System.Windows.Forms.ComboBox();
            this.lblConsultants = new System.Windows.Forms.Label();
            this.comboConsultants = new System.Windows.Forms.ComboBox();
            this.appointmentsPerLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.successProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerTab,
            this.AppointmentsTab,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CustomerTab
            // 
            this.CustomerTab.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CustomerTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CustomerTab.Name = "CustomerTab";
            this.CustomerTab.Size = new System.Drawing.Size(76, 20);
            this.CustomerTab.Text = "Customers";
            this.CustomerTab.Click += new System.EventHandler(this.ClickCustomersTab);
            // 
            // AppointmentsTab
            // 
            this.AppointmentsTab.Name = "AppointmentsTab";
            this.AppointmentsTab.Size = new System.Drawing.Size(95, 20);
            this.AppointmentsTab.Text = "Appointments";
            this.AppointmentsTab.Click += new System.EventHandler(this.ClickAppointmentsTab);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appointmentTypesPerMonthToolStripMenuItem,
            this.appointmentsPerLocationToolStripMenuItem,
            this.consultantSchedulesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // appointmentTypesPerMonthToolStripMenuItem
            // 
            this.appointmentTypesPerMonthToolStripMenuItem.Name = "appointmentTypesPerMonthToolStripMenuItem";
            this.appointmentTypesPerMonthToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.appointmentTypesPerMonthToolStripMenuItem.Text = "Appointment Types Per Month";
            this.appointmentTypesPerMonthToolStripMenuItem.Click += new System.EventHandler(this.AppointmentTypesPerMonthToolStripMenuItem_Click);
            // 
            // consultantSchedulesToolStripMenuItem
            // 
            this.consultantSchedulesToolStripMenuItem.Name = "consultantSchedulesToolStripMenuItem";
            this.consultantSchedulesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.consultantSchedulesToolStripMenuItem.Text = "Consultant Schedules";
            this.consultantSchedulesToolStripMenuItem.Click += new System.EventHandler(this.ConsultantSchedulesToolStripMenuItem_Click);
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToResizeColumns = false;
            this.mainDataGridView.AllowUserToResizeRows = false;
            this.mainDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(45, 48);
            this.mainDataGridView.MultiSelect = false;
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(926, 436);
            this.mainDataGridView.TabIndex = 1;
            this.mainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGridView_CellClick);
            this.mainDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MainDataGridView_DataBindingComplete);
            // 
            // AddBttn
            // 
            this.AddBttn.BackColor = System.Drawing.SystemColors.Control;
            this.AddBttn.Location = new System.Drawing.Point(45, 500);
            this.AddBttn.Name = "AddBttn";
            this.AddBttn.Size = new System.Drawing.Size(104, 39);
            this.AddBttn.TabIndex = 2;
            this.AddBttn.Text = "Add";
            this.AddBttn.UseVisualStyleBackColor = false;
            this.AddBttn.Click += new System.EventHandler(this.AddBttn_Click);
            // 
            // UpdateBttn
            // 
            this.UpdateBttn.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateBttn.Location = new System.Drawing.Point(169, 500);
            this.UpdateBttn.Name = "UpdateBttn";
            this.UpdateBttn.Size = new System.Drawing.Size(104, 39);
            this.UpdateBttn.TabIndex = 3;
            this.UpdateBttn.Text = "Update";
            this.UpdateBttn.UseVisualStyleBackColor = false;
            this.UpdateBttn.Click += new System.EventHandler(this.UpdateBttn_Click);
            // 
            // DeleteBttn
            // 
            this.DeleteBttn.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteBttn.Location = new System.Drawing.Point(297, 500);
            this.DeleteBttn.Name = "DeleteBttn";
            this.DeleteBttn.Size = new System.Drawing.Size(104, 39);
            this.DeleteBttn.TabIndex = 4;
            this.DeleteBttn.Text = "Delete";
            this.DeleteBttn.UseVisualStyleBackColor = false;
            this.DeleteBttn.Click += new System.EventHandler(this.DeleteBttn_Click);
            // 
            // ViewReportBttn
            // 
            this.ViewReportBttn.BackColor = System.Drawing.SystemColors.Control;
            this.ViewReportBttn.Location = new System.Drawing.Point(45, 500);
            this.ViewReportBttn.Name = "ViewReportBttn";
            this.ViewReportBttn.Size = new System.Drawing.Size(104, 39);
            this.ViewReportBttn.TabIndex = 5;
            this.ViewReportBttn.Text = "View Report";
            this.ViewReportBttn.UseVisualStyleBackColor = false;
            this.ViewReportBttn.Click += new System.EventHandler(this.ViewReportBttn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(425, 513);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(0, 13);
            this.feedbackLabel.TabIndex = 7;
            // 
            // successProvider
            // 
            this.successProvider.ContainerControl = this;
            this.successProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("successProvider.Icon")));
            // 
            // comboBoxAppointmentFilter
            // 
            this.comboBoxAppointmentFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppointmentFilter.FormattingEnabled = true;
            this.comboBoxAppointmentFilter.Items.AddRange(new object[] {
            "All",
            "Weekly",
            "Monthly"});
            this.comboBoxAppointmentFilter.Location = new System.Drawing.Point(784, 518);
            this.comboBoxAppointmentFilter.Name = "comboBoxAppointmentFilter";
            this.comboBoxAppointmentFilter.Size = new System.Drawing.Size(187, 21);
            this.comboBoxAppointmentFilter.TabIndex = 9;
            this.comboBoxAppointmentFilter.SelectedIndexChanged += new System.EventHandler(this.AppointmentFilter_SelectedIndexChanged);
            // 
            // lblFilterAppointments
            // 
            this.lblFilterAppointments.AutoSize = true;
            this.lblFilterAppointments.Location = new System.Drawing.Point(822, 500);
            this.lblFilterAppointments.Name = "lblFilterAppointments";
            this.lblFilterAppointments.Size = new System.Drawing.Size(96, 13);
            this.lblFilterAppointments.TabIndex = 10;
            this.lblFilterAppointments.Text = "Filter Appointments";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(854, 500);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 12;
            this.lblMonth.Text = "Month";
            // 
            // comboBoxMonths
            // 
            this.comboBoxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonths.FormattingEnabled = true;
            this.comboBoxMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonths.Location = new System.Drawing.Point(784, 518);
            this.comboBoxMonths.Name = "comboBoxMonths";
            this.comboBoxMonths.Size = new System.Drawing.Size(187, 21);
            this.comboBoxMonths.TabIndex = 11;
            this.comboBoxMonths.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMonths_SelectedIndexChanged);
            // 
            // lblConsultants
            // 
            this.lblConsultants.AutoSize = true;
            this.lblConsultants.Location = new System.Drawing.Point(838, 498);
            this.lblConsultants.Name = "lblConsultants";
            this.lblConsultants.Size = new System.Drawing.Size(57, 13);
            this.lblConsultants.TabIndex = 14;
            this.lblConsultants.Text = "Consultant";
            // 
            // comboConsultants
            // 
            this.comboConsultants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConsultants.FormattingEnabled = true;
            this.comboConsultants.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboConsultants.Location = new System.Drawing.Point(784, 518);
            this.comboConsultants.Name = "comboConsultants";
            this.comboConsultants.Size = new System.Drawing.Size(187, 21);
            this.comboConsultants.TabIndex = 13;
            this.comboConsultants.SelectedIndexChanged += new System.EventHandler(this.ComboConsultants_SelectedIndexChanged);
            // 
            // appointmentsPerLocationToolStripMenuItem
            // 
            this.appointmentsPerLocationToolStripMenuItem.Name = "appointmentsPerLocationToolStripMenuItem";
            this.appointmentsPerLocationToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.appointmentsPerLocationToolStripMenuItem.Text = "Appointments Per Location";
            this.appointmentsPerLocationToolStripMenuItem.Click += new System.EventHandler(this.AppointmentsPerLocationToolStripMenuItem_Click);
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 567);
            this.Controls.Add(this.lblConsultants);
            this.Controls.Add(this.comboConsultants);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.comboBoxMonths);
            this.Controls.Add(this.lblFilterAppointments);
            this.Controls.Add(this.comboBoxAppointmentFilter);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.ViewReportBttn);
            this.Controls.Add(this.DeleteBttn);
            this.Controls.Add(this.UpdateBttn);
            this.Controls.Add(this.AddBttn);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Appointment";
            this.Text = "Scheduler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.successProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CustomerTab;
        private System.Windows.Forms.ToolStripMenuItem AppointmentsTab;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ToolStripMenuItem appointmentTypesPerMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultantSchedulesToolStripMenuItem;
        private System.Windows.Forms.Button AddBttn;
        private System.Windows.Forms.Button UpdateBttn;
        private System.Windows.Forms.Button DeleteBttn;
        private System.Windows.Forms.Button ViewReportBttn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.ErrorProvider successProvider;
        private System.Windows.Forms.ComboBox comboBoxAppointmentFilter;
        private System.Windows.Forms.Label lblFilterAppointments;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox comboBoxMonths;
        private System.Windows.Forms.Label lblConsultants;
        private System.Windows.Forms.ComboBox comboConsultants;
        private System.Windows.Forms.ToolStripMenuItem appointmentsPerLocationToolStripMenuItem;
    }
}