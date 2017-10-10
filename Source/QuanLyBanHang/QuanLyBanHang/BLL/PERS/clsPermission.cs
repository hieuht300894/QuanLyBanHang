using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPermission : clsTemplate<xPermission>
    {
        #region Constructor
        private static volatile clsPermission instance = null;
        private static readonly object mLock = new object();
        protected clsPermission() { }
        public new static clsPermission Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsPermission();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IList<xPermission> SearchPermission(bool IsEnable, int KeyID)
        {
            repository.Context = new aModel();
            IEnumerable<xPermission> lstTemp = repository.Context.xPermission.Where(x => x.IsEnable == IsEnable || x.KeyID == KeyID);
            return lstTemp.ToList();
        }
    }
}
