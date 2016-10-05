using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] assetName1 = new string[0];
                int[] electionsRigged1 = new int[0];
                double[] subterfuge1 = new double[0];
               

                ViewState.Add("Asset Name", assetName1);
                ViewState.Add("Elections Rigged", electionsRigged1);
                ViewState.Add("Subterfuge", subterfuge1);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            string[] assetName = (string[])ViewState["Asset Name"];
            Array.Resize(ref assetName, assetName.Length + 1);
            int newNameSize = assetName.GetUpperBound(0);
            assetName[newNameSize] = assetNameTextBox.Text;
            ViewState["Asset Name"] = assetName;
            assetNameTextBox.Text = "";

            int[] electionsRigged = (int[])ViewState["Elections Rigged"];
            Array.Resize(ref electionsRigged, electionsRigged.Length + 1);
            int newElectionsSize = electionsRigged.GetUpperBound(0);
            electionsRigged[newElectionsSize] = int.Parse(electionsRiggedTextBox.Text);
            ViewState["Elections Rigged"] = electionsRigged;
            electionsRiggedTextBox.Text = "";

            double[] subterfuge = (double[])ViewState["Subterfuge"];
            Array.Resize(ref subterfuge, subterfuge.Length + 1);
            int newSubterfugeSize = subterfuge.GetUpperBound(0);
            subterfuge[newSubterfugeSize] = double.Parse(subterfugeTextBox.Text);
            ViewState["Subterfuge"] = subterfuge;
            subterfugeTextBox.Text = "";

            resultLabel.Text = String.Format("Total elections rigged: {0}<br />Average acts of Subterfuge per Asset: {1:N2}" +
                "<br /> (Last Asset you added: {2})",
                electionsRigged.Sum(), subterfuge.Average(), assetName[newNameSize]);
        }
    }
}