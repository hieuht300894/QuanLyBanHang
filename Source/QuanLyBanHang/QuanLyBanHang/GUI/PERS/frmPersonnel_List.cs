using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanHang.BLL.PERS;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel_List : frmBase
    {
        #region Variables
        IList<xPersonnel> lstPersonnel = new List<xPersonnel>();
        IList<xPersonnel> lstRepoPersonnel = new List<xPersonnel>();
        #endregion

        #region Form Events
        public frmPersonnel_List()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadData();
            CustomForm();
        }
        #endregion

        #region Grid Events
        private void grvPersonnelList_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvPersonnelList.CalcHitInfo(mouse.Location);
            if (grvPersonnelList.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                UpdateEntry();
            }
        }

        private void gctPersonnelList_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e, true, true, true, false, true, true);
        }
        #endregion

        #region Base Button Events
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsertEntry();
        }

        protected override void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshEntry();
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateEntry();
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteEntry();
        }

        protected override void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsertEntry();
        }

        protected override void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateEntry();
        }

        protected override void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteEntry();
        }

        protected override void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshEntry();
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            lstPersonnel = new List<xPersonnel>();
            clsFunction.Instance.SelectAsync(this, gctPersonnelList, lstPersonnel, "select top 100 * from xPersonnel", new SqlParameter[] { });
            gctPersonnelList.DataSource = lstPersonnel;

            //lstRepoPersonnel = new List<xPersonnel>();
            //clsFunction.Instance.SelectAsync(this, rlokPersonnel, lstRepoPersonnel, "select top 100 * from xPersonnel", new SqlParameter[] { });
            //rlokPersonnel.DataSource = lstRepoPersonnel;
        }

        public void InsertEntry()
        {
            using (frmPersonnel _frm = new frmPersonnel())
            {
                _frm.Text = "Thêm mới nhân viên";
                _frm.fType = eFormType.Add;
                _frm.ShowDialog();
            }
        }

        public void UpdateEntry()
        {
            if (grvPersonnelList.RowCount > 0 && grvPersonnelList.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmPersonnel _frm = new frmPersonnel())
                    {
                        xPersonnel _eEntry = (xPersonnel)grvPersonnelList.GetRow(grvPersonnelList.FocusedRowHandle);
                        _frm.iEntry = _eEntry;
                        _frm.Text = "Cập nhật nhân viên";
                        _frm.fType = eFormType.Edit;
                        _frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }

        public void DeleteEntry()
        {
            //int[] Indexes = grvPersonnelList.GetSelectedRows();
            //List<int> lstIDNhanVien = new List<int>();
            //List<int> lstIDTaiKhoan = new List<int>();
            //bool IsWarming = false;
            //for (int i = 0; i < Indexes.Length; i++)
            //{
            //    xPersonnel personnel = (xPersonnel)grvPersonnelList.GetRow(Indexes[i]);
            //    if (!IsWarming)
            //    {
            //        //Thông báo nếu chưa được cảnh báo nhân viên đã có tài khoản
            //        if (personnel.IsAccount)
            //        {
            //            bool IsXoa = clsGeneral.showConfirmMessage("Nhân viên đã có tài khoản! Xác nhận xóa tài khoản của nhân viên này?");
            //            if (IsXoa)
            //            {
            //                lstIDNhanVien.Add(personnel.KeyID);
            //                lstIDTaiKhoan.Add(personnel.KeyID);
            //            }
            //        }
            //        else
            //        {
            //            lstIDNhanVien.Add(personnel.KeyID);
            //        }
            //    }
            //    else
            //    {
            //        lstIDNhanVien.Add(personnel.KeyID);
            //        if (personnel.IsAccount)
            //            lstIDTaiKhoan.Add(personnel.KeyID);
            //    }
            //    //Thông báo có áp dụng cho các trường hợp nhân viên đã có tài khoản
            //    if (!IsWarming && personnel.IsAccount) IsWarming = clsGeneral.showConfirmMessage("Áp dụng cho tất cả nhân viên được xóa?");
            //}

            //clsPersonnel.Instance.Init();
            //clsPersonnel.Instance.SetEntity(typeof(xPersonnel).Name, lstIDNhanVien);
            //clsPersonnel.Instance.SetEntity(typeof(xAccount).Name, lstIDTaiKhoan);
            //clsPersonnel.Instance.ReloadProgress = LoadProgress;
            //clsPersonnel.Instance.ReloadPercent = LoadPercent;
            //clsPersonnel.Instance.ReloadMessage = LoadMessage;
            //clsPersonnel.Instance.ReloadError = LoadError;
            //clsPersonnel.Instance.ReloadData = loadData;
            //clsPersonnel.Instance.StartRun();


            int[] Indexes = grvPersonnelList.GetSelectedRows();
            List<xPersonnel> lstNhanVien = new List<xPersonnel>();
            for (int i = 0; i < Indexes.Length; i++)
            {
                xPersonnel personnel = (xPersonnel)grvPersonnelList.GetRow(Indexes[i]);
                lstNhanVien.Add(personnel);
            }

            //clsPersonnel.Instance.Init();
            //clsPersonnel.Instance.SetEntity(typeof(xPersonnel).Name, lstNhanVien.ToList<object>());
            //clsPersonnel.Instance.ReloadProgress = OpenProgress;
            //clsPersonnel.Instance.ReloadPercent = LoadPercent;
            //clsPersonnel.Instance.ReloadMessage = LoadMessage;
            //clsPersonnel.Instance.ReloadError = LoadError;
            //clsPersonnel.Instance.StartRun();

            // lstPersonnel = new List<xPersonnel>();
        }

        public void RefreshEntry()
        {
            LoadData();
        }

        public override void CustomForm()
        {
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
            base.CustomForm();
        }

        protected override void grv_TopRowChanged<T>(object sender, EventArgs e, IList<T> ListData, string query, SqlParameter[] parameters)
        {
            GridView view = (GridView)sender;
            xPersonnel personnel = view.GetRow(GetGridViewLastRow(view)) as xPersonnel;
            if (personnel == null) return;

            query = $"select top 10 * from xPersonnel where KeyID>@KeyID";
            parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@KeyID", personnel.KeyID);
            base.grv_TopRowChanged(sender, e, ListData, query, parameters);

        }
        #endregion
    }
}