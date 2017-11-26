using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.NhapHang
{
    public partial class frmNhapHangNhaCungCap : frmBase
    {
        IList<eSanPham> lstSanPham = new List<eSanPham>();
        IList<eKho> lstKho = new List<eKho>();
        IList<eNhomSanPham> lstNhomSanPham = new List<eNhomSanPham>();

        public frmNhapHangNhaCungCap()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);

            LoadRepository();
            LoadDataForm();
            CustomForm();
        }
        protected override void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.frmBase_FormClosing(sender, e);
            _ReloadData?.Invoke(0);
        }

        async void LoadRepository()
        {
            lstNhomSanPham = await clsFunction<eNhomSanPham>.Instance.GetAll();
            lstSanPham = await clsFunction<eSanPham>.Instance.GetAll();
            lstKho = await clsFunction<eKho>.Instance.GetAll();

            await RunMethodAsync(() =>
            {
                lokNhomSanPham.Properties.DataSource = lstNhomSanPham;
                rlokSanPham.DataSource = lstSanPham;
                rlokKho.DataSource = lstKho;

                var qSanPham = lstSanPham.Select(x => new { x.Ma, x.Ten });
                foreach(var rSanPham in qSanPham)
                {
                    srcMaSanPham.Properties.Items.Add(rSanPham.Ma);
                    srcTenSanPham.Properties.Items.Add(rSanPham.Ten);
                }
            });
        }
        public override void LoadDataForm()
        {
        }
        public override void SetControlValue()
        {
        }
        public override bool ValidationForm()
        {
            return base.ValidationForm();
        }
        public override Task<bool> SaveData()
        {
            return base.SaveData();
        }
        public override void CustomForm()
        {
            lokNhaCungCap.Properties.ValueMember = "KeyID";
            lokNhaCungCap.Properties.DisplayMember = "Ten";
            lokNhomSanPham.Properties.ValueMember = "KeyID";
            lokNhomSanPham.Properties.DisplayMember = "Ten";
            rlokKho.ValueMember = "KeyID";
            rlokKho.DisplayMember = "Ten";
            rlokSanPham.ValueMember = "KeyID";
            rlokSanPham.DisplayMember = "Ten";

            base.CustomForm();

            grvChiTiet.OptionsView.ColumnAutoWidth = false;
        }
    }
}
