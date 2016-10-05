using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                createRandomImages();
                string currency = setCurrency();
                if (currency == "") return;
                else moneyLabel.Text = String.Format("{0:C}", 100);
            }
        }

        protected void currencyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currency = setCurrency();
            if (currency == "") return;
            else
            {
                moneyLabel.Text = String.Format("{0:C}", 100);
                resultLabel.Text = "";
            }
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            string currency = setCurrency();
            if (currency == "") return;
            else newBet();
        }

        private string setCurrency()
        {
            string currency = currencyDropDownList.Text;
            switch (currency)
            {
                case "USD":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("us-US");
                    break;
                case "GBP":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("gb-GB");
                    break;
                case "EUR":
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                    break;
                default:
                    resultLabel.Text = "Please select a currency to play";
                    break;
            }
            return currency;
        }

        private void newBet()
        {
            if (yourBetTextBox.Text == "") resultLabel.Text = "Please place a bet before pulling the Lever..";
            else
            {
                double yourBet = double.Parse(yourBetTextBox.Text);
                createRandomImages();
                checkSevenCombination(yourBet);
            }
        }
        
        private void createRandomImages()
        {
            Random random = new Random();
            string[] images = Directory.GetFiles("F:\\VS2015 Exprs\\All Practice\\MegaChallengeCasino\\MegaChallengeCasino", "*.png");
            firstImage.ImageUrl = images[random.Next(0, images.Length)].Substring(69);
            secondImage.ImageUrl = images[random.Next(0, images.Length)].Substring(69);
            thirdImage.ImageUrl = images[random.Next(0, images.Length)].Substring(69);
            /*firstImage.ImageUrl = "Seven.png";
            secondImage.ImageUrl = "Seven.png";
            thirdImage.ImageUrl = "Seven.png";*/
        }

        private void checkSevenCombination(double yourBet)
        {
            if (firstImage.ImageUrl == "Seven.png" && secondImage.ImageUrl == "Seven.png" && thirdImage.ImageUrl == "Seven.png")
            {
                double winningAmount = yourBet * 100;
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", yourBet, winningAmount);
                setMoneyLabel(yourBet, winningAmount);
            }
            else checkBarCombination(yourBet);
        }

        private void checkBarCombination(double yourBet)
        {
            if (firstImage.ImageUrl == "Bar.png" || secondImage.ImageUrl == "Bar.png" || thirdImage.ImageUrl == "Bar.png")
            {
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", yourBet);
                setMoneyLabel(yourBet);
            }
            else checkCherryCombination(yourBet);
        }

        private void checkCherryCombination(double yourBet)
        {
            if (checkOneCherry()) winAmountForCherry(yourBet, 2);
            else if (checkTwoCherry()) winAmountForCherry(yourBet, 3);
            else if (checkThreeCherry()) winAmountForCherry(yourBet, 4);
            else noWinnigCombination(yourBet);
            
            /*if (firstImage.ImageUrl == "Cherry.png" && (secondImage.ImageUrl != "Cherry.png" && thirdImage.ImageUrl != "Cherry.png")
                || (secondImage.ImageUrl == "Cherry.png" && (firstImage.ImageUrl != "Cherry.png" && thirdImage.ImageUrl != "Cherry.png"))
                || (thirdImage.ImageUrl == "Cherry.png" && (firstImage.ImageUrl != "Cherry.png" && secondImage.ImageUrl != "Cherry.png")))
            {
                double winningAmount = yourBet * 2;
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", yourBet, winningAmount);
                setMoneyLabel(yourBet);
            }
            else if (firstImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl != "Cherry.png"
                || firstImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl != "Cherry.png"
                || secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png" && firstImage.ImageUrl != "Cherry.png")
            {
                double winningAmount = yourBet * 3;
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", yourBet, winningAmount);
                setMoneyLabel(yourBet);
            }
            else if (firstImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png")
            {
                double winningAmount = yourBet * 4;
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", yourBet, winningAmount);
                setMoneyLabel(yourBet);
            }
            else noWinnigCombination(yourBet);*/
        }

        private bool checkOneCherry()
        {
            if (firstImage.ImageUrl == "Cherry.png" && (secondImage.ImageUrl != "Cherry.png" && thirdImage.ImageUrl != "Cherry.png")
                || (secondImage.ImageUrl == "Cherry.png" && (firstImage.ImageUrl != "Cherry.png" && thirdImage.ImageUrl != "Cherry.png"))
                || (thirdImage.ImageUrl == "Cherry.png" && (firstImage.ImageUrl != "Cherry.png" && secondImage.ImageUrl != "Cherry.png")))
                return true;
            else
                return false;
        }

        private bool checkTwoCherry()
        {
            if ((firstImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl != "Cherry.png"
                || firstImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl != "Cherry.png"
                || secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png" && firstImage.ImageUrl != "Cherry.png"))
                return true;
            else
                return false;
        }

        private bool checkThreeCherry()
        {
            if (firstImage.ImageUrl == "Cherry.png" && secondImage.ImageUrl == "Cherry.png" && thirdImage.ImageUrl == "Cherry.png")
                return true;
            else
                return false;
        }

        private void winAmountForCherry(double yourBet, double multiplier)
        {
            double winningAmount = yourBet * multiplier;
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", yourBet, winningAmount);
            setMoneyLabel(yourBet, winningAmount);
        }

        private void noWinnigCombination(double yourBet)
        {
            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", yourBet);
            setMoneyLabel(yourBet);
        }

        private void setMoneyLabel(double yourBet, double winningAmount = 0.0)
        {
            double remainingMoney = double.Parse(moneyLabel.Text.Substring(1));
            remainingMoney -= yourBet;
            remainingMoney += winningAmount;
            moneyLabel.Text = String.Format("{0:C}", remainingMoney);
        }

    }
}

    
