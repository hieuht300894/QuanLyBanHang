using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.BLL.DanhMuc
{
    class clsKhachHang : clsFunction<eKhachHang>
    {
        #region Contructor
        protected clsKhachHang() { }
        public new static clsKhachHang Instance
        {
            get { return new clsKhachHang(); }
        }
        #endregion
    }
}
