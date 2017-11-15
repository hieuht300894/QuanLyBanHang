using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmNhaCungCap : frmBaseGrid
    {
        BindingList<eNhaCungCap> lstEntries = new BindingList<eNhaCungCap>();
        BindingList<eNhaCungCap> lstEdited = new BindingList<eNhaCungCap>();

        public frmNhaCungCap()
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

        async void LoadRepository()
        {
            IList<eTinhThanh> lstTinhThanh = new List<eTinhThanh>(await clsTinhThanh.Instance.Get63TinhThanh());
            await RunMethodAsync(() => { rlokTinhThanh.DataSource = lstTinhThanh; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eNhaCungCap>();
            lstEntries = new BindingList<eNhaCungCap>(await clsFunction<eNhaCungCap>.Instance.GetAll());
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
                eTinhThanh tinhThanh = (eTinhThanh)rlokTinhThanh.GetDataSourceRowByKeyValue(x.IDTinhThanh) ?? new eTinhThanh();

                x.TinhThanh = tinhThanh.Ten;
            });

            bool chk = false;
            chk = await clsFunction<eNhaCungCap>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokTinhThanh.ValueMember = "KeyID";
            rlokTinhThanh.DisplayMember = "Ten";

            base.CustomForm();

            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.RowUpdated += grvDanhSach_RowUpdated;
        }

        private void gctDanhSach_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
        private void grvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!lstEdited.Any(x => x.KeyID == ((eNhaCungCap)e.Row).KeyID)) lstEdited.Add((eNhaCungCap)e.Row);
        }
    }
}
