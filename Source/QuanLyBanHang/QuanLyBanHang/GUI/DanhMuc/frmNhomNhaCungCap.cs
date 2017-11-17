using EntityModel.DataModel.DanhMuc;
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

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmNhomNhaCungCap : frmBaseGrid
    {
        BindingList<eNhomNhaCungCap> lstEntries = new BindingList<eNhomNhaCungCap>();
        BindingList<eNhomNhaCungCap> lstEdited = new BindingList<eNhomNhaCungCap>();

        public frmNhomNhaCungCap()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
        }

        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eNhomNhaCungCap>();
            lstEntries = new BindingList<eNhomNhaCungCap>(await clsFunction<eNhomNhaCungCap>.Instance.GetAll());
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
            bool chk = false;
            chk = await clsFunction<eNhomNhaCungCap>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            base.CustomForm();
            gctDanhSach.MouseClick += (s, e) => { ShowGridPopup(s, e, true, false, true, true, true, true); };
            grvDanhSach.RowUpdated += (s, e) => { if (!lstEdited.Any(x => x.KeyID == ((eNhomNhaCungCap)e.Row).KeyID)) lstEdited.Add((eNhomNhaCungCap)e.Row); };
        }
    }
}
