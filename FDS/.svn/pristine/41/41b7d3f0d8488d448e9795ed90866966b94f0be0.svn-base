using System;
using System.Drawing;
using System.Windows.Forms;

namespace FDM3
{
    public partial class CashIn_Out : Form
    {
        private decimal TotalCash;
        private decimal TotalCashWithCredits;
        private int ShiftID;
        private int HallID;
        private Boolean doubleCount = false, pizzaInventory = false, pizzaErr = false;
        private decimal lastShiftOut = 0;
        private Main MainForm;

        /*
         * Initalizes instance varaibles
         */

        public CashIn_Out(int shiftID, int hallID, Main FormMain)
        {
            ShiftID = shiftID;
            HallID = hallID;
            MainForm = FormMain;
            InitializeComponent();
        }

        /*
         * Populates pizza gridview and removes the (min,max,exit) button box
         * and aquires the last shift out for comparison reasons
         */

        private void CashIn_Out_Load(object sender, EventArgs e)
        {
            this.pizzasForHallTableAdapter.Fill(this.frontDeskSuiteDataSet12.PizzasForHall, HallID);
            this.ControlBox = false;
            lastShiftOut = FDS.Shift.getLastCashOut(ShiftID, HallID);
        }

        #region MethodsIn

        /*
         * Submit cash in and pizza counts and reset controls for later use when cashing out
         */

        private void btnPopUpCashIn_Click(object sender, EventArgs e)
        {
            //If any pizza counts are missed or invalid tell the user
            if (checkPizzaCounts())
            {
                MessageBox.Show("Please enter valid counts for all pizzas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkPizzaCountsColor();
                return;
            }
            //If pizzas differ from current inventory ask for recount
            if (!pizzaInventory)
            {
                checkPizzaCountsError();
                pizzaInventory = true;
                return;
            }
            //If cash amounts differ set error
            if (TotalCash != lastShiftOut)
            {
                FDS.Shift.setCashErrorIn(ShiftID);
            }

            if (chkCount.Checked == true)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to submit your pizza counts and cash in?",
                    "Cash/Pizza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FDS.Shift.setCashIn(ShiftID, TotalCash, "Last Shift Out: " + lastShiftOut + " --- Difference: " + (TotalCash - lastShiftOut));
                    countPizzasIn();
                    MainForm.lblStartCashDollars.Text = TotalCash.ToString("C2");
                }
                else
                {
                    return;
                }
                cashIn_OutReset();
                MainForm.btnCashOut.Enabled = true;
                Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please certify that you have counted cash and pizzas.",
                "Cash/Pizza", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        #endregion MethodsIn

        #region MethodsOut

        /*
         *Submits cash out, pizza counts out, and resets control for application restart
         *Pre: adds up total sales and total credits to compare to  given cash out
         *post: restarted app
         */

        private void btnPopUpCashOut_Click(object sender, EventArgs e)
        {
            //If any pizza counts are missed or invalid tell the user
            if (checkPizzaCounts())
            {
                MessageBox.Show("Please enter counts for all pizzas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkPizzaCountsColor();
                return;
            }
            //If pizzas differ from current inventory ask for recount
            if (!pizzaInventory)
            {
                checkPizzaCountsError();
                pizzaInventory = true;
                return;
            }

            decimal cashOut = Decimal.Parse(MainForm.lblValueItemsAll.Text.ToString().TrimStart('$')) +
                              Decimal.Parse(MainForm.lblStartCashDollars.Text.ToString().TrimStart('$'));

            if (TotalCash != cashOut && doubleCount == false)
            {
                DialogResult result = MessageBox.Show("Please double count your cash as it differes from the system total.",
                 "Cash/Pizza", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
                doubleCount = true;
                return;
            }

            if (chkCount.Checked == true)
            {
                if (TotalCash != cashOut)
                {
                    txtCountsOff.Visible = true;
                    lblCountOffDC.Visible = true;

                    if (txtCountsOff.Text.ToString().Trim().Equals("") || txtCountsOff.Text == null)
                    {
                        DialogResult result = MessageBox.Show("Please enter a possible reason for your cash being off.",
                         "NotBalanced", MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
                        return;
                    }
                    FDS.Shift.setCashErrorOut(ShiftID);
                }
                FDS.Shift.setCashOut(ShiftID, TotalCash, " ----- \"" + txtCountsOff.Text + "\" ----- " + "\nSystem Cash Out: " +
                    cashOut + " --- Difference: " + (TotalCash - cashOut));
                countPizzasOut();
                FDS.Shift.EndShift(ShiftID);
                //Restart
                Application.Restart();
                //Application.Exit();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please certify that you have counted cash and pizzas.",
                 "Cash/Pizza", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
            }
        }

        #endregion MethodsOut

        #region HelperMethods

        private void cashIn_OutReset()
        {
            MainForm.tabCntrlFrontDesk.TabPages[2].Enabled = true;
            MainForm.tabCntrlFrontDesk.TabPages[3].Enabled = true;
            MainForm.tabCntrlFrontDesk.TabPages[2].BackColor = Color.White;
            MainForm.tabCntrlFrontDesk.TabPages[3].BackColor = Color.White;
            MainForm.pnlCashIn.Enabled = false;

            btnPopUpCashIn.Visible = false;
            btnPopUpCashOut.Visible = true;
            chkCount.Checked = false;
            pizzaInventory = false;

            numericUpDownNickels.Value = 0;
            numericUpDownDimes.Value = 0;
            numericUpDownQuarters.Value = 0;
            numericUpDownDollars.Value = 0;
            numericUpDownFives.Value = 0;
            numericUpDownTens.Value = 0;

            txtCountsOff.Enabled = true;

            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                Row.Cells["PizzaCounts"].Value = "";
            }
        }




        /*
         * Helper Method for CashIn
         *     Counts pizzas row by row in the gridview
         */

        private void countPizzasIn()
        {
            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                int pizzaID = int.Parse(Row.Cells["pizzaCountPizzaID"].Value.ToString());
                int pizzaInventory = int.Parse(Row.Cells["pizzaCountInventory"].Value.ToString());
                int count = int.Parse(Row.Cells["PizzaCounts"].Value.ToString());
                FDS.Shift.countPizzaIn(ShiftID, pizzaID, pizzaInventory, count);

                if (pizzaInventory != count && pizzaErr == false)
                {
                    pizzaErr = true;
                    FDS.Shift.setPizzaError(ShiftID);
                }
            }
        }

        /*
         * Helper Method for CashIn
         *     Counts pizzas row by row in the gridview
         */

        private void countPizzasOut()
        {
            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                int pizzaID = int.Parse(Row.Cells["pizzaCountPizzaID"].Value.ToString());
                int pizzaInventory = int.Parse(Row.Cells["pizzaCountInventory"].Value.ToString());
                int count = int.Parse(Row.Cells["PizzaCounts"].Value.ToString());
                FDS.Shift.countPizzaOut(ShiftID, pizzaID, pizzaInventory, count);

                if (pizzaInventory != count && pizzaErr == false)
                {
                    pizzaErr = true;
                    FDS.Shift.setPizzaError(ShiftID);
                }
            }
        }

        /*
         *Method to refresh pizza gridview for counting pizzas
         *out at the end of a shift
         */

        public void CashIn_Out_RefreshPizza()
        {
            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                Row.Cells["PizzaCounts"].Value = "";
            }
            DGVPizzaCount.Refresh();
            this.pizzasForHallTableAdapter.Fill(this.frontDeskSuiteDataSet12.PizzasForHall, HallID);
        }

