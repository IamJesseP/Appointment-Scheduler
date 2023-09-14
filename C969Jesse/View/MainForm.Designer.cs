namespace C969Jesse
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.ViewBttn = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.successProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.successProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerTab,
            this.AppointmentsTab,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1260, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CustomerTab
            // 
            this.CustomerTab.BackColor = System.Drawing.SystemColors.Control;
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
            // 
            // consultantSchedulesToolStripMenuItem
            // 
            this.consultantSchedulesToolStripMenuItem.Name = "consultantSchedulesToolStripMenuItem";
            this.consultantSchedulesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.consultantSchedulesToolStripMenuItem.Text = "Consultant Schedules";
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToResizeColumns = false;
            this.mainDataGridView.AllowUserToResizeRows = false;
            this.mainDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(45, 44);
            this.mainDataGridView.MultiSelect = false;
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(926, 436);
            this.mainDataGridView.TabIndex = 1;
            this.mainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellClick);
            this.mainDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainDataGridView_DataBindingComplete);
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
            // ViewBttn
            // 
            this.ViewBttn.BackColor = System.Drawing.SystemColors.Control;
            this.ViewBttn.Location = new System.Drawing.Point(867, 500);
            this.ViewBttn.Name = "ViewBttn";
            this.ViewBttn.Size = new System.Drawing.Size(104, 39);
            this.ViewBttn.TabIndex = 5;
            this.ViewBttn.Text = "View Report";
            this.ViewBttn.UseVisualStyleBackColor = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(1015, 44);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 567);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.ViewBttn);
            this.Controls.Add(this.DeleteBttn);
            this.Controls.Add(this.UpdateBttn);
            this.Controls.Add(this.AddBttn);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
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
        private System.Windows.Forms.Button ViewBttn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.ErrorProvider successProvider;
    }
}