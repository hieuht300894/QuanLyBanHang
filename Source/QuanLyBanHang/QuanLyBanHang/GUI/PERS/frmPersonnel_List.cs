using System;
using System.Windows.Forms;
using QuanLyBanHang.BLL.PERS;
using EntityModel.DataModel;
using System.Data.Entity;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel_List : frmBase
    {
        #region Variables
        BindingList<xPersonnel> lstData = new BindingList<xPersonnel>();
        #endregion

        #region Form Events
        public frmPersonnel_List()
        {
            InitializeComponent();
        }

        private void frmNhanVien_List_Load(object sender, EventArgs e)
        {
            LoadData(0, gctPersonnelList, lstData);
            //loadData(0);
            grvPersonnelList.OptionsSelection.MultiSelect = true;
            grvPersonnelList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
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
        private void loadPersonnel()
        {
            rlokPersonnel.DataSource = clsPersonnel.Instance.GetAll();
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
        }

        private void loadData(int KeyID)
        {
            loadPersonnel();
            gctPersonnelList.DataSource = clsPersonnel.Instance.SearchPersonnel(true, 0);
            if (KeyID > 0)
                grvPersonnelList.FocusedRowHandle = grvPersonnelList.LocateByValue("KeyID", KeyID);
        }

        private void insertEntry()
        {
            using (frmPersonnel _frm = new frmPersonnel())
            {
                _frm.Text = "Thêm mới nhân viên".Translation("ftxtAddPersonnel", _frm.Name);
                _frm.fType = eFormType.Add;
                _frm.ReLoadParent = this.loadData;
                _frm.ShowDialog();
            }
        }

        private void updateEntry()
        {
            if (grvPersonnelList.RowCount > 0 && grvPersonnelList.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmPersonnel _frm = new frmPersonnel())
                    {
                        xPersonnel _eEntry = (xPersonnel)grvPersonnelList.GetRow(grvPersonnelList.FocusedRowHandle);
                        _frm.iEntry = _eEntry;
                        _frm.Text = "Cập nhật nhân viên".Translation("ftxtUpdatePersonnel", _frm.Name);
                        _frm.fType = eFormType.Edit;
                        _frm.ReLoadParent = this.loadData;
                        _frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }

        private void deleteEntry()
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
            bool IsWarming = false;
            for (int i = 0; i < Indexes.Length; i++)
            {
                xPersonnel personnel = (xPersonnel)grvPersonnelList.GetRow(Indexes[i]);
                if (!IsWarming)
                {
                    //Thông báo nếu chưa được cảnh báo nhân viên đã có tài khoản
                    if (personnel.IsAccount)
                    {
                        bool IsXoa = clsGeneral.showConfirmMessage("Nhân viên đã có tài khoản! Xác nhận xóa tài khoản của nhân viên này?");
                        if (IsXoa)
                            lstNhanVien.Add(personnel);
                    }
                    else
                    {
                        lstNhanVien.Add(personnel);
                    }
                }
                else
                {
                    lstNhanVien.Add(personnel);
                }
                //Thông báo có áp dụng cho các trường hợp nhân viên đã có tài khoản
                if (!IsWarming && personnel.IsAccount) IsWarming = clsGeneral.showConfirmMessage("Áp dụng cho tất cả nhân viên được xóa?");
            }
            clsPersonnel.Instance.Init();
            clsPersonnel.Instance.SetEntity(typeof(xPersonnel).Name, lstNhanVien.ToList<object>());
            //clsPersonnel.Instance.SetEntity(typeof(xAccount).Name, lstTaiKhoan);
            clsPersonnel.Instance.ReloadProgress = LoadProgress;
            clsPersonnel.Instance.ReloadPercent = LoadPercent;
            clsPersonnel.Instance.ReloadMessage = LoadMessage;
            clsPersonnel.Instance.ReloadError = LoadError;
            clsPersonnel.Instance.ReloadData = loadData;
            clsPersonnel.Instance.StartRun();
        }

        private void refreshEntry()
        {
            loadData(0);
        }

        private void customForm()
        {
            gctPersonnelList.Format();

            lctPersonnel.BestFitText();
        }
        #endregion
    }
}