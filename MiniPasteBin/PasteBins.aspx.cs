using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessObjects;

namespace MiniPasteBin
{
    public partial class PasteBins : System.Web.UI.Page
    {
        BLayer dbl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataFromPasteBinWhereGuid();
                GetDatedFormDBIntoLabel();
                BurnAfterReading();
            }
        }

        public void GetDataFromPasteBinWhereGuid()
        {
            List<BObjects> bo = dbl.GetAllDataFromPasteBin();

            var GUIDfromReqQueStr = Request.QueryString["GUID"];

            var GUIDFromDB = bo
                .Where(i => i.GUID == GUIDfromReqQueStr)
                .Select(i => i.PasteBinText)
                .ToList();
            PasteBinTextBox.Text = string.Join(", ", GUIDFromDB);
        }

        public void GetDatedFormDBIntoLabel()
        {
            List<BObjects> bo = dbl.GetAllDataFromPasteBin();

            var GUIDfromReqQueStr = Request.QueryString["GUID"];

            var CreationDateFromDB = bo
                .Where(i => i.GUID == GUIDfromReqQueStr)
                .Select(i => i.CreationDate)
                .ToList();

            var LastVisitedFromDB = bo
                .Where(i => i.GUID == GUIDfromReqQueStr)
                .Select(i => i.LastVisited)
                .ToList();

            var ExpirationDateFromDB = bo
                .Where(i => i.GUID == GUIDfromReqQueStr)
                .Select(i => i.ExpirationDate)
                .ToList();

            CreationDatelabel.Text = string.Join(", ", CreationDateFromDB);
            LastVisitedLabel.Text = string.Join(", ", LastVisitedFromDB);
            ExpirationDateLabel.Text = string.Join(", ", ExpirationDateFromDB);
        }

        public void BurnAfterReading()
        {
            try
            {
                List<BObjects> bo = dbl.GetAllDataFromPasteBin();

                var GUIDfromReqQueStr = Request.QueryString["GUID"];

                var GUIDFromDB = bo
                    .Where(i => i.GUID == GUIDfromReqQueStr)
                    .Select(i => i.GUID)
                    .ToList();
                string GUIDFromDBJoined = string.Join(", ", GUIDFromDB);

                var BurnAfterReadingTrueFromDB = bo
                    .Where(i => i.GUID == GUIDfromReqQueStr)
                    .Select(i => i.BurnAfterReadingTrue)
                    .ToList();

                int BurnAfterReadingTrueFromDBJoined = int.Parse(string.Join(", ", BurnAfterReadingTrueFromDB));
                if (BurnAfterReadingTrueFromDBJoined != 0)
                {
                    BurnAfterReadingTrueFromDBJoined += 1;
                    dbl.UpdateBurnAfterReadingTrue(BurnAfterReadingTrueFromDBJoined, GUIDFromDBJoined);
                    if (BurnAfterReadingTrueFromDBJoined >= 3)
                    {
                        dbl.BurnAfterReadingDeleteWhereGUID(GUIDFromDBJoined);
                    }
                }
            }
            catch (Exception) { };
        }
    }
}