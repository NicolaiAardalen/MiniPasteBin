using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BObjects
    {
        public int ID { get; set; }
        public string PasteBinText { get; set; }
        public string GUID { get; set; }
        public bool Private { get; set; }
        public string PrivatePassword { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastVisited { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool BurnAfterReading { get; set; }
        public int BurnAfterReadingTrue { get; set; }
    }
}
