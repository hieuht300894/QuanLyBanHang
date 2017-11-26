using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.DanhMuc
{
    public class clsSanPham : clsFunction<eSanPham>
    {
        #region Contructor
        protected clsSanPham() { }
        public new static clsSanPham Instance
        {
            get { return new clsSanPham(); }
        }
        #endregion

        public async Task<IList<eSanPham>> TimKiemSanPham(int IDNhomSanPham, string MaSanPham, string TenSanPham)
        {
            try
            {
                db = new aModel();
                return await Task.Factory.StartNew(() =>
                {
                    IEnumerable<eSanPham> lstTemp = db.eSanPham.ToList();

                    if (!string.IsNullOrEmpty(MaSanPham))
                        lstTemp = lstTemp.Where(x => x.Ma.ToLower().Contains(MaSanPham.ToLower()));

                    if (!string.IsNullOrEmpty(TenSanPham))
                        lstTemp = lstTemp.Where(x => x.Ten.ToLower().Contains(TenSanPham.ToLower()));

                    return lstTemp.ToList();
                });
            }
            catch { return new List<eSanPham>(); }
        }
    }
}
