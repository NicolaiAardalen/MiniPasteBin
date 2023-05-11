using BusinessObjects;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security.AntiXss;
using System.Text;
using System.Security.Policy;

namespace MiniPasteBin
{
    public partial class Default : System.Web.UI.Page
    {
        protected BLayer dbl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void CreateNewPasteBinButton_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString();
            string guidDataTimeAddOn = DateTime.Now.Millisecond.ToString();
            string fullGuid = guid + guidDataTimeAddOn;

            bool Private = false;
            if (PrivateCheckBox.Checked && PrivatePasswordTextBox.Text != "")
            {
                Private = true;
            }

            int BurnAfterReadingTrue = 0;
            bool BurnAfterReading = false;
            if (BurnAfterRedingCheckBox.Checked)
            {
                BurnAfterReading = true;
                BurnAfterReadingTrue = 1;
            }

            dbl.InsetPasteBinTextIntoDatabase(InsertTextBox.Text, fullGuid, Private, PrivatePasswordTextBox.Text, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), BurnAfterReading, BurnAfterReadingTrue);
            Response.Redirect($"PasteBins.aspx?GUID={fullGuid}");
        }
    }
}