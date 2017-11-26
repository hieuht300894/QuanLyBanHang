using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.ChucNang
{
    public class clsNhapHangNhaCungCap : clsFunction<eNhapHangNhaCungCap>
    {
        #region Contructor
        protected clsNhapHangNhaCungCap() { }
        public new static clsNhapHangNhaCungCap Instance
        {
            get { return new clsNhapHangNhaCungCap(); }
        }
        #endregion

        public async Task<IList<eNhapHangNhaCungCapChiTiet>> NhapHangChiTiet(int KeyID)
        {
            try {
                db = new aModel();
                return await Task.Factory.StartNew(() => {
                    IEnumerable<eNhapHangNhaCungCapChiTiet> lstTemp = db.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == KeyID);
                    IList<eNhapHangNhaCungCapChiTiet> lstResult = lstTemp.ToList();
                    return lstResult;
                });
            }
            catch { return new List<eNhapHangNhaCungCapChiTiet>(); }
        }
    }
}
