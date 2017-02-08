﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FDM3
{
    public partial class Main : Form
    {
        #region GlobalVaraibles

        //Numerical user ID (###) For Current Shift
        private String UserID;

        //Typical user (8.4) For Current Shift
        private String NetID;

        //HallID For Current Shift
        private int HallID;

        //OldHallID For Current Shift
        private int OldHallID;

        //HallName For Current Shift
        private String HallName;

        //ID For Current Shift
        private int ShiftID;

        //Is DC
        private Boolean isDC;

        //New Form to cashin/out
        private CashIn_Out CashIn_Out;

        //New Form to pizzaOptions
        private PizzaSellOptions PizzaOptions;

        //TotalCash for DcWithdraw
        private Decimal TotalCash;

        //DefaultCellStyle for DGV highlighted row
        public DataGridViewCellStyle HighlightCellStyle = new DataGridViewCellStyle();

        //DefaultCellStyle for DGV normal row
        public DataGridViewCellStyle DefCellStyle = new DataGridViewCellStyle();

        #endregion GlobalVaraibles

        #region StartupMethods

        public Main(String ID)
        {
            UserID = ID;
            NetID = FDS.Employee.GetNetID(UserID);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (UserID != null)
            {
                try
                {
                    //Gets the HostName of the computer for authorized usertable
                    //Loads corresponding fields that are tied to the host name
                    String HostName = System.Net.Dns.GetHostName().ToLower();
                    HallID = FDS.Employee.GetHallByComputerName(HostName);
                    HallID = 7; //For Testing to force a specific Hall
                    OldHallID = FDS.Employee.GetOldHallID_FromNew(HallID);
                    HallName = (FDS.Hall.GetHallById(HallID)).Name;
                    this.Text = "Front Desk Suite: " + NetID;
                }
                catch (Exception)
                {
                    Close();
                }

                try
                {
                    //Checks to see if the worker is a DC of any hall
                    isDC = FDS.Employee.getIfDC(int.Parse(UserID), HallID);
                }
                catch (Exception)
                {
                }

                //loads MOTD for the hall and the hall name into the correct fields
                lblWelcome.Text = "Welcome to the Front Desk for " + HallName + " Hall!";
                txtCurrentMessage.Text = FDS.Options.GetMessage(HallID);
                //Start new Shift
                ShiftID = FDS.Shift.StartShift(HallID, int.Parse(UserID));
            }
            else
            {
                Close();
            }

            //REMOVES the minimize,maximize,and exit buttons from the upper right of the window
            this.ControlBox = false;

            //If a DC is logged in initalize extra fields, else remove options page from view
            if (isDC)
            {
                TotalCash = 0;
            }
            else
            {
                tabCntrlFrontDesk.TabPages.RemoveAt(6);
            }

            #region DataGridView Setup

            //Populate Gridviews With data from stored procedures/ Datatables
            RefreshGridViews_All();

            //Format Cells of Gridview to [Currency = c, Date = d]
            this.DGVpizzaInventory.Columns["pizzaPrice"].DefaultCellStyle.Format = "c";
            this.DGVproductsInventory.Columns["productPrice"].DefaultCellStyle.Format = "c";
            this.DGVpackageInventory.Columns["packageCost"].DefaultCellStyle.Format = "c";
            this.DGVcurrentShiftSales.Columns["CurrentSalesCost"].DefaultCellStyle.Format = "c";
            this.DGVpackageInventory.Columns["packageDateReceived"].DefaultCellStyle.Format = "d";

            //Sort Gridviews For default starting sort direction, still allows users to change stort
            DGVDVDInventory.Sort(DGVDVDInventory.Columns[1], (System.ComponentModel.ListSortDirection.Ascending));

            //Add listeners to Gridviews with multiple buttons to specify the correct method for each button
            DGVproductsInventory.CellClick += new DataGridViewCellEventHandler(this.btnAddProductToInventory_Click);
            DGVproductsInventory.CellClick += new DataGridViewCellEventHandler(this.btnSellProduct_Click);
            DGVpizzaInventory.CellClick += new DataGridViewCellEventHandler(this.btnAddPizzaToInventory_Click);
            DGVpizzaInventory.CellClick += new DataGridViewCellEventHandler(this.btnSellPizza_Click);

            //Add listener to Package Gridview as it acts differently than the rest
            DGVstudentsPackage.CellClick += new DataGridViewCellEventHandler(this.packageRoom_Click);
            //Add listener to Gridviews with row highlighting ability
            //Pizza
            DGVpizzaInventory.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            //Products
            DGVproductsInventory.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            //Packages
            DGVpackageInventory.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            //Equipment
            DGVcheckInEquipment.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVequipmentInventory.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVStudentsCheckOutEquipment.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVequipmentList.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVequipmentCheckOut.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            //DVD
            DGVDVDInventory.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVDVDcheckOut.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVDVDcheckIn.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVStudentsCheckOutDVD.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);
            DGVAvailableDVD.CellClick += new DataGridViewCellEventHandler(this.Gridview_Click);

            //Sets up Default and Highlight Cell Styles for use with all Gridviews
            HighlightCellStyle.BackColor = SystemColors.Highlight;
            DefCellStyle.BackColor = Color.White;

            #endregion DataGridView Setup

            //Disables the ability to interact with the pizza/product pages until CASH IN has been completed
            tabCntrlFrontDesk.TabPages[2].Enabled = false;
            tabCntrlFrontDesk.TabPages[3].Enabled = false;
            tabCntrlFrontDesk.TabPages[2].BackColor = Color.IndianRed;
            tabCntrlFrontDesk.TabPages[3].BackColor = Color.IndianRed;

            //When DVD CHECKOUT IS CLOSED
            // tabControlDVD.TabPages[1].Enabled = false;
            // tabControlDVD.TabPages[1].BackColor = Color.IndianRed;
            // tabControlDVD.TabPages[2].Enabled = false;
            // tabControlDVD.TabPages[2].BackColor = Color.IndianRed;
        }

        #endregion StartupMethods

        #region Start_EndShiftMethods

        /**
         *
         * Initalizes the cash in/out form for counting drawer money and pizza totals
         * Passes full access to the main form and disables/enables pages as necessary
         *
         */

        /*
        * Starts the cash in process
        * opens the cash in/out window and loads the correct cash and pizza values
        */

        private void btnCashIn_Click(object sender, EventArgs e)
        {
            //lblStartCashInWarning.Visible = false;
            //lblEndCashOutWarning.Visible = true;
            btnCashOut.BackColor = Color.Salmon;
            btnCashOut.Visible = true;
            btnCashIn.Visible = false;
            btnCashIn.Enabled = false;
            btnCashOut.Enabled = false;

            if (CashIn_Out == null || CashIn_Out.IsDisposed)
            {
                CashIn_Out = new CashIn_Out(ShiftID, HallID, this);
                CashIn_Out.Show();
            }
        }

        /*
         * Starts the cash out process and disables selling abilities
         * opens the cash in/out window and loads the correct cash and pizza values
         */

        private void btnCashOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cash out, count pizzas, and end your shift? This will disable the ability to sell pizzas or products while you cash out.",
                "End Shift?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tabCntrlFrontDesk.TabPages[2].Enabled = false;
                tabCntrlFrontDesk.TabPages[3].Enabled = false;
                tabCntrlFrontDesk.TabPages[2].BackColor = Color.Salmon;
                tabCntrlFrontDesk.TabPages[3].BackColor = Color.Salmon;
                btnCashOut.Enabled = false;
                CashIn_Out.CashIn_Out_RefreshPizza();
                CashIn_Out.lblCreditValue.Text = lblValueCredits.Text.ToString();
                CashIn_Out.Show();
            }
        }

        //Method used during TESTING

        private void onExitMain(object sender, FormClosingEventArgs e)
        {
            // Application.Exit();
        }

        #endregion Start_EndShiftMethods

        #region EquipmentTabMethods

        /*
         *   Searches for EQUIPMENT in the database based on the given parameters and HallID
         *      Pre:Name
         *      Post:Any records with matching like '%pre%' parameters
         */

        private void btnSearchEquipment_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = DGVequipmentCheckOut.DataSource;
            String search = textBoxSearchEquipment.Text.Replace("[", "").Replace("]", "");
            bs.Filter = "Name like '%" + search + "%' OR Category like '%" + search + "%'";
        }

        /*
         *   Searches for STUDENTS in the database based on the given parameters and HallID
         *      Pre:FirstName, LastName, RoomNumber
         *      Post:Any records with matching like '%pre%' parameters
         */

        private void btnSearchStudentEquipment_Click(object sender, EventArgs e)
        {
            String Name = txtStudentNameEquipment.Text.ToString();
            String rNum = textBoxStudentRoomNumberEquipment.Text.ToString();
            if (Name.Equals("") && rNum.Equals(""))
            {
                this.studentsForSearchTableAdapter.Fill(this.frontDeskSuiteDataSet1.StudentsForSearch, HallID, Name, "-1");
            }
            else
            {
                this.studentsForSearchTableAdapter.Fill(this.frontDeskSuiteDataSet1.StudentsForSearch, HallID, Name, rNum);
            }
        }

        /*
         *  Ensures only one student is selected at a time for check out/in of Equipment
         *      Pre:-
         *      Post:single selected row
         */

        private void DGVStudentsCheckOutEquipment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DGVStudentsCheckOutEquipment.Rows)
            {
                if (row.Cells["EquipmentSelectedStudent"].Value != null && row.Cells["EquipmentSelectedStudent"].Value.Equals("true"))
                {
                    row.Cells["EquipmentSelectedStudent"].Value = false;
                }
            }
        }

        //Adds Equipment item to the selected queue
        private void btnSelectEquipment_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVequipmentCheckOut.Columns["btnSelectEquipment"].Index && e.RowIndex >= 0)
            {
                int equipID = int.Parse(DGVequipmentCheckOut.Rows[e.RowIndex].Cells["EquipmentIDOut"].Value.ToString());
                FDS.Equipment.SelectItem(equipID);
                RefreshGridViews_Equipment_Selecting();
            }
        }

        //Removes Equipment item from the selected queue
        private void btnUnSelectEquipment_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVequipmentList.Columns["SelectedEquipmentUnSelect"].Index && e.RowIndex >= 0)
            {
                int equipID = int.Parse(DGVequipmentList.Rows[e.RowIndex].Cells["SelectedEquipmentID"].Value.ToString());
                FDS.Equipment.UnselectItem(equipID);
                RefreshGridViews_Equipment_Selecting();
            }
        }

        /*
         *  Checks out 1-M equipment to a SINGLE STUDENT and also updates the History of the equipment checked out
         *      Pre: Selected equipment(1-M), Selected Student(1)
         *      Post: Equipment is checked out and visable in Checked out table
         */

        private void btnCheckOutEquip_Click(object sender, EventArgs e)
        {
            String StudentFor = "";
            //Get The Selected Student from the DGV - only 1 row possible
            foreach (DataGridViewRow row in DGVStudentsCheckOutEquipment.Rows)
            {
                if (row.Cells["EquipmentSelectedStudent"].Value != null && row.Cells["EquipmentSelectedStudent"].Value.Equals("true"))
                {
                    StudentFor = row.Cells["equipmentStudentID"].Value.ToString();
                }
            }
            //Check To make Sure there is a student selected and there is equipment selected
            if (StudentFor.Equals("") || DGVequipmentList.Rows.Count < 1)
            {
                MessageBox.Show("Please Select A Student And Equipment To Check Out!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (DataGridViewRow row in DGVequipmentList.Rows)
                {
                    int equipID = int.Parse(row.Cells["SelectedEquipmentID"].Value.ToString());
                    String equipName = row.Cells["SelectedEquipmentName"].Value.ToString();
                    String Condition = row.Cells["SelectedEquipmentCondition"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are You Sure You Want To Check Out The Following Eqipment:\n\tEquipment: " + equipName +
                        "\n\tStudent: " + StudentFor,
                           "Equipment Check In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //checks out an equipment item to the student with the stats CHECKED OUT
                        FDS.Equipment.CheckOut(equipID, HallID, 2, StudentFor, Condition, NetID);
                    }
                    else
                    {
                        return;
                    }
                }
                txtStudentNameEquipment.Text = "";
                textBoxStudentRoomNumberEquipment.Text = "";
                btnSearchStudentEquipment_Click(this, e);
                RefreshGridViews_Equipment();
            }
        }

        /*
         *  Checks in  1 equipment item from a SINGLE STUDENT and also updates the History of the equipment checked out
         *      Pre: Selected equipment(1), Selected Student(1)
         *      Post: Equipment is checked back in and available again
         */

        private void btnCheckInEquipment_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVcheckInEquipment.Columns["btnCheckInEquipment"].Index && e.RowIndex >= 0)
            {
                String equipName = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentNameIn"].Value.ToString();
                String ConditionIn = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentConditionIn"].Value.ToString();
                String ConditionOut = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentConditionOutReturn"].Value.ToString();
                String StudentFrom = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentStudentIDOut"].Value.ToString();

                if (ConditionIn.Equals(""))
                {
                    DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentConditionIn"].Value = ConditionOut;
                    ConditionIn = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentConditionIn"].Value.ToString();
                }
                if (ConditionIn.Equals("damaged"))
                {
                    DialogResult dmg = MessageBox.Show("The Equipment Being Checked In Is Damaged.\nIs This Correct?",
                        "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dmg == DialogResult.Yes)
                    {
                        //Sends email to HD, AHD, DC about damaged equipment
                        FDS.Equipment.DamagedEquipmentEmail(HallName, equipName, ConditionIn, ConditionOut, StudentFrom, NetID);
                    }
                    else
                    {
                        return;
                    }
                }
                DialogResult result = MessageBox.Show("Are You Sure You Want To Check In The Following Eqipment:\n\tEquipment: " +
                    equipName + "\n\tStudent: " + StudentFrom + "\n\tCondition Out: " + ConditionOut + "\n\tCondition In: " + ConditionIn,
                           "Equipment Check In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    String equipID = DGVcheckInEquipment.Rows[e.RowIndex].Cells["EquipmentIDIn"].Value.ToString();
                    FDS.Equipment.CheckIn(int.Parse(equipID), 1, ConditionIn, NetID);
                    RefreshGridViews_Equipment();
                }
            }
        }

        /*
         *  Displays the History for a SINGLE Equipment item in a gridview
         *      Pre: Selected equipment(1)
         *      Post: All rental entries are displayed
         */

        private void btnEquipmentHistory_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVequipmentInventory.Columns["btnEquipmentHistory"].Index && e.RowIndex >= 0)
            {
                int EqipmentID = int.Parse(DGVequipmentInventory.Rows[e.RowIndex].Cells["EquipmentIDHistory"].Value.ToString());
                this.equipmentHistoryTableAdapter.Fill(this.frontDeskSuiteDataSet9.EquipmentHistory, EqipmentID);
                //Sort Gridview by Date (newest to oldest)
                DGVEquipmentHistoryItem.Sort(DGVEquipmentHistoryItem.Columns[3], (System.ComponentModel.ListSortDirection.Descending));
            }
        }

        #endregion EquipmentTabMethods

        #region PizzaTabMethods

        /*
         * Adds Pizza to inventory based on multiple checks and records additions to inventory in DC Web
         */

        private void btnAddPizzaToInventory_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DGVpizzaInventory.Columns["AddPizzaToInventory"].Index && e.RowIndex >= 0)
                {
                    String pizzaName = DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaName"].Value.ToString();
                    String pizzaBrand = DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaBrand"].Value.ToString();
                    int pizzaID = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["PizzaID"].Value.ToString());
                    //int pizzaInventory = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaInventory"].Value.ToString()); //old method
                    int pizzaInventory = FDS.Pizza.getPizzaInventory(pizzaID);

                    if (DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaAmount"].Value != null)
                    {
                        int amount = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaAmount"].Value.ToString());
                        if (amount <= 0)
                        {
                            MessageBox.Show("Please enter an amount greater than zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        DialogResult result = MessageBox.Show("Are you sure you want to add:\t\n\tQuantity: " +
                            amount + "\n\tBrand: " + pizzaBrand + "\n\tType: " + pizzaName + "\n\tCurrent Inventory: " + pizzaInventory,
                                  "Add Product To Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                        if (result == DialogResult.Yes)
                        {
                            FDS.Pizza.PizzaAdd(pizzaInventory + amount, pizzaID, amount, int.Parse(UserID), "Front Desk Worker: " + NetID, ShiftID);
                            RefreshGridViews_Pizza();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter an amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /*
         * Sells pizza(s) based on multiple checks and records all sales in DC Web
         */

        private void btnSellPizza_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DGVpizzaInventory.Columns["SellPizza"].Index && e.RowIndex >= 0)
                {
                    String pizzaName = DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaName"].Value.ToString();
                    String pizzaBrand = DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaBrand"].Value.ToString();
                    int pizzaID = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["PizzaID"].Value.ToString());
                    // int pizzaInventory = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaInventory"].Value.ToString()); //old method
                    int pizzaInventory = FDS.Pizza.getPizzaInventory(pizzaID);

                    decimal pizzaPrice = decimal.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaPrice"].Value.ToString().TrimStart('$'));

                    if (DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaAmount"].Value != null)
                    {
                        int amount = int.Parse(DGVpizzaInventory.Rows[e.RowIndex].Cells["pizzaAmount"].Value.ToString());

                        if (amount <= 0)
                        {
                            MessageBox.Show("Please enter an amount greater than zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (pizzaInventory >= amount)
                        {
                            PizzaOptions = new PizzaSellOptions(ShiftID, int.Parse(UserID), pizzaBrand, pizzaName,
                                pizzaID, pizzaInventory, amount, pizzaPrice, this);
                            PizzaOptions.Show();
                        }
                        else
                        {
                            MessageBox.Show("Amount entered: " + amount +
                                " is greater than then current inventory of: " + pizzaInventory, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RefreshGridViews_Pizza();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter an amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion PizzaTabMethods

        #region ProductTabMethods

        /*
         * Method to add a product to inventory
         */

        private void btnAddProductToInventory_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVproductsInventory.Columns["AddProductToInventory"].Index && e.RowIndex >= 0)
            {
                String prodName = DGVproductsInventory.Rows[e.RowIndex].Cells["productName"].Value.ToString();
                int prodID = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["productID"].Value.ToString());
                //int prodInventory = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["productInventory"].Value.ToString());
                int prodInventory = FDS.Product.getProductInventory(prodID);

                if (DGVproductsInventory.Rows[e.RowIndex].Cells["ProductAmount"].Value != null)
                {
                    int amount = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["ProductAmount"].Value.ToString());

                    if (amount <= 0)
                    {
                        MessageBox.Show("Please enter an amount greater than zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Are you sure you want to add:\t\n\tQuantity: " +
                        amount + "\n\tType: " + prodName + "\n\tCurrent Inventory: " + prodInventory,
                              "Add Product To Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        FDS.Product.ProductAdd(prodInventory + amount, prodID, amount, int.Parse(UserID), "Front Desk Worker: " + NetID, ShiftID);
                        RefreshGridViews_Product();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        /*
         * Method to Sell A Product
         * pre: Selected row
         * post:  Gets all relevant information from the selected row in the GV and checks amount against inventory.
         * Sells the product and refreshes the relevant GV's
         */

        private void btnSellProduct_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVproductsInventory.Columns["SellProduct"].Index && e.RowIndex >= 0)
            {
                String prodName = DGVproductsInventory.Rows[e.RowIndex].Cells["productName"].Value.ToString();
                int prodID = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["productID"].Value.ToString());
                //int prodInventory = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["productInventory"].Value.ToString());
                int prodInventory = FDS.Product.getProductInventory(prodID);
                decimal prodPrice = decimal.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["productPrice"].Value.ToString().TrimStart('$'));

                if (DGVproductsInventory.Rows[e.RowIndex].Cells["ProductAmount"].Value != null)
                {
                    int amount = int.Parse(DGVproductsInventory.Rows[e.RowIndex].Cells["ProductAmount"].Value.ToString());
                    int isCredit = 0;
                    decimal cost = amount * prodPrice;

                    if (amount <= 0)
                    {
                        MessageBox.Show("Please enter an amount greater than zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (prodInventory >= amount)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to sell:\t\n\tQuantity: " +
                            amount + "\n\tType: " + prodName + "\n\tCurrent Inventory: " + prodInventory,
                            "Sell Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            FDS.Product.ProductSell(prodInventory - amount, prodID, ShiftID, int.Parse(UserID), isCredit, amount, cost);
                            RefreshGridViews_Product();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Amount entered: " + amount +
                            " is greater than then current inventory of: " + prodInventory, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshGridViews_Product();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        #endregion ProductTabMethods

        #region PackageTabMethods

        /*
        *   Searches for students in the database based on the given parameters and HallID
        *      Pre:Name
        *      Post:Any records with matching like '%pre%' parameters
        */

        private void btnSearchStudentPackageDeliver_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = DGVpackageInventory.DataSource;
            String search = txtPackageSearch.Text.Replace("[", "").Replace("]", "");
            bs.Filter = "StudentFor like '%" + search + "%' OR StudentFor like '%" + search + "%'";
        }

        /*
         *   Searches for equipment in the database based on the given parameters
         *      Pre:FirstName, LastName, RoomNumber
         *      Post:Any records with matching like '%pre%' parameters
         */

        private void btnSearchStudentPackage_Click(object sender, EventArgs e)
        {
            String Name = txtStudentNamePackage.Text.ToString();
            String rNum = textBoxStudentRoomNumberPackage.Text.ToString();
            if (Name.Equals("") && rNum.Equals(""))
            {
                this.studentsForSearchByHallTableAdapter.Fill(this.frontDeskSuiteDataSet21.StudentsForSearchByHall, HallID, "%%", "");
            }
            else
            {
                this.studentsForSearchByHallTableAdapter.Fill(this.frontDeskSuiteDataSet21.StudentsForSearchByHall, HallID, Name, rNum);
            }
        }

        /*
        * Method that manages group/normal package mode with number of selections (many/one)
        * and colors row accordingly if they are selected
        *
        */

        private void packageRoom_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ChkGroupPackage.Checked == false)
                {
                    if (e.ColumnIndex == DGVstudentsPackage.Columns["packageStudent"].Index && e.RowIndex >= 0)
                    {
                        foreach (DataGridViewRow row in DGVstudentsPackage.Rows)
                        {
                            DGVstudentsPackage.Rows[row.Index].Cells["packageStudent"].Value = "false";
                            DGVstudentsPackage.Rows[row.Index].DefaultCellStyle = DefCellStyle;
                        }
                        DGVstudentsPackage.Rows[e.RowIndex].Cells["packageStudent"].Value = "true";
                        DGVstudentsPackage.Rows[e.RowIndex].DefaultCellStyle = HighlightCellStyle;
                        DGVstudentsPackage.EndEdit();
                    }
                }
                else
                {
                    if (e.ColumnIndex == DGVstudentsPackage.Columns["packageStudent"].Index && e.RowIndex >= 0)
                    {
                        if (DGVstudentsPackage.Rows[e.RowIndex].Cells["packageStudent"].Value.Equals("true"))
                        {
                            DGVstudentsPackage.Rows[e.RowIndex].Cells["packageStudent"].Value = "false";
                            DGVstudentsPackage.Rows[e.RowIndex].DefaultCellStyle = DefCellStyle;
                        }
                        else
                        {
                            DGVstudentsPackage.Rows[e.RowIndex].Cells["packageStudent"].Value = "true";
                            DGVstudentsPackage.Rows[e.RowIndex].DefaultCellStyle = HighlightCellStyle;
                            DGVstudentsPackage.EndEdit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /*
         * Toggles between group/non-group packages and changes the needed controls
         */

        private void ChkGroupPackage_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkGroupPackage.Checked == true)
            {
                txtStudentNamePackage.Enabled = false;
                textBoxStudentRoomNumberPackage.Enabled = false;
            }
            else
            {
                txtStudentNamePackage.Enabled = true;
                textBoxStudentRoomNumberPackage.Enabled = true;
                this.studentsForSearchByHallTableAdapter.Fill(this.frontDeskSuiteDataSet21.StudentsForSearchByHall, HallID, "%%", "");
            }
        }

        /*
         * Method to receive packages
         *  Records timestamp, emplyoee, student
         */

        private void btnReceivePackage_Click(object sender, EventArgs e)
        {
            if (ChkGroupPackage.Checked == false)
            {
                foreach (DataGridViewRow row in DGVstudentsPackage.Rows)
                {
                    if (row.Cells["packageStudent"].Value != null && row.Cells["packageStudent"].Value.Equals("true"))
                    {
                        String StudentFor = row.Cells["PackageStudentID"].Value.ToString();
                        String Description = textBoxPackageDescription.Text.ToString();
                        decimal Cost = numericUpDownCostPackages.Value;

                        if (Cost < 0)
                        {
                            MessageBox.Show("Please enter a cost greater than or equal to zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (textBoxPackageDescription.Text.ToString().Equals(""))
                        {
                            MessageBox.Show("Please enter a description for this package.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DialogResult result = MessageBox.Show("Are You Sure You Want To Receive This Package?\n\n\tDescription: \"" + Description +
                            "\"\n\tFor: " + StudentFor + "\n\tCost: " + Cost,
                                "Receive Package", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            FDS.Package.ReceivePackage(HallID, StudentFor, Description, Cost, NetID);
                            FDS.Package.ReceivePackageEmail(StudentFor, HallName, Cost);

                            txtStudentNamePackage.Text = "";
                            textBoxStudentRoomNumberPackage.Text = "";
                            textBoxPackageDescription.Text = "";
                            numericUpDownCostPackages.Value = 0;
                            btnSearchStudentPackage_Click(this, e);
                            RefreshGridViews_Package();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                MessageBox.Show("Please Select A Student!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow row in DGVstudentsPackage.Rows)
                {
                    if (row.Cells["packageStudent"].Value != null && row.Cells["packageStudent"].Value.Equals("true"))
                    {
                        String StudentFor = row.Cells["PackageStudentID"].Value.ToString();
                        String Description = textBoxPackageDescription.Text.ToString();
                        decimal Cost = numericUpDownCostPackages.Value;

                        if (Cost < 0)
                        {
                            MessageBox.Show("Please enter a cost greater than or equal to zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (textBoxPackageDescription.Text.ToString().Equals(""))
                        {
                            MessageBox.Show("Please enter a description for this package.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DialogResult result = MessageBox.Show("Are You Sure You Want To Receive This Package?\n\n\tDescription: \"" + Description +
                            "\"\n\tFor: " + StudentFor + "\n\tCost: " + Cost,
                                "Receive Package", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            FDS.Package.ReceivePackage(HallID, StudentFor, Description, Cost, NetID);
                            FDS.Package.ReceivePackageEmail(StudentFor, HallName, Cost);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                txtStudentNamePackage.Text = "";
                textBoxStudentRoomNumberPackage.Text = "";
                textBoxPackageDescription.Text = "";
                numericUpDownCostPackages.Value = 0;
                btnSearchStudentPackage_Click(this, e);
                RefreshGridViews_Package();
                return;
            }
        }

        /*
         *Method to deliver packages to students when picked up
         * Records employee and timestamp
         */

        private void btnDeliverPackage_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVpackageInventory.Columns["packageDeliver"].Index && e.RowIndex >= 0)
            {
                String StudentFor = DGVpackageInventory.Rows[e.RowIndex].Cells["packageStudentFor"].Value.ToString();
                String Description = DGVpackageInventory.Rows[e.RowIndex].Cells["packageDescription"].Value.ToString();
                decimal Cost = decimal.Parse(DGVpackageInventory.Rows[e.RowIndex].Cells["packageCost"].Value.ToString());

                DialogResult result = MessageBox.Show("Are You Sure You Want To Deliver This Package?\n\n\tDescription: \"" + Description +
                    "\"\n\tFor: " + StudentFor + "\n\tCost: " + Cost,
                            "Package Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && Cost == 0)
                {
                    String packageID = DGVpackageInventory.Rows[e.RowIndex].Cells["PackageID"].Value.ToString();
                    FDS.Package.DeliverPackage(int.Parse(packageID), NetID);
                    RefreshGridViews_Package();
                }
                else if (result == DialogResult.Yes && Cost > 0)
                {
                    DialogResult payment = MessageBox.Show("This Package Has Additional Cost Associated With It Which Must Be Provided Now.\n\tCost: " + Cost,
                           "Package Payment", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (payment == DialogResult.OK)
                    {
                        String packageID = DGVpackageInventory.Rows[e.RowIndex].Cells["PackageID"].Value.ToString();
                        FDS.Package.DeliverPackage(int.Parse(packageID), NetID);
                        RefreshGridViews_Package();
                    }
                }
            }
        }

        #endregion PackageTabMethods

        #region DVDTabMethods

        /*Inventory Tab
         *   Searches for DVD in the database based on the given parameters and HallID
         *      Pre:Name
         *      Post:Any records with matching like '%pre%' parameters
         */

        private void btnSearchDvd_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = DGVDVDInventory.DataSource;
            String search = textBoxSearchDvd.Text.Replace("[", "").Replace("]", "");
            bs.Filter = "Title like '%" + search + "%'";
        }

        /*Inventory Tab
        * Opens the IMDB link in an internet browser for the selected DVD as entered from DVDCheckout
        */

        private void btnDvdIMDB_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVDVDInventory.Columns["IMDBButton"].Index && e.RowIndex >= 0)
            {
                try
                {
                    String IMDB = DGVDVDInventory.Rows[e.RowIndex].Cells["IMDB"].Value.ToString();
                    System.Diagnostics.Process.Start(IMDB);
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show("There is no IMDB link available for this DVD.",
                        "DVD IMDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region FD-DVD-Checkout

        /*FD Checkout Tab
         *   Searches for DVD in the database based on the given parameters and HallID
         *      Pre:Name
         *      Post:Any records with matching like '%pre%' parameters
         */

        private void btnSearchFDDvd_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = DGVAvailableDVD.DataSource;
            String search = textBoxSearchFDDvd.Text.Replace("[", "").Replace("]", "");
            bs.Filter = "Title like '%" + search + "%'";
        }

        /*FD Checkout Tab
        *   Searches for STUDENTS in the database based on the given parameters and HallID
        *      Pre:FirstName, LastName, RoomNumber
        *      Post:Any records with matching like '%pre%' parameters
        */

        private void btnSearchStudentDVD_Click(object sender, EventArgs e)
        {
            String Name = txtStudentNameDVD.Text.ToString();
            if (Name.Equals(""))
            {
                this.studentsForSearchTableAdapter2.Fill(this.frontDeskSuiteDataSet18.StudentsForSearch, HallID, Name, "-1");
            }
            else
            {
                this.studentsForSearchTableAdapter2.Fill(this.frontDeskSuiteDataSet18.StudentsForSearch, HallID, Name, "");
            }
        }

        /*FD Checkout Tab
         *  Ensures only one student is selected at a time for check out/in of DVD's
         *      Pre:-
         *      Post:single selected row
         */

        private void DGVStudentsCheckOutDVD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DGVStudentsCheckOutDVD.Rows)
            {
                if (row.Cells["DGVDVDStudentsSelect"].Value != null && row.Cells["DGVDVDStudentsSelect"].Value.Equals("true"))
                {
                    row.Cells["DGVDVDStudentsSelect"].Value = false;
                }
            }
        }

        /*FD Checkout Tab
        *  Ensures only one DVD is selected at a time for check out/in of DVD's
        *      Pre:-
        *      Post:single selected row
        */

        private void DGVAvailableDVD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DGVAvailableDVD.Rows)
            {
                if (row.Cells["DGVAvailableDVDSelect"].Value != null && row.Cells["DGVAvailableDVDSelect"].Value.Equals("true"))
                {
                    row.Cells["DGVAvailableDVDSelect"].Value = false;
                }
            }
        }

        /*FD Checkout Tab
        *  Checks out a single dvd to a single student and creates an entry for them in the DVD database
        *  if they have never checked out a DVD before
        *      Pre:Student and Dvd Selected
        *      Post:DVD checked out to that Student
        */

        private void btnFDDVDCheckOut_Click(object sender, EventArgs e)
        {
            String StudentFor = "";
            String DVDLocID = "";
            String DVDTitle = "";
            String DVDID = "";
            //Get The Selected Student from the DGV - only 1 row possible
            foreach (DataGridViewRow row in DGVStudentsCheckOutDVD.Rows)
            {
                if (row.Cells["DGVDVDStudentsSelect"].Value != null && row.Cells["DGVDVDStudentsSelect"].Value.Equals("true"))
                {
                    StudentFor = row.Cells["DGVDVDStudentsNetID"].Value.ToString();
                }
            }
            //Get The Selected DVD from the DGV - only 1 row possible
            foreach (DataGridViewRow row in DGVAvailableDVD.Rows)
            {
                if (row.Cells["DGVAvailableDVDSelect"].Value != null && row.Cells["DGVAvailableDVDSelect"].Value.Equals("true"))
                {
                    DVDLocID = row.Cells["DGVAvailableDVDLocID"].Value.ToString();
                    DVDID = row.Cells["DGVAvailableDVDID"].Value.ToString();
                    DVDTitle = row.Cells["DGVAvailableDVDTitle"].Value.ToString();
                }
            }

            //Check To make Sure there is a student selected and there is a DVD selected
            if (StudentFor.Equals("") || DVDLocID.Equals(""))
            {
                MessageBox.Show("Please Select A Student And A DVD To Check Out!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Check Out The Following DVD:\n\tDVD: " + DVDTitle +
                    "\n\tStudent: " + StudentFor,
                       "DVD Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    /*
                     * puts the DVD into the reserved table like in the webversion
                     * and adds the user into the table if they do not exist already
                     * Then checks out the DVD and updates the location and reservation
                     * tables accordingly
                     */
                    FDS.Shift.ReserveCheckOutDvd(DVDLocID, StudentFor, DVDID, NetID);

                    txtStudentNameDVD.Text = "";
                    textBoxSearchFDDvd.Text = "";
                    btnSearchStudentDVD_Click(this, e);
                    btnSearchFDDvd_Click(this, e);
                    RefreshGridViews_DVD();
                }
                else
                {
                    return;
                }
            }
        }

        #endregion FD-DVD-Checkout

        /*Web Checkout Tab
         *  Checks out the selected DVD
         *      pre: Selected DVD
         *      post: Puts the DVD into the checked out table
         */

        private void btnDvdCheckOut_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVDVDcheckOut.Columns["btnCheckOutDVD"].Index && e.RowIndex >= 0)
            {
                String LocID = DGVDVDcheckOut.Rows[e.RowIndex].Cells["DVDCheckOutLocID"].Value.ToString();
                DateTime ResTime = DateTime.Parse(DGVDVDcheckOut.Rows[e.RowIndex].Cells["DVDCheckOutResTime"].Value.ToString());
                String Title = DGVDVDcheckOut.Rows[e.RowIndex].Cells["DVDCheckOutTitle"].Value.ToString();
                String DvdNet = DGVDVDcheckOut.Rows[e.RowIndex].Cells["DVDCheckOutNetID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to check out " + Title + "\nto " + DvdNet,
                            "DVD Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FDS.Shift.CheckOutDvd(LocID, ResTime, NetID);
                    RefreshGridViews_DVD();
                }
            }
        }

        /*Web CheckIn Tab
         *  Checks in the selected DVD
         *      pre: Selected DVD
         *      post: Puts the DVD back into the available DVD listing
         */

        private void btnDvdCheckIn_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVDVDcheckIn.Columns["btnCheckInDVD"].Index && e.RowIndex >= 0)
            {
                String LocID = DGVDVDcheckIn.Rows[e.RowIndex].Cells["DVDCheckInLocID"].Value.ToString();
                DateTime CheckOutTime = DateTime.Parse(DGVDVDcheckIn.Rows[e.RowIndex].Cells["DVDCheckInOutTime"].Value.ToString());
                String Comment = DGVDVDcheckIn.Rows[e.RowIndex].Cells["DVDCheckInRetComment"].Value.ToString();

                String Title = DGVDVDcheckIn.Rows[e.RowIndex].Cells["DVDCheckInTitle"].Value.ToString();
                String DvdNet = DGVDVDcheckIn.Rows[e.RowIndex].Cells["DVDCheckInNetID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to check in " + Title + "\nfrom " + DvdNet,
                            "DVD Check In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FDS.Shift.CheckInDvd(LocID, CheckOutTime, Comment, NetID);
                    RefreshGridViews_DVD();
                }
            }
        }

        #endregion DVDTabMethods

        #region GridViewRefresh_UtilityMethods

        /*
        *Highlights the currently editing row in the gridview to make it easier to see
        */

        private void Gridview_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView DGV = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        DGV.Rows[row.Index].DefaultCellStyle = DefCellStyle;
                    }
                    DGV.Rows[e.RowIndex].DefaultCellStyle = HighlightCellStyle;
                }
            }
            catch (Exception)
            {
            }
        }

        /**
         * Methods to referesh Gridview Data. Contain the correct refreshed for each indiviual page.
         *
         */

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshGridViews_All();
        }

        public void RefreshGridViews_All()
        {
            //MAIN
            this.salesForShiftTableAdapter.Fill(this.frontDeskSuiteDataSet10.SalesForShift, ShiftID);
            this.inventoryChangesForShiftTableAdapter.Fill(this.frontDeskSuiteDataSet11.InventoryChangesForShift, ShiftID);
            //PIZZA
            this.pizzasForHallTableAdapter.Fill(this.frontDeskSuiteDataSet4.PizzasForHall, HallID);
            //PRODUCT
            this.productsForHallTableAdapter.Fill(this.frontDeskSuiteDataSet6.ProductsForHall, HallID);
            //EQIPMENT
            this.equipmentForHallTableAdapter.Fill(this.frontDeskSuiteDataSet5.EquipmentForHall, HallID);
            this.equipmentForHallSelectedTableAdapter.Fill(this.frontDeskSuiteDataSet20.EquipmentForHallSelected, HallID);
            this.equipmentForHallCheckedInTableAdapter.Fill(this.frontDeskSuiteDataSet3.EquipmentForHallCheckedIn, HallID);
            this.equipmentForHallCheckedOutTableAdapter.Fill(this.frontDeskSuiteDataSet2.EquipmentForHallCheckedOut, HallID);
            //PACKAGES
            this.packagesForHallTableAdapter.Fill(this.frontDeskSuiteDataSet7.PackagesForHall, HallID);
            this.studentsForSearchByHallTableAdapter.Fill(this.frontDeskSuiteDataSet21.StudentsForSearchByHall, HallID, "%%", "");
            //DvD
            this.getCurrentDvdReservationsTableAdapter.Fill(this.frontDeskSuiteDataSet25.getCurrentDvdReservations, HallID);
            this.getCurrentDvdReservationsOutTableAdapter.Fill(this.frontDeskSuiteDataSet14.getCurrentDvdReservationsOut, HallID);
            this.getCurrentDvdPurchasedTableAdapter.Fill(this.frontDeskSuiteDataSet19.getCurrentDvdPurchased, HallID);
            this.dvdForHallTableAdapter.Fill(this.frontDeskSuiteDataSet13.DvdForHall, HallID);
            //SALES
            updateSalesTab();
        }

        #region Main

        public void RefreshGridViews_Main()
        {
            this.salesForShiftTableAdapter.Fill(this.frontDeskSuiteDataSet10.SalesForShift, ShiftID);
            this.inventoryChangesForShiftTableAdapter.Fill(this.frontDeskSuiteDataSet11.InventoryChangesForShift, ShiftID);
        }

        #endregion Main

        #region Package

        public void RefreshGridViews_Package()
        {
            this.packagesForHallTableAdapter.Fill(this.frontDeskSuiteDataSet7.PackagesForHall, HallID);
        }

        private void btnRefreshPackage_Click(object sender, EventArgs e)
        {
            this.packagesForHallTableAdapter.Fill(this.frontDeskSuiteDataSet7.PackagesForHall, HallID);
            this.studentsForSearchByHallTableAdapter.Fill(this.frontDeskSuiteDataSet21.StudentsForSearchByHall, HallID, "%%", "");
        }

        #endregion Package

        #region Equipment

        /*
         * Refreshes all GV related to Equipment and sets the Condition IN to the Condition OUT
         */

        public void RefreshGridViews_Equipment()
        {
            this.equipmentForHallTableAdapter.Fill(this.frontDeskSuiteDataSet5.EquipmentForHall, HallID);
            this.equipmentForHallSelectedTableAdapter.Fill(this.frontDeskSuiteDataSet20.EquipmentForHallSelected, HallID);
            this.equipmentForHallCheckedInTableAdapter.Fill(this.frontDeskSuiteDataSet3.EquipmentForHallCheckedIn, HallID);
            this.equipmentForHallCheckedOutTableAdapter.Fill(this.frontDeskSuiteDataSet2.EquipmentForHallCheckedOut, HallID);

            foreach (DataGridViewRow row in DGVcheckInEquipment.Rows)
            {
                String conditionOut = row.Cells["EquipmentConditionOutReturn"].Value.ToString();
                if (!conditionOut.Equals(""))
                {
                    row.Cells["EquipmentConditionIn"].Value = conditionOut;
                }
            }
        }

        public void RefreshGridViews_Equipment_Selecting()
        {
            this.equipmentForHallSelectedTableAdapter.Fill(this.frontDeskSuiteDataSet20.EquipmentForHallSelected, HallID);
            this.equipmentForHallCheckedInTableAdapter.Fill(this.frontDeskSuiteDataSet3.EquipmentForHallCheckedIn, HallID);
        }

        #endregion Equipment

        #region Product

        public void RefreshGridViews_Product()
        {
            this.productsForHallTableAdapter.Fill(this.frontDeskSuiteDataSet6.ProductsForHall, HallID);
            RefreshGridViews_Main();
            updateSalesTab();
        }

        #endregion Product

        #region Pizza

        public void RefreshGridViews_Pizza()
        {
            //Fixes cases where workers sell pizzas after cash out has been started
            CashIn_Out.CashIn_Out_RefreshPizza();

            this.pizzasForHallTableAdapter.Fill(this.frontDeskSuiteDataSet4.PizzasForHall, HallID);
            RefreshGridViews_Main();
            updateSalesTab();
        }

        #endregion Pizza

        #region DVD

        private void RefreshGridViews_DVD()
        {
            this.getCurrentDvdReservationsTableAdapter.Fill(this.frontDeskSuiteDataSet25.getCurrentDvdReservations, HallID);
            this.getCurrentDvdReservationsOutTableAdapter.Fill(this.frontDeskSuiteDataSet14.getCurrentDvdReservationsOut, HallID);
            this.getCurrentDvdPurchasedTableAdapter.Fill(this.frontDeskSuiteDataSet19.getCurrentDvdPurchased, HallID);
            this.dvdForHallTableAdapter.Fill(this.frontDeskSuiteDataSet13.DvdForHall, HallID);
        }

        private void btnRefreshReservations_Click(object sender, EventArgs e)
        {
            this.getCurrentDvdReservationsTableAdapter.Fill(this.frontDeskSuiteDataSet25.getCurrentDvdReservations, HallID);
            this.getCurrentDvdReservationsOutTableAdapter.Fill(this.frontDeskSuiteDataSet14.getCurrentDvdReservationsOut, HallID);
            this.getCurrentDvdPurchasedTableAdapter.Fill(this.frontDeskSuiteDataSet19.getCurrentDvdPurchased, HallID);
            this.dvdForHallTableAdapter.Fill(this.frontDeskSuiteDataSet13.DvdForHall, HallID);
        }

        #endregion DVD

        #region Sales

        /*
         * PRE:Calcuates values of item sales/ credits for a shift
         * POST:Returns the values:
         * Sale Quantity,  Sale Value,  Credit Quantity,  Credit Value
         * Calcuated fully after any sale (pizza/products)
         */

        private void updateSalesTab()
        {
            int SalesQuantity = 0;
            decimal SalesValue = 0;
            int CreditQuantity = 0;
            decimal CreditValue = 0;
            foreach (DataGridViewRow row in DGVcurrentShiftSales.Rows)
            {
                if (Boolean.Parse(row.Cells["CurrentSalesIsCredit"].Value.ToString()) == false)
                {
                    SalesQuantity++;
                    decimal itemCost = decimal.Parse(row.Cells["CurrentSalesCost"].Value.ToString());
                    SalesValue += itemCost;
                }
                else
                {
                    CreditQuantity++;
                    decimal creditCost = decimal.Parse(row.Cells["CurrentSalesCost"].Value.ToString());
                    CreditValue += creditCost;
                }
            }
            lblNumberItemsAll.Text = SalesQuantity.ToString();
            lblValueItemsAll.Text = SalesValue.ToString("C2");
            lblNumberCredits.Text = CreditQuantity.ToString();
            lblValueCredits.Text = CreditValue.ToString("C2");
        }

        #endregion Sales

        #endregion GridViewRefresh_UtilityMethods

        #region OptionsTabMethods

        /*
        *  Auto totals cash field when any of the value boxes are changed
        */

        private void btnAutoTotalCash_Click(object sender, EventArgs e)
        {
            TotalCash = (decimal)((int)numericUpDownNickels.Value * .05 +
                            (int)numericUpDownDimes.Value * .1 +
                            (int)numericUpDownQuarters.Value * .25 +
                            (int)numericUpDownDollars.Value +
                            (int)numericUpDownFives.Value * 5 +
                            (int)numericUpDownTens.Value * 10);

            lblTotalCash.Text = String.Format("{0:C}", TotalCash);
        }

        /*
         * Auto totals the cashboxes and subtracts the withdraw amount to give
         * an updated total for the hall
         */

        private void btnCalcDcWithdraw_Click(object sender, EventArgs e)
        {
            btnAutoTotalCash_Click(this, null);
            if (!txtWithdrawAmt.Text.Equals(""))
            {
                Decimal withdraw = Decimal.Parse(txtWithdrawAmt.Text);
                lblNewTotalCash.Text = String.Format("{0:C}", ((TotalCash - withdraw).ToString()));
                btnSubmitDcWithdraw.Enabled = true;
            }
        }

        /*
         * Runs a DC Withdraw Shift
         * PRE: Must have completed the total cash and withdraw amount boxes in the OPTIONS page and have run the calculate buton
         * POST: Starts and ends a shift with the Total Cash, (Total Cash - Withdraw) respectively
         *
         */

        private void btnSubmitDcWithdraw_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to withdraw cash and end your shift? \n This will also close FDM.",
               "End Shift?", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FDS.Shift.setCashIn(ShiftID, TotalCash, "DC Withdraw");
                FDS.Shift.setCashOut(ShiftID, Decimal.Parse(lblNewTotalCash.Text), "");
                FDS.Shift.EndShift(ShiftID);
                Application.Exit();
            }
        }

        #endregion OptionsTabMethods

        #region ExcelExport

        /**
         * Methods to Export GV's to Excel sheets
         *
         * Work by copying all the the GV contents to the clipboard and pasting them into Excel
         *
         * Tables are hardcoded based on a dropdown on the OPTIONS page and for each GV the Headers must by hardcoded
         *
         */

        /*
         * Utility method for gridview Excell exports
         * Pre:selected Gridview
         * Post:All lines from the selected DataGridView are coppied to the systems global clipboard
         */

        private void copyAlltoClipboard(DataGridView DGV)
        {
            DGV.SelectAll();
            DataObject dataObj = DGV.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        /*
         * Exports the clipboard to Excell
         * Pre:Data in the clipboard
         * Post:Exports the data to a new Excell doc and fills in the header row for the respective case
         */

        private void exportToExcel_Click(object sender, EventArgs e)
        {
            if (cmbPrintInventories.Text.ToString().Equals("Products"))
            {
                copyAlltoClipboard(DGVproductsInventory);
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Equipment"))
            {
                copyAlltoClipboard(DGVequipmentInventory);
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Pizzas"))
            {
                copyAlltoClipboard(DGVpizzaInventory);
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Packages"))
            {
                copyAlltoClipboard(DGVpackageInventory);
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Dvds"))
            {
                copyAlltoClipboard(DGVDVDInventory);
            }

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            if (cmbPrintInventories.Text.ToString().Equals("Products"))
            {
                xlWorkSheet.Cells[1, 1] = "Name";
                xlWorkSheet.Cells[1, 2] = "Inventory";
                xlWorkSheet.Cells[1, 3] = "Price";
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Equipment"))
            {
                xlWorkSheet.Cells[1, 1] = "Name";
                xlWorkSheet.Cells[1, 2] = "Category";
                xlWorkSheet.Cells[1, 3] = "Condition";
                xlWorkSheet.Cells[1, 4] = "Status";
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Pizzas"))
            {
                xlWorkSheet.Cells[1, 1] = "Name";
                xlWorkSheet.Cells[1, 2] = "Brand";
                xlWorkSheet.Cells[1, 3] = "Inventory";
                xlWorkSheet.Cells[1, 4] = "Price";
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Packages"))
            {
                xlWorkSheet.Cells[1, 1] = "Description";
                xlWorkSheet.Cells[1, 2] = "Carrier";
                xlWorkSheet.Cells[1, 3] = "Student For";
                xlWorkSheet.Cells[1, 4] = "Received By";
                xlWorkSheet.Cells[1, 5] = "Date Received";
                xlWorkSheet.Cells[1, 6] = "Cost";
            }
            else if (cmbPrintInventories.Text.ToString().Equals("Dvds"))
            {
                xlWorkSheet.Cells[1, 1] = "ID";
                xlWorkSheet.Cells[1, 2] = "Title";
                xlWorkSheet.Cells[1, 3] = "Year";
                xlWorkSheet.Cells[1, 4] = "Runtime";
            }
        }

        #endregion ExcelExport
    }
}