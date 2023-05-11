using DatabaseLayer;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BLayer
    {
        private DBLayer dbl = new DBLayer();

        public List<BObjects> GetAllDataFromPasteBin()
        {
            return dbl.GetAllDataFromPasteBin();
        }

        public void InsetPasteBinTextIntoDatabase(string PasteBinText, string GUID, bool Private, string PrivatePassword, DateTime CreationDate, DateTime LastVisited, DateTime ExpirationDate, bool BurnAfterReading, int BurnAfterReadingTrue)
        {
            dbl.InsetPasteBinTextIntoDatabase(PasteBinText, GUID, Private, PrivatePassword, CreationDate, LastVisited, ExpirationDate, BurnAfterReading, BurnAfterReadingTrue);
        }

        public void DeleteWhereExpirationDate()
        { 
            dbl.DeleteWhereExpirationDate();
        }

        public void UpdateBurnAfterReadingTrue(int BurnAfterReadingTrue, string GUIDFromDB)
        {
            dbl.UpdateBurnAfterReadingTrue(BurnAfterReadingTrue, GUIDFromDB);
        }

        public void BurnAfterReadingDeleteWhereGUID(string GUIDFromDB)
        {
            dbl.BurnAfterReadingDeleteWhereGUID(GUIDFromDB);
        }
    }
}
