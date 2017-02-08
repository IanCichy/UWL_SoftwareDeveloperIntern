namespace Package_Manager
{
    partial class FrmPackageManager
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
            this.tabControlPackages = new System.Windows.Forms.TabControl();
            this.tabPagePackageInventory = new System.Windows.Forms.TabPage();
            this.btnRefreshPackage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackageSearch = new System.Windows.Forms.TextBox();
            this.DGVpackageInventory = new System.Windows.Forms.DataGridView();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carrierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageDateReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageDeliver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.packageIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveredByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDeliveredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packagesForHallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frontDeskSuiteDataSet1 = new Package_Manager.FrontDeskSuiteDataSet1();
            this.tabPageAddPackage = new System.Windows.Forms.TabPage();
            this.pnlAddNewPackage = new System.Windows.Forms.Panel();
            this.lblPackageCostDollars = new System.Windows.Forms.Label();
            this.numericUpDownCostPackages = new System.Windows.Forms.NumericUpDown();
            this.btnReceivePackage = new System.Windows.Forms.Button();
            this.lblPackageCost = new System.Windows.Forms.Label();
            this.lblSelectStudentPackage = new System.Windows.Forms.Label();
            this.lblPackageDescription = new System.Windows.Forms.Label();
            this.pnlSearchStudentPackage = new System.Windows.Forms.Panel();
            this.lblSearchStudentPackage = new System.Windows.Forms.Label();
            this.textBoxStudentRoomNumberPackage = new System.Windows.Forms.TextBox();
            this.lblStudentLastNamePackage = new System.Windows.Forms.Label();
            this.lblStudentRoomNumberPackage = new System.Windows.Forms.Label();
            this.txtStudentNamePackage = new System.Windows.Forms.TextBox();
            this.textBoxPackageDescription = new System.Windows.Forms.TextBox();
            this.DGVstudentsPackage = new System.Windows.Forms.DataGridView();
            this.packageRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageStudent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.studentsForSearchByHallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frontDeskSuiteDataSet = new Package_Manager.FrontDeskSuiteDataSet();
            this.studentsForSearchByHallTableAdapter = new Package_Manager.FrontDeskSuiteDataSetTableAdapters.StudentsForSearchByHallTableAdapter();
            this.packagesForHallTableAdapter = new Package_Manager.FrontDeskSuiteDataSet1TableAdapters.PackagesForHallTableAdapter();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControlPackages.SuspendLayout();
            this.tabPagePackageInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpackageInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesForHallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontDeskSuiteDataSet1)).BeginInit();
            this.tabPageAddPackage.SuspendLayout();
            this.pnlAddNewPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostPackages)).BeginInit();
            this.pnlSearchStudentPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVstudentsPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsForSearchByHallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontDeskSuiteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPackages
            // 
            this.tabControlPackages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPackages.Controls.Add(this.tabPagePackageInventory);
            this.tabControlPackages.Controls.Add(this.tabPageAddPackage);
            this.tabControlPackages.Location = new System.Drawing.Point(12, 38);
            this.tabControlPackages.Name = "tabControlPackages";
            this.tabControlPackages.SelectedIndex = 0;
            this.tabControlPackages.Size = new System.Drawing.Size(853, 548);
            this.tabControlPackages.TabIndex = 2;
            // 
            // tabPagePackageInventory
            // 
            this.tabPagePackageInventory.Controls.Add(this.btnRefreshPackage);
            this.tabPagePackageInventory.Controls.Add(this.label2);
            this.tabPagePackageInventory.Controls.Add(this.txtPackageSearch);
            this.tabPagePackageInventory.Controls.Add(this.DGVpackageInventory);
            this.tabPagePackageInventory.Location = new System.Drawing.Point(4, 22);
            this.tabPagePackageInventory.Name = "tabPagePackageInventory";
            this.tabPagePackageInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePackageInventory.Size = new System.Drawing.Size(845, 522);
            this.tabPagePackageInventory.TabIndex = 0;
            this.tabPagePackageInventory.Text = "Package Inventory";
            this.tabPagePackageInventory.UseVisualStyleBackColor = true;
            // 
            // btnRefreshPackage
            // 
            this.btnRefreshPackage.Location = new System.Drawing.Point(6, 10);
            this.btnRefreshPackage.Name = "btnRefreshPackage";
            this.btnRefreshPackage.Size = new System.Drawing.Size(75, 25);
            this.btnRefreshPackage.TabIndex = 18;
            this.btnRefreshPackage.Text = "Refresh";
            this.btnRefreshPackage.UseVisualStyleBackColor = true;
            this.btnRefreshPackage.Click += new System.EventHandler(this.btnRefreshPackage_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Student Name";
            // 
            // txtPackageSearch
            // 
            this.txtPackageSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackageSearch.Location = new System.Drawing.Point(673, 15);
            this.txtPackageSearch.Name = "txtPackageSearch";
            this.txtPackageSearch.Size = new System.Drawing.Size(150, 20);
            this.txtPackageSearch.TabIndex = 4;
            this.txtPackageSearch.TextChanged += new System.EventHandler(this.btnSearchStudentPackageDeliver_Click);
            // 
            // DGVpackageInventory
            // 
            this.DGVpackageInventory.AllowUserToAddRows = false;
            this.DGVpackageInventory.AllowUserToDeleteRows = false;
            this.DGVpackageInventory.AllowUserToResizeRows = false;
            this.DGVpackageInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVpackageInventory.AutoGenerateColumns = false;
            this.DGVpackageInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVpackageInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVpackageInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.carrierDataGridViewTextBoxColumn,
            this.studentForDataGridViewTextBoxColumn,
            this.receivedByDataGridViewTextBoxColumn,
            this.packageDateReceived,
            this.packageCost,
            this.packageDeliver,
            this.packageIDDataGridViewTextBoxColumn,
            this.deliveredByDataGridViewTextBoxColumn,
            this.dateDeliveredDataGridViewTextBoxColumn,
            this.hallIDDataGridViewTextBoxColumn});
            this.DGVpackageInventory.DataSource = this.packagesForHallBindingSource;
            this.DGVpackageInventory.Location = new System.Drawing.Point(5, 45);
            this.DGVpackageInventory.Name = "DGVpackageInventory";
            this.DGVpackageInventory.ReadOnly = true;
            this.DGVpackageInventory.RowHeadersVisible = false;
            this.DGVpackageInventory.Size = new System.Drawing.Size(836, 471);
            this.DGVpackageInventory.TabIndex = 0;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // carrierDataGridViewTextBoxColumn
            // 
            this.carrierDataGridViewTextBoxColumn.DataPropertyName = "Carrier";
            this.carrierDataGridViewTextBoxColumn.HeaderText = "Carrier";
            this.carrierDataGridViewTextBoxColumn.Name = "carrierDataGridViewTextBoxColumn";
            this.carrierDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentForDataGridViewTextBoxColumn
            // 
            this.studentForDataGridViewTextBoxColumn.DataPropertyName = "StudentFor";
            this.studentForDataGridViewTextBoxColumn.HeaderText = "StudentFor";
            this.studentForDataGridViewTextBoxColumn.Name = "studentForDataGridViewTextBoxColumn";
            this.studentForDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receivedByDataGridViewTextBoxColumn
            // 
            this.receivedByDataGridViewTextBoxColumn.DataPropertyName = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn.HeaderText = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn.Name = "receivedByDataGridViewTextBoxColumn";
            this.receivedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packageDateReceived
            // 
            this.packageDateReceived.DataPropertyName = "DateReceived";
            this.packageDateReceived.HeaderText = "DateReceived";
            this.packageDateReceived.Name = "packageDateReceived";
            this.packageDateReceived.ReadOnly = true;
            // 
            // packageCost
            // 
            this.packageCost.DataPropertyName = "Cost";
            this.packageCost.HeaderText = "Cost";
            this.packageCost.Name = "packageCost";
            this.packageCost.ReadOnly = true;
            // 
            // packageDeliver
            // 
            this.packageDeliver.HeaderText = "Deliver";
            this.packageDeliver.Name = "packageDeliver";
            this.packageDeliver.ReadOnly = true;
            this.packageDeliver.Visible = false;
            // 
            // packageIDDataGridViewTextBoxColumn
            // 
            this.packageIDDataGridViewTextBoxColumn.DataPropertyName = "PackageID";
            this.packageIDDataGridViewTextBoxColumn.HeaderText = "PackageID";
            this.packageIDDataGridViewTextBoxColumn.Name = "packageIDDataGridViewTextBoxColumn";
            this.packageIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.packageIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // deliveredByDataGridViewTextBoxColumn
            // 
            this.deliveredByDataGridViewTextBoxColumn.DataPropertyName = "DeliveredBy";
            this.deliveredByDataGridViewTextBoxColumn.HeaderText = "DeliveredBy";
            this.deliveredByDataGridViewTextBoxColumn.Name = "deliveredByDataGridViewTextBoxColumn";
            this.deliveredByDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveredByDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDeliveredDataGridViewTextBoxColumn
            // 
            this.dateDeliveredDataGridViewTextBoxColumn.DataPropertyName = "DateDelivered";
            this.dateDeliveredDataGridViewTextBoxColumn.HeaderText = "DateDelivered";
            this.dateDeliveredDataGridViewTextBoxColumn.Name = "dateDeliveredDataGridViewTextBoxColumn";
            this.dateDeliveredDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDeliveredDataGridViewTextBoxColumn.Visible = false;
            // 
            // hallIDDataGridViewTextBoxColumn
            // 
            this.hallIDDataGridViewTextBoxColumn.DataPropertyName = "HallID";
            this.hallIDDataGridViewTextBoxColumn.HeaderText = "HallID";
            this.hallIDDataGridViewTextBoxColumn.Name = "hallIDDataGridViewTextBoxColumn";
            this.hallIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.hallIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // packagesForHallBindingSource
            // 
            this.packagesForHallBindingSource.DataMember = "PackagesForHall";
            this.packagesForHallBindingSource.DataSource = this.frontDeskSuiteDataSet1;
            // 
            // frontDeskSuiteDataSet1
            // 
            this.frontDeskSuiteDataSet1.DataSetName = "FrontDeskSuiteDataSet1";
            this.frontDeskSuiteDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPageAddPackage
            // 
            this.tabPageAddPackage.Controls.Add(this.pnlAddNewPackage);
            this.tabPageAddPackage.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddPackage.Name = "tabPageAddPackage";
            this.tabPageAddPackage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddPackage.Size = new System.Drawing.Size(845, 522);
            this.tabPageAddPackage.TabIndex = 1;
            this.tabPageAddPackage.Text = "Add New Package";
            this.tabPageAddPackage.UseVisualStyleBackColor = true;
            // 
            // pnlAddNewPackage
            // 
            this.pnlAddNewPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlAddNewPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddNewPackage.Controls.Add(this.lblPackageCostDollars);
            this.pnlAddNewPackage.Controls.Add(this.numericUpDownCostPackages);
            this.pnlAddNewPackage.Controls.Add(this.btnReceivePackage);
            this.pnlAddNewPackage.Controls.Add(this.lblPackageCost);
            this.pnlAddNewPackage.Controls.Add(this.lblSelectStudentPackage);
            this.pnlAddNewPackage.Controls.Add(this.lblPackageDescription);
            this.pnlAddNewPackage.Controls.Add(this.pnlSearchStudentPackage);
            this.pnlAddNewPackage.Controls.Add(this.textBoxPackageDescription);
            this.pnlAddNewPackage.Controls.Add(this.DGVstudentsPackage);
            this.pnlAddNewPackage.Location = new System.Drawing.Point(143, 5);
            this.pnlAddNewPackage.Name = "pnlAddNewPackage";
            this.pnlAddNewPackage.Size = new System.Drawing.Size(548, 516);
            this.pnlAddNewPackage.TabIndex = 0;
            // 
            // lblPackageCostDollars
            // 
            this.lblPackageCostDollars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPackageCostDollars.AutoSize = true;
            this.lblPackageCostDollars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageCostDollars.Location = new System.Drawing.Point(200, 462);
            this.lblPackageCostDollars.Name = "lblPackageCostDollars";
            this.lblPackageCostDollars.Size = new System.Drawing.Size(16, 16);
            this.lblPackageCostDollars.TabIndex = 30;
            this.lblPackageCostDollars.Text = "$";
            // 
            // numericUpDownCostPackages
            // 
            this.numericUpDownCostPackages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownCostPackages.DecimalPlaces = 2;
            this.numericUpDownCostPackages.Location = new System.Drawing.Point(221, 460);
            this.numericUpDownCostPackages.Name = "numericUpDownCostPackages";
            this.numericUpDownCostPackages.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownCostPackages.TabIndex = 29;
            // 
            // btnReceivePackage
            // 
            this.btnReceivePackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceivePackage.BackColor = System.Drawing.SystemColors.Control;
            this.btnReceivePackage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReceivePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceivePackage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReceivePackage.Location = new System.Drawing.Point(322, 431);
            this.btnReceivePackage.Name = "btnReceivePackage";
            this.btnReceivePackage.Size = new System.Drawing.Size(94, 49);
            this.btnReceivePackage.TabIndex = 28;
            this.btnReceivePackage.Text = "Add Package";
            this.btnReceivePackage.UseVisualStyleBackColor = false;
            this.btnReceivePackage.Click += new System.EventHandler(this.btnReceivePackage_Click);
            // 
            // lblPackageCost
            // 
            this.lblPackageCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPackageCost.AutoSize = true;
            this.lblPackageCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageCost.Location = new System.Drawing.Point(118, 459);
            this.lblPackageCost.Name = "lblPackageCost";
            this.lblPackageCost.Size = new System.Drawing.Size(39, 16);
            this.lblPackageCost.TabIndex = 27;
            this.lblPackageCost.Text = "Cost";
            // 
            // lblSelectStudentPackage
            // 
            this.lblSelectStudentPackage.AutoSize = true;
            this.lblSelectStudentPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectStudentPackage.Location = new System.Drawing.Point(14, 95);
            this.lblSelectStudentPackage.Name = "lblSelectStudentPackage";
            this.lblSelectStudentPackage.Size = new System.Drawing.Size(108, 16);
            this.lblSelectStudentPackage.TabIndex = 24;
            this.lblSelectStudentPackage.Text = "Select Student";
            // 
            // lblPackageDescription
            // 
            this.lblPackageDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPackageDescription.AutoSize = true;
            this.lblPackageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageDescription.Location = new System.Drawing.Point(118, 400);
            this.lblPackageDescription.Name = "lblPackageDescription";
            this.lblPackageDescription.Size = new System.Drawing.Size(87, 16);
            this.lblPackageDescription.TabIndex = 23;
            this.lblPackageDescription.Text = "Description";
            // 
            // pnlSearchStudentPackage
            // 
            this.pnlSearchStudentPackage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSearchStudentPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchStudentPackage.Controls.Add(this.lblSearchStudentPackage);
            this.pnlSearchStudentPackage.Controls.Add(this.textBoxStudentRoomNumberPackage);
            this.pnlSearchStudentPackage.Controls.Add(this.lblStudentLastNamePackage);
            this.pnlSearchStudentPackage.Controls.Add(this.lblStudentRoomNumberPackage);
            this.pnlSearchStudentPackage.Controls.Add(this.txtStudentNamePackage);
            this.pnlSearchStudentPackage.Location = new System.Drawing.Point(5, 5);
            this.pnlSearchStudentPackage.Name = "pnlSearchStudentPackage";
            this.pnlSearchStudentPackage.Size = new System.Drawing.Size(538, 87);
            this.pnlSearchStudentPackage.TabIndex = 21;
            // 
            // lblSearchStudentPackage
            // 
            this.lblSearchStudentPackage.AutoSize = true;
            this.lblSearchStudentPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchStudentPackage.Location = new System.Drawing.Point(191, 5);
            this.lblSearchStudentPackage.Name = "lblSearchStudentPackage";
            this.lblSearchStudentPackage.Size = new System.Drawing.Size(113, 16);
            this.lblSearchStudentPackage.TabIndex = 12;
            this.lblSearchStudentPackage.Text = "Search Student";
            // 
            // textBoxStudentRoomNumberPackage
            // 
            this.textBoxStudentRoomNumberPackage.Location = new System.Drawing.Point(233, 53);
            this.textBoxStudentRoomNumberPackage.MaxLength = 50;
            this.textBoxStudentRoomNumberPackage.Name = "textBoxStudentRoomNumberPackage";
            this.textBoxStudentRoomNumberPackage.Size = new System.Drawing.Size(199, 20);
            this.textBoxStudentRoomNumberPackage.TabIndex = 18;
            this.textBoxStudentRoomNumberPackage.TextChanged += new System.EventHandler(this.btnSearchStudentPackage_Click);
            // 
            // lblStudentLastNamePackage
            // 
            this.lblStudentLastNamePackage.AutoSize = true;
            this.lblStudentLastNamePackage.Location = new System.Drawing.Point(132, 27);
            this.lblStudentLastNamePackage.Name = "lblStudentLastNamePackage";
            this.lblStudentLastNamePackage.Size = new System.Drawing.Size(35, 13);
            this.lblStudentLastNamePackage.TabIndex = 13;
            this.lblStudentLastNamePackage.Text = "Name";
            // 
            // lblStudentRoomNumberPackage
            // 
            this.lblStudentRoomNumberPackage.AutoSize = true;
            this.lblStudentRoomNumberPackage.Location = new System.Drawing.Point(112, 58);
            this.lblStudentRoomNumberPackage.Name = "lblStudentRoomNumberPackage";
            this.lblStudentRoomNumberPackage.Size = new System.Drawing.Size(75, 13);
            this.lblStudentRoomNumberPackage.TabIndex = 15;
            this.lblStudentRoomNumberPackage.Text = "Room Number";
            // 
            // txtStudentNamePackage
            // 
            this.txtStudentNamePackage.Location = new System.Drawing.Point(233, 27);
            this.txtStudentNamePackage.MaxLength = 50;
            this.txtStudentNamePackage.Name = "txtStudentNamePackage";
            this.txtStudentNamePackage.Size = new System.Drawing.Size(199, 20);
            this.txtStudentNamePackage.TabIndex = 16;
            this.txtStudentNamePackage.TextChanged += new System.EventHandler(this.btnSearchStudentPackage_Click);
            // 
            // textBoxPackageDescription
            // 
            this.textBoxPackageDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPackageDescription.Location = new System.Drawing.Point(221, 400);
            this.textBoxPackageDescription.MaxLength = 100;
            this.textBoxPackageDescription.Name = "textBoxPackageDescription";
            this.textBoxPackageDescription.Size = new System.Drawing.Size(195, 20);
            this.textBoxPackageDescription.TabIndex = 0;
            // 
            // DGVstudentsPackage
            // 
            this.DGVstudentsPackage.AllowUserToAddRows = false;
            this.DGVstudentsPackage.AllowUserToDeleteRows = false;
            this.DGVstudentsPackage.AllowUserToResizeColumns = false;
            this.DGVstudentsPackage.AllowUserToResizeRows = false;
            this.DGVstudentsPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DGVstudentsPackage.AutoGenerateColumns = false;
            this.DGVstudentsPackage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVstudentsPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVstudentsPackage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packageRoom,
            this.packageStudent});
            this.DGVstudentsPackage.DataSource = this.studentsForSearchByHallBindingSource;
            this.DGVstudentsPackage.Location = new System.Drawing.Point(5, 114);
            this.DGVstudentsPackage.Name = "DGVstudentsPackage";
            this.DGVstudentsPackage.RowHeadersVisible = false;
            this.DGVstudentsPackage.Size = new System.Drawing.Size(538, 268);
            this.DGVstudentsPackage.TabIndex = 1;
            this.DGVstudentsPackage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVstudentsPackage_CellValueChanged);
            // 
            // packageRoom
            // 
            this.packageRoom.DataPropertyName = "Room";
            this.packageRoom.HeaderText = "Room";
            this.packageRoom.Name = "packageRoom";
            // 
            // packageStudent
            // 
            this.packageStudent.FalseValue = "false";
            this.packageStudent.HeaderText = "Select";
            this.packageStudent.Name = "packageStudent";
            this.packageStudent.TrueValue = "true";
            // 
            // studentsForSearchByHallBindingSource
            // 
            this.studentsForSearchByHallBindingSource.DataMember = "StudentsForSearchByHall";
            this.studentsForSearchByHallBindingSource.DataSource = this.frontDeskSuiteDataSet;
            // 
            // frontDeskSuiteDataSet
            // 
            this.frontDeskSuiteDataSet.DataSetName = "FrontDeskSuiteDataSet";
            this.frontDeskSuiteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentsForSearchByHallTableAdapter
            // 
            this.studentsForSearchByHallTableAdapter.ClearBeforeFill = true;
            // 
            // packagesForHallTableAdapter
            // 
            this.packagesForHallTableAdapter.ClearBeforeFill = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(16, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(306, 25);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome to Package Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Package_Manager.Properties.Resources.box;
            this.pictureBox1.Location = new System.Drawing.Point(818, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPackageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Package_Manager.Properties.Resources.light_grey_wash_wall;
            this.ClientSize = new System.Drawing.Size(877, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tabControlPackages);
            this.Name = "FrmPackageManager";
            this.Text = "PackageManager";
            this.Load += new System.EventHandler(this.PackageManager_Load);
            this.tabControlPackages.ResumeLayout(false);
            this.tabPagePackageInventory.ResumeLayout(false);
            this.tabPagePackageInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpackageInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesForHallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontDeskSuiteDataSet1)).EndInit();
            this.tabPageAddPackage.ResumeLayout(false);
            this.pnlAddNewPackage.ResumeLayout(false);
            this.pnlAddNewPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostPackages)).EndInit();
            this.pnlSearchStudentPackage.ResumeLayout(false);
            this.pnlSearchStudentPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVstudentsPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsForSearchByHallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontDeskSuiteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPackages;
        private System.Windows.Forms.TabPage tabPagePackageInventory;
        private System.Windows.Forms.Button btnRefreshPackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPackageSearch;
        private System.Windows.Forms.DataGridView DGVpackageInventory;
        private System.Windows.Forms.TabPage tabPageAddPackage;
        private System.Windows.Forms.Panel pnlAddNewPackage;
        private System.Windows.Forms.Label lblPackageCostDollars;
        private System.Windows.Forms.NumericUpDown numericUpDownCostPackages;
        private System.Windows.Forms.Button btnReceivePackage;
        private System.Windows.Forms.Label lblPackageCost;
        private System.Windows.Forms.Label lblSelectStudentPackage;
        private System.Windows.Forms.Label lblPackageDescription;
        private System.Windows.Forms.Panel pnlSearchStudentPackage;
        private System.Windows.Forms.Label lblSearchStudentPackage;
        private System.Windows.Forms.TextBox textBoxStudentRoomNumberPackage;
        private System.Windows.Forms.Label lblStudentLastNamePackage;
        private System.Windows.Forms.Label lblStudentRoomNumberPackage;
        private System.Windows.Forms.TextBox txtStudentNamePackage;
        private System.Windows.Forms.TextBox textBoxPackageDescription;
        private System.Windows.Forms.DataGridView DGVstudentsPackage;
        private System.Windows.Forms.BindingSource studentsForSearchByHallBindingSource;
        private FrontDeskSuiteDataSet frontDeskSuiteDataSet;
        private FrontDeskSuiteDataSetTableAdapters.StudentsForSearchByHallTableAdapter studentsForSearchByHallTableAdapter;
        private System.Windows.Forms.BindingSource packagesForHallBindingSource;
        private FrontDeskSuiteDataSet1 frontDeskSuiteDataSet1;
        private FrontDeskSuiteDataSet1TableAdapters.PackagesForHallTableAdapter packagesForHallTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carrierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageDateReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageCost;
        private System.Windows.Forms.DataGridViewButtonColumn packageDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveredByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDeliveredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hallIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageRoom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn packageStudent;

    }
}