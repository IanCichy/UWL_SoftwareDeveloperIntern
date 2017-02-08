using System;
using System.Windows.Forms;

namespace FDM3
{
    public partial class PizzaSellOptions : Form
    {
        //Pizza information & instance varaibles from the main form
        private int shiftID, userID, pizzaID, pizzaInventory, saleAmount, isCredit = 0;
        private String pizzaBrand, pizzaName, creditReason = "";
        private decimal pizzaPrice, cost;
        private Main MainForm;

        /*
         * Main method that loads the correct fields fron the main form and initalize fields
         */

        public PizzaSellOptions(int shift_ID, int user_ID, String pizza_Brand, String pizza_Name,
            int pizza_ID, int pizza_Inventory, int sale_Amount, decimal pizza_Price, Main FormMain)
        {
            InitializeComponent();
            this.ControlBox = false;
            lblPizzaName.Text = pizza_Brand + " " + pizza_Name;

            shiftID = shift_ID;
            userID = user_ID;
            pizzaID = pizza_ID;
            pizzaInventory = pizza_Inventory;
            saleAmount = sale_Amount;
            pizzaPrice = pizza_Price;
            pizzaBrand = pizza_Brand;
            pizzaName = pizza_Name;
            cost = pizza_Price * sale_Amount;

            MainForm = FormMain;

            lblCost.Text = "Total Cost: " + cost.ToString("C2");
            lblAmount.Text = "Quantity: x" + saleAmount.ToString();
            MainForm.Enabled = false;
        }

        /*
         * Method to sell a pizza
         * Pre:Sale type selected and
         * Post:Pizza sold and recorded in system
         */

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (isCredit == 1)
            {
                if (!txtDcNote.Text.Trim().Equals("") && txtDcNote.Text != null)
                {
                    if (radioButtonBurnedRuined.Checked == true)
                    {
                        creditReason = "Burned/Ruined -- ";
                    }
                    else if (radioButtonProgramPizza.Checked == true)
                    {
                        creditReason = "Program -- ";
                    }
                    else
                    {
                        creditReason = "Other -- ";
                    }
                    creditReason += txtDcNote.Text;
                }
                else
                {
                    MessageBox.Show("Please enter a valid reason.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DialogResult result = MessageBox.Show("Are you sure you want to sell:\t\n\tQuantity: " + saleAmount
                + "\n\tBrand: " + pizzaBrand
                + "\n\tType:  " + pizzaName
                + "\n\tCurrent Inventory: " + pizzaInventory,
                "Sell Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainForm.Enabled = true;
                MainForm.Focus();
                FDS.Pizza.PizzaSell(pizzaInventory - saleAmount, pizzaID, shiftID, userID, isCredit, creditReason, cost, saleAmount);
                MainForm.RefreshGridViews_Pizza();
                this.Close();
            }
        }

        /*
         * Method to cancel a pizza sale at any time
         */

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.Enabled = true;
            MainForm.Focus();
            this.Close();
        }

        /*
         * Method to change the type of sale and adjust any fields needed
         */

        private void radioButtonSell_CheckedChanged(object sender, EventArgs e)
        {
            txtDcNote.Enabled = false;
            isCredit = 0;
        }

        /*
         * Method to change the type of sale and adjust any fields needed
         */

        private void radioButtonBurnedRuined_CheckedChanged(object sender, EventArgs e)
        {
            txtDcNote.Enabled = true;
            isCredit = 1;
        }

        /*
         * Method to change the type of sale and adjust any fields needed
         */

        private void radioButtonProgramPizza_CheckedChanged(object sender, EventArgs e)
        {
            txtDcNote.Enabled = true;
            isCredit = 1;
        }

        /*
         * Method to change the type of sale and adjust any fields needed
         */

        private void radioButtonOther_CheckedChanged(object sender, EventArgs e)
        {
            txtDcNote.Enabled = true;
            isCredit = 1;
        }

        private void PizzaSellOptions_Load(object sender, EventArgs e)
        {
        }
    }
}