using EntityModel.DataModel;
using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.DanhMuc
{
    class clsTinhThanh : clsFunction<eTinhThanh>
    {
        #region Contructor
        protected clsTinhThanh() { }
        public new static clsTinhThanh Instance
        {
            get { return new clsTinhThanh(); }
        }
        #endregion

        public async Task<IList<eTinhThanh>> Get63TinhThanh()
        {
            try
            {
                IEnumerable<eTinhThanh> lstTemp = await GetAll();
                lstTemp = lstTemp.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2);
                IList<eTinhThanh> lstResult = lstTemp.ToList();
                return lstResult;
            }
            catch { return new List<eTinhThanh>(); }
        }
    }
}
