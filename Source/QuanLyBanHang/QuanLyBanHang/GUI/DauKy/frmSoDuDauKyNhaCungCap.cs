using EntityModel.DataModel.DanhMuc;
using EntityModel.DataModel.DauKy;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DauKy
{
    public partial class frmSoDuDauKyNhaCungCap : frmBaseGrid
    {
        BindingList<eSoDuDauKyNhaCungCap> lstEntries = new BindingList<eSoDuDauKyNhaCungCap>();
        BindingList<eSoDuDauKyNhaCungCap> lstEdited = new BindingList<eSoDuDauKyNhaCungCap>();

        public frmSoDuDauKyNhaCungCap()
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
            IList<eNhaCungCap> lstNhaCungCap = await clsFunction<eNhaCungCap>.Instance.GetAll();
            await RunMethodAsync(() => { rlokNhaCungCap.DataSource = lstNhaCungCap; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eSoDuDauKyNhaCungCap>();
            lstEntries = new BindingList<eSoDuDauKyNhaCungCap>(await clsFunction<eSoDuDauKyNhaCungCap>.Instance.GetAll());
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
                eNhaCungCap NhaCungCap = (eNhaCungCap)rlokNhaCungCap.GetDataSourceRowByKeyValue(x.IDNhaCungCap) ?? new eNhaCungCap();
                x.MaNhaCungCap = NhaCungCap.Ma;
                x.TenNhaCungCap = NhaCungCap.Ten;
            });

            bool chk = false;
            chk = await clsFunction<eSoDuDauKyNhaCungCap>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokNhaCungCap.ValueMember = "KeyID";
            rlokNhaCungCap.DisplayMember = "Ten";

            base.CustomForm();

            gctDanhSach.MouseClick += (s, e) => { ShowGridPopup(s, e, true, false, true, true, true, true); };
            grvDanhSach.RowUpdated += (s, e) => { if (!lstEdited.Any(x => x.KeyID == ((eSoDuDauKyNhaCungCap)e.Row).KeyID)) lstEdited.Add((eSoDuDauKyNhaCungCap)e.Row); };
        }
    }
}