        /*
        * Pre: checks to see if all pizzas have a count value
         * Post: Returns true if yes, else false
        */

        private Boolean checkPizzaCounts()
        {
            int num;
            Boolean badCounts = false;
            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                if (Row.Cells["PizzaCounts"].Value != null && int.TryParse(Row.Cells["PizzaCounts"].Value.ToString(), out num))
                {
                }
                else
                {
                    badCounts = true;
                }
            }
            return badCounts;
        }

        /*
        * Pre: checks to see if all pizzas have a count value
         * Post: Returns true if yes, else false
        */

        private void checkPizzaCountsError()
        {
            String countOffPizzas = "";

            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                int pizzaInventory = int.Parse(Row.Cells["pizzaCountInventory"].Value.ToString());
                int count = int.Parse(Row.Cells["PizzaCounts"].Value.ToString());
                String name = Row.Cells["pizzaCountName"].Value.ToString();
                String brand = Row.Cells["pizzaCountBrand"].Value.ToString();
                checkPizzaCountsColor();

                if (pizzaInventory != count)
                {
                    countOffPizzas += brand + " " + name + "\n";
                }
            }
            if (!countOffPizzas.Equals(""))
            {
                DialogResult result = MessageBox.Show("Please re-count the following pizza(s): \n" + countOffPizzas,
                     "Cash/Pizza", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void checkPizzaCountsColor()
        {
            foreach (DataGridViewRow Row in DGVPizzaCount.Rows)
            {
                int pizzaInventory = int.Parse(Row.Cells["pizzaCountInventory"].Value.ToString());
                int count;
                Boolean valid = int.TryParse(Row.Cells["PizzaCounts"].Value.ToString(), out count);

                if (pizzaInventory != count)
                {
                    Row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else if(!valid)
                {
                    Row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else
                {
                    Row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

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

            //lblCreditValue.Text = MainForm.lblValueCredits.Text.ToString();

            TotalCashWithCredits = TotalCash + Decimal.Parse(lblCreditValue.Text.ToString().TrimStart('$'));

            lblTotalCash.Text = String.Format("{0:C}", TotalCash);
            lblTotalCashWithCredits.Text = String.Format("{0:C}", TotalCashWithCredits);
        }

        #endregion HelperMethods

    }
}