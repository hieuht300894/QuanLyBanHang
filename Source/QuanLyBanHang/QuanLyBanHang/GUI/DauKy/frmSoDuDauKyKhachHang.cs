using DevExpress.XtraBars;
using EntityModel.DataModel.DanhMuc;
using EntityModel.DataModel.DauKy;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.GUI.DauKy
{
    public partial class frmSoDuDauKyKhachHang : frmBaseGrid
    {
        BindingList<eSoDuDauKyKhachHang> lstEntries = new BindingList<eSoDuDauKyKhachHang>();
        BindingList<eSoDuDauKyKhachHang> lstEdited = new BindingList<eSoDuDauKyKhachHang>();

        public frmSoDuDauKyKhachHang()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadRepository();
            LoadData(0);
            CustomForm();
        }

        public async void LoadRepository()
        {
            IList<eKhachHang> lstKhachHang = await clsFunction<eKhachHang>.Instance.GetAll();
            await RunMethodAsync(() => { rlokKhachHang.DataSource = lstKhachHang; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eSoDuDauKyKhachHang>();
            lstEntries = new BindingList<eSoDuDauKyKhachHang>(await clsFunction<eSoDuDauKyKhachHang>.Instance.GetAll());
            await RunMethodAsync(() => { gctDanhSach.DataSource = lstEntries; });
        }
        public override bool ValidationForm()
        {
            grvDanhSach.CloseEditor();
            grvDanhSach.UpdateCurrentRow();
            return base.ValidationForm();
        }
        public async override Task<bool> SaveData()
        {
            lstEdited.ToList().ForEach(x =>
            {
                eKhachHang khachHang = (eKhachHang)rlokKhachHang.GetDataSourceRowByKeyValue(x.IDKhachHang) ?? new eKhachHang();
                x.MaKhachHang = khachHang.Ma;
                x.TenKhachHang = khachHang.Ten;
            });

            bool chk = false;
            chk = await clsFunction<eSoDuDauKyKhachHang>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokKhachHang.ValueMember = "KeyID";
            rlokKhachHang.DisplayMember = "Ten";

            base.CustomForm();

            gctDanhSach.MouseClick += (s, e) => { ShowGridPopup(s, e, true, false, true, true, true, true); };
            grvDanhSach.RowUpdated += (s, e) => { if (!lstEdited.Any(x => x.KeyID == ((eSoDuDauKyKhachHang)e.Row).KeyID)) lstEdited.Add((eSoDuDauKyKhachHang)e.Row); };
        }
    }
}
