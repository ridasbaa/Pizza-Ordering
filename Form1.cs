using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIZZAV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public float GetSelectedSizePrice() {

            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }

            if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }

            if (rbLarge.Checked)
            {

                return Convert.ToSingle(rbLarge.Tag);
            }
            return 0;
        }

        public float GetSelectedToppingsPrice() {

            float TotalToppings = 0;

            if (chkExtraCheese.Checked)
            {
                TotalToppings += Convert.ToSingle(chkExtraCheese.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                TotalToppings += Convert.ToSingle(chkGreenPeppers.Tag);
            }

            if (chkMushrooms.Checked)
            {
                TotalToppings += Convert.ToSingle(chkMushrooms.Tag);
            }

            if (chkOlives.Checked)
            {
                TotalToppings += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkTomatoes.Checked)
            {
                TotalToppings += Convert.ToSingle(chkTomatoes.Tag);
            }

            if (chkUnion.Checked)
            {
                TotalToppings += Convert.ToSingle(chkUnion.Tag);
            }

            return TotalToppings;
        }

        public float GetSelectedCrustType() {

            if (rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);
            }

            if (rbThickCrust.Checked)
            {
                return Convert.ToSingle(rbThickCrust.Tag);
            }
            return 0;
        }

        public void UpdateTotalPrice()
        {
            float FinalPrice = GetSelectedSizePrice() + GetSelectedToppingsPrice() + GetSelectedCrustType() ;

            lblPrice.Text = "$" +  FinalPrice.ToString();

        }

        public void UpdateSize() {

            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
            }

            if (rbLarge.Checked) {

                lblSize.Text = "Large";
            }


        }

        public void UpdateCrustType() {
            UpdateTotalPrice();

            if (rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
            }

            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
            }

        }

        public void UpdateToppings() { 
        
            UpdateTotalPrice() ;

            string sToppings = "";

            if (chkExtraCheese.Checked)
            {
                sToppings += "Extra Cheese";
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }

            if (chkUnion.Checked)
            {
                sToppings += ", Union";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if (sToppings == "")
            {
                sToppings = "No Toppings";
            }

            lblToppings.Text = sToppings;

        }

        public void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize() ;
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkUnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
             MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gbCrustType.Enabled = false;
            gbSize.Enabled = false;
            gbToppings.Enabled = false;
            gbWhereToEat.Enabled = false;       



        }

        public void ResetForm() {


            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            chkExtraCheese.Checked = false;
            chkGreenPeppers.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkUnion.Checked = false;

            rbSmall.Checked = true;
            rbEatIn.Checked = true;
            rbThinCrust.Checked = true;
            btnOrderPizza.Enabled = true;
        }
        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void UpdateOrderSummary()
        {
            UpdateCrustType();
            UpdateSize();
            UpdateToppings();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
