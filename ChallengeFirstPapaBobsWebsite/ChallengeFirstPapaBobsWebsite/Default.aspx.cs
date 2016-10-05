using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            int babyPrice = 10;
            int mamaPrice = 13;
            int papaPrice = 16;
            int deepDish = 2;
            double totalPrice = 0.0;
            double pepperoni = 1.50;
            double onions = 0.75;
            double greenPeppers = 0.50;
            double redPeppers = 0.75;
            int anchovies = 2;
            int discount = 2;

            if (babyBobRadioButton.Checked)
            {
                totalPrice = babyPrice;              
            }
            if (mamaBobRadioButton.Checked)
            {
                totalPrice = mamaPrice;
            }
            if (papaBobRadioButton.Checked)
            {
                totalPrice = papaPrice;
            }

            totalPrice = (DeepDishRadioButton.Checked) ? totalPrice + deepDish : totalPrice;
            totalPrice = (pepperoniCheckBox.Checked) ? totalPrice + pepperoni : totalPrice;
            totalPrice = (onionsCheckBox.Checked) ? totalPrice + onions : totalPrice;
            totalPrice = (greenPeppersCheckBox.Checked) ? totalPrice + greenPeppers : totalPrice;
            totalPrice = (redPeppersCheckBox.Checked) ? totalPrice + redPeppers : totalPrice;
            totalPrice = (anchoviesCheckBox.Checked) ? totalPrice + anchovies : totalPrice;

            if ((pepperoniCheckBox.Checked && greenPeppersCheckBox.Checked && anchoviesCheckBox.Checked) 
                || (pepperoniCheckBox.Checked && redPeppersCheckBox.Checked && onionsCheckBox.Checked))
            {
                totalPrice -= discount;
            }

            priceLabel.Text = totalPrice.ToString();
        }
    }
}