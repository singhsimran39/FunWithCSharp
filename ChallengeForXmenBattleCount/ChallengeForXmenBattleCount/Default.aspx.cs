using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };
            int maximum = numbers[0];
            int minimum = numbers[0];
            int maximumIndex = 0;
            int minimumIndex = 0;
           
            for (int iCount = 0; iCount < numbers.Length - 1; iCount++)
            {
                if (numbers[iCount + 1] > maximum)
                {
                    maximum = numbers[iCount + 1];
                    maximumIndex = iCount + 1;
                }
                if (numbers[iCount + 1] < minimum)
                {
                    minimum = numbers[iCount + 1];
                    minimumIndex = iCount + 1;
                }
            }
            
            resultLabel.Text = string.Format("Most battles belong to: {0} (Value: {1}) <br /> Least battles belong to: {2} (Value: {3})",
                names[maximumIndex], numbers[maximumIndex], names[minimumIndex], numbers[minimumIndex]);
        }
    }
}