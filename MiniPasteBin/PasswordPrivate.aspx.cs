using BusinessObjects;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace MiniPasteBin
{
    public partial class PasswordPrivate : System.Web.UI.Page
    {
        private BLayer dbl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckPasswordButton_Click(object sender, EventArgs e)
        {
            List<BObjects> bo = dbl.GetAllDataFromPasteBin();

            var GUIDfromReqQueStr = Request.QueryString["GUID"];

            var PasswordFromDB = bo
                .Where(i => i.GUID == GUIDfromReqQueStr)
                .Select(i => i.PrivatePassword)
                .ToList();
            var PasswordFromDBJoined = string.Join(", ", PasswordFromDB);

            var HashedPasswordFromTextBox = ComputeSha256Hash(PasswordTextBox.Text);

            if (HashedPasswordFromTextBox == PasswordFromDBJoined)
            {
                FormsAuthentication.RedirectFromLoginPage(PasswordFromDBJoined, false);
            }
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

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}