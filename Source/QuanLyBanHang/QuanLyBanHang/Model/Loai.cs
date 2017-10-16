using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Model
{
    public class Loai
    {
        public int KeyID { get; set; }
        public string Ten { get; set; }
        public static List<Loai> LoaiDonViHanhChinh()
        {
            List<Loai> lstResult = new List<Loai>();
            lstResult.Add(new Loai() { KeyID = 1, Ten = "Thành phố trực thuộc TW" });
            lstResult.Add(new Loai() { KeyID = 2, Ten = "Tỉnh" });
            lstResult.Add(new Loai() { KeyID = 3, Ten = "Quận" });
            lstResult.Add(new Loai() { KeyID = 4, Ten = "Huyện" });
            lstResult.Add(new Loai() { KeyID = 5, Ten = "Thành phố trực thuộc tỉnh" });
            lstResult.Add(new Loai() { KeyID = 6, Ten = "Thị xã" });
            lstResult.Add(new Loai() { KeyID = 7, Ten = "Phường" });
            lstResult.Add(new Loai() { KeyID = 8, Ten = "Thị trấn" });
            lstResult.Add(new Loai() { KeyID = 8, Ten = "Xã" });
            return lstResult;
        }
    }
}
