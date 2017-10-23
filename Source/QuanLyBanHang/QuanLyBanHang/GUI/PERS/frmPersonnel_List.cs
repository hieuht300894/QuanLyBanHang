using CustomControl;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel_List : frmBase
    {
        #region Variables
        IList<xPersonnel> lstPersonnel = new List<xPersonnel>();
        #endregion

        #region Form Events
        public frmPersonnel_List()
        {
            InitializeComponent();
        }
        private void frmNhanVien_List_Load(object sender, EventArgs e)
        {
            lstPersonnel = new List<xPersonnel>();
            LoadData(0, userGridControl1, lstPersonnel, null, null, true);
            customForm();
        }
        #endregion

        #region Grid Events
        private void grvPersonnelList_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvPersonnelList.CalcHitInfo(mouse.Location);
            if (grvPersonnelList.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                updateEntry();
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
            insertEntry();
        }

        protected override void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateEntry();
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteEntry();
        }

        protected override void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            insertEntry();
        }

        protected override void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateEntry();
        }

        protected override void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteEntry();
        }

        protected override void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
        }
        #endregion

        #region Methods
        public void insertEntry()
        {
            using (frmPersonnel _frm = new frmPersonnel())
            {
                _frm.Text = "Thêm mới nhân viên";
                _frm.fType = eFormType.Add;
                _frm.ShowDialog();
            }
        }

        public void updateEntry()
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

        public void deleteEntry()
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

            clsPersonnel.Instance.Init();
            clsPersonnel.Instance.SetEntity(typeof(xPersonnel).Name, lstNhanVien.ToList<object>());
            clsPersonnel.Instance.ReloadProgress = OpenProgress;
            clsPersonnel.Instance.ReloadPercent = LoadPercent;
            clsPersonnel.Instance.ReloadMessage = LoadMessage;
            clsPersonnel.Instance.ReloadError = LoadError;
            clsPersonnel.Instance.StartRun();

            lstPersonnel = new List<xPersonnel>();
            LoadData(0, gctPersonnelList, lstPersonnel, null, null);
        }

        public void refreshEntry()
        {
        }

        public void customForm()
        {
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
            gctPersonnelList.Format();
            userGridControl1.GridControl.Format();
            lctPersonnel.BestFitText();


            // grvPersonnelList.TopRowChanged += grvPersonnelList_TopRowChanged;

            userGridControl1.GridView.TopRowChanged += gridView_TopRowChanged;
        }

        private void gridView_TopRowChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            GridViewInfo vi = view.GetViewInfo() as GridViewInfo;
            List<GridRowInfo> lstRowsInfo = new List<GridRowInfo>(vi.RowsInfo.Where(x => x.VisibleIndex != -1));
            for (int i = lstRowsInfo.Count - 1; i >= 0; i--)
            {
                if (view.IsRowVisible(lstRowsInfo[i].VisibleIndex) != RowVisibleState.Visible || view.IsNewItemRow(lstRowsInfo[i].VisibleIndex))
                    lstRowsInfo.RemoveAt(i);
            }
            int LastRow = lstRowsInfo.Select(x => x.VisibleIndex).ToList().DefaultIfEmpty().Max();
            int RowCount = view.OptionsView.NewItemRowPosition == NewItemRowPosition.None ? view.RowCount - 1 : view.RowCount - 2;

            if (LastRow == RowCount)
            {
                GridRowInfo RowInfo = lstRowsInfo.Last();
                Dictionary<string, object> dFrom = new Dictionary<string, object>();
                dFrom.Add("KeyID", ((xPersonnel)RowInfo.RowKey).KeyID + 1);
                LoadData(0, userGridControl1, lstPersonnel, dFrom, null, true);
            }
        }
        #endregion
    }
}