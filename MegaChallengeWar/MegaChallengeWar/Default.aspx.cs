using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            Game startGame = new Game("Player1", "Player2");
            resultLabel.Text = String.Format("<h3>Dealing cards ...</h3><br/>");

            resultLabel.Text += startGame.DisplayDealtCards().ToString();

            Battle b1 = new Battle(startGame);
            resultLabel.Text += b1.startTwentyBattles();
        }
    }
}