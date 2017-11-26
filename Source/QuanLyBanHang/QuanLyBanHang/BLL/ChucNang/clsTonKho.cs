using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.ChucNang
{
    public class clsTonKho : clsFunction<eTonKho>
    {
        #region Contructor
        protected clsTonKho() { }
        public new static clsTonKho Instance
        {
            get { return new clsTonKho(); }
        }
        #endregion

        public async Task<IList<eTonKho>> TonKhoHienTai(int IDNhomSanPham, string MaSanPham, string TenSanPham)
        {
            try
            {
                db = new aModel();
                return await Task.Factory.StartNew(() =>
                {
                    IEnumerable<eTonKho> lstTemp = db.eTonKho.ToList();

                    if (IDNhomSanPham > 0)
                        lstTemp = lstTemp.Where(x => x.IDNhomSanPham == IDNhomSanPham);

                    if (!string.IsNullOrEmpty(MaSanPham))
                        lstTemp = lstTemp.Where(x => x.MaSanPham.ToLower().Contains(MaSanPham.ToLower()));

                    if (!string.IsNullOrEmpty(TenSanPham))
                        lstTemp = lstTemp.Where(x => x.TenSanPham.ToLower().Contains(TenSanPham.ToLower()));



                    List<eTonKho> lstResult = new List<eTonKho>();
                    return lstResult;
                });
            }
            catch { return new List<eTonKho>(); }
        }
    }
}
