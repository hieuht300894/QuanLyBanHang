using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;

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
