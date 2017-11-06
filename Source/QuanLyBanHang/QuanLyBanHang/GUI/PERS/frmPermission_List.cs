using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.GUI.PER;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PERS
{
    public partial class frmPermission_List : frmBase
    {
        #region Variables
        #endregion

        #region Form Events
        public frmPermission_List()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadPersonnel();
            LoadData(0);
            CustomForm();
        }
        #endregion

        #region Grid Events
        private void grvPermission_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvPermission.CalcHitInfo(mouse.Location);
            if (grvPermission.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
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
        private async void LoadPersonnel()
        {
            IList<xPersonnel> lstPersonel = await clsPersonnel.Instance.GetAllPersonnel();
            await RunMethodAsync(() => { rlokPersonnel.DataSource = lstPersonel; });
        }

        private async void LoadData(int KeyID)
        {
            IList<xPermission> lstPermission = await clsPermission.Instance.SearchPermission(true, 0);
            await RunMethodAsync(() =>
            {
                gctPermission.DataSource = lstPermission;
                if (KeyID > 0)
                    grvPermission.FocusedRowHandle = grvPermission.LocateByValue("KeyID", KeyID);
            });
        }

        private void InsertEntry()
        {
            using (frmPermission _frm = new frmPermission())
            {
                _frm.Text = "Thêm mới quyền";
                _frm.fType = eFormType.Add;
                _frm.ReloadData = this.LoadData;
                _frm.ShowDialog();
            }
        }

        private void UpdateEntry()
        {
            if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmPermission _frm = new frmPermission())
                    {
                        xPermission _eEntry = (xPermission)grvPermission.GetRow(grvPermission.FocusedRowHandle);
                        _frm._iEntry = _eEntry;
                        _frm.Text = "Cập nhật quyền";
                        _frm.fType = eFormType.Edit;
                        _frm.ReloadData = this.LoadData;
                        _frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }

        private void DeleteEntry()
        {
            //if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0 && clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu".Translation("msgConfirmDelete", this.Name)))
            //{
            //    try
            //    {
            //        if (clsPersonnel.Instance.re(((xPersonnel)grvPermission.GetRow(grvPermission.FocusedRowHandle)).KeyID))
            //        {
            //            loadData(0);
            //        }
            //        else
            //            clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgDeleteFailed", this.Name));

            //    }
            //    catch (Exception ex)
            //    {
            //        clsGeneral.showErrorException(ex, "Exception");
            //    }
            //}
        }

        private void RefreshEntry()
        {
            LoadPersonnel();
            LoadData(0);
        }

        public override void CustomForm()
        {
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";

            base.CustomForm();
            gctPermission.MouseClick += gctPersonnelList_MouseClick;
            grvPermission.DoubleClick += grvPermission_DoubleClick;
        }
        #endregion
    }
}
