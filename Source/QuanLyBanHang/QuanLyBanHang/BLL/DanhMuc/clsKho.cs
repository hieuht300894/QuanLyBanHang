using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.DanhMuc
{
    public class clsKho : clsFunction<eKho>
    {
        #region Contructor
        protected clsKho() { }
        public new static clsKho Instance
        {
            get { return new clsKho(); }
        }
        #endregion
    }
}
