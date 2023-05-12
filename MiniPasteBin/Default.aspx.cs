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
using System.Web.Security;
using System.Security.Cryptography;

namespace MiniPasteBin
{
    public partial class Default : System.Web.UI.Page
    {
        protected BLayer dbl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dbl.DeleteWhereExpirationDate();
                GetAllBinsFromDB();
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

            var HasedPasswordFromTextBox = ComputeSha256Hash(PrivatePasswordTextBox.Text);

            dbl.InsetPasteBinTextIntoDatabase(InsertTextBox.Text, fullGuid, Private, HasedPasswordFromTextBox, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), BurnAfterReading, BurnAfterReadingTrue);

            if (PrivatePasswordTextBox.Text == "")
            {
                FormsAuthentication.RedirectFromLoginPage(fullGuid, false); 
            }
            Response.Redirect($"PasteBins.aspx?GUID={fullGuid}");
        }

        public void GetAllBinsFromDB()
        {
            try
            {
                List<BObjects> bo = dbl.GetAllDataFromPasteBin();

                var IDFormDB = bo
                    .Select(i => i.ID)
                    .ToList();

                foreach (int id in IDFormDB)
                {
                    BinsDropDown.Items.Add(id.ToString());
                }
            }
            catch (Exception) { }
        }


        protected void GoToBinButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<BObjects> bo = dbl.GetAllDataFromPasteBin();

                int SelectedIDFromDropDown = int.Parse(BinsDropDown.SelectedItem.Text);

                var GUIDWhereSelectedID = bo
                    .Where(i => i.ID == SelectedIDFromDropDown)
                    .Select(i => i.GUID)
                    .ToList();
                var GUIDWhereSelectedIDJoined = string.Join(", ", GUIDWhereSelectedID);

                var PasswordFromDB = bo
                    .Where(i => i.ID == SelectedIDFromDropDown)
                    .Select(i => i.PrivatePassword)
                    .ToList();
                var PasswordFromDBJoined = string.Join(", ", PasswordFromDB);


                if (PasswordFromDBJoined == ComputeSha256Hash(""))
                {
                    FormsAuthentication.RedirectFromLoginPage(GUIDWhereSelectedIDJoined, false);
                }
                Response.Redirect($"PasteBins.aspx?GUID={GUIDWhereSelectedIDJoined}");
            }
            catch (Exception) { }
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}