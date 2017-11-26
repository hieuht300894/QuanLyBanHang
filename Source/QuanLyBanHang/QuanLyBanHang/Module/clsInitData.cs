using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuanLyBanHang.Module
{
    public class clsInitData
    {
        public static IList<eDonViTinh> lstDonViTinh = new List<eDonViTinh>();
        public static IList<eKhachHang> lstKhachHang = new List<eKhachHang>();
        public static IList<eKho> lstKho = new List<eKho>();
        public static IList<eNhaCungCap> lstNhaCungCap = new List<eNhaCungCap>();
        public static IList<eNhomDonViTinh> lstNhomDonViTinh = new List<eNhomDonViTinh>();
        public static IList<eNhomKhachHang> lstNhomKhachHang = new List<eNhomKhachHang>();
        public static IList<eNhomNhaCungCap> lstNhomNhaCungCap = new List<eNhomNhaCungCap>();
        public static IList<eNhomSanPham> lstNhomSanPham = new List<eNhomSanPham>();
        public static IList<eSanPham> lstSanPham = new List<eSanPham>();
        public static IList<eTienTe> lstTienTe = new List<eTienTe>();
        public static IList<eTinhThanh> lstTinhThanh = new List<eTinhThanh>();

        public async static void TaiDuLieu()
        {
            lstDonViTinh = await clsFunction<eDonViTinh>.Instance.GetAll();
            lstKhachHang = await clsFunction<eKhachHang>.Instance.GetAll();
            lstKho = await clsFunction<eKho>.Instance.GetAll();
            lstNhaCungCap = await clsFunction<eNhaCungCap>.Instance.GetAll();
            lstNhomDonViTinh = await clsFunction<eNhomDonViTinh>.Instance.GetAll();
            lstNhomKhachHang = await clsFunction<eNhomKhachHang>.Instance.GetAll();
            lstNhomNhaCungCap = await clsFunction<eNhomNhaCungCap>.Instance.GetAll();
            lstNhomSanPham = await clsFunction<eNhomSanPham>.Instance.GetAll();
            lstSanPham = await clsFunction<eSanPham>.Instance.GetAll();
            lstTienTe = await clsFunction<eTienTe>.Instance.GetAll();
            lstTinhThanh = await clsFunction<eTinhThanh>.Instance.GetAll();
        }

        public async static Task<IList<T>> LayDuLieu<T>() where T : class, new()
        {
            Task<IList<T>> task = Task.Factory.StartNew(() =>
            {
                Type type = typeof(clsInitData);
                foreach (FieldInfo fInfo in type.GetFields())
                {
                    if (fInfo.FieldType.GetGenericTypeDefinition() == typeof(IList<>) && fInfo.FieldType.GenericTypeArguments.Count() > 0 && fInfo.FieldType.GenericTypeArguments[0] == typeof(T))
                    {
                        if (fInfo.GetValue(null) != null)
                            return (IList<T>)fInfo.GetValue(null);
                    }
                }
                return new List<T>();
            });
            return await task;
        }

        public async static void ThemDuLieu<T>(T obj) where T : class, new()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                Type type = typeof(clsInitData);
                foreach (FieldInfo fInfo in type.GetFields())
                {
                    if (fInfo.FieldType.GetGenericTypeDefinition() == typeof(IList<>) && fInfo.FieldType.GenericTypeArguments.Count() > 0 && fInfo.FieldType.GenericTypeArguments[0] == typeof(T))
                    {
                        if (fInfo.GetValue(null) != null)
                            ((IList<T>)fInfo.GetValue(null)).Add(obj);
                    }
                }
            });
            await task;
        }
    }
}
