using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.Common
{
    class clsUserLogs
    {
        #region Constructor
        private static volatile clsUserLogs instance = null;
        private static readonly object mLock = new object();
        protected clsUserLogs() { }
        public static clsUserLogs Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsUserLogs();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        aModel db;
        public int getLastKeyID()
        {
            db = new aModel();
            return db.xUserLogs.Max(x => x.KeyID);
        }

        public xUserLog getUserLog(int KeyID)
        {
            db = new aModel();
            return db.xUserLogs.Find(KeyID);
        }

        public string getTableName(int keyID)
        {
            db = new aModel();
            IEnumerable<xUserLog> lstTemp = db.xUserLogs.Where(x => x.KeyID >= keyID);
            string[] filter = new string[] { "eUnit" };

            foreach (var item in lstTemp)
            {
                if (filter.Any(x => x.Equals(item.TableName)))
                    return item.TableName;
            }
            return string.Empty;
        }
        #endregion
    }
}
