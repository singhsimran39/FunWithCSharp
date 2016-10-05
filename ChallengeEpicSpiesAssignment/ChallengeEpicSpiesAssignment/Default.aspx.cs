using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("gb-GB");
            if (!Page.IsPostBack)
            {
                previousAssignmentCalendar.SelectedDate = DateTime.Today;
                newAssignmentStartCalendar.SelectedDate = DateTime.Today.AddDays(14);
                newAssignmentEndCalendar.SelectedDate = DateTime.Today.AddDays(21);
            }
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            double difference = newAssignmentStartCalendar.SelectedDate.Subtract(previousAssignmentCalendar.SelectedDate).TotalDays;
            double assignmentDuration = (newAssignmentEndCalendar.SelectedDate.Subtract(newAssignmentStartCalendar.SelectedDate)).TotalDays + 1;
            int perDayCost = 500;
            double totalCost = (assignmentDuration * perDayCost);
            

            if (difference < 15)
            {
                resultLabel.Text = "Error: Must allow at least 2 weeks between previous assignment and new assignment";
                newAssignmentStartCalendar.SelectedDate = previousAssignmentCalendar.SelectedDate.AddDays(15);
                newAssignmentStartCalendar.VisibleDate = newAssignmentStartCalendar.SelectedDate;
            }
            else
            {
                if (assignmentDuration > 21)
                {
                    totalCost += 1000;
                    resultLabel.Text = String.Format("{0} allocated to assignment {1}. Budget total: {2:C2}",
                        spyNameTextBox.Text, assignmentNameTextBox.Text, totalCost);
                }
                else
                {
                    resultLabel.Text = String.Format("{0} allocated to assignment {1}. Budget total: {2:C2}",
                        spyNameTextBox.Text, assignmentNameTextBox.Text, totalCost);
                }
            }
        }
    }
}