using System;
using System.Windows.Forms;
using QuanLyBanHang.BLL.PERS;
using EntityModel.DataModel;
using System.Data.Entity;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel_List : frmBase
    {
        #region Variables
        #endregion

        #region Form Events
        public frmPersonnel_List()
        {
            InitializeComponent();
        }

        private void frmNhanVien_List_Load(object sender, EventArgs e)
        {
            loadData(0);
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
            base.ShowGridPopup(sender, e);
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
            //if (grvPersonnelList.RowCount > 0 && grvPersonnelList.FocusedRowHandle >= 0 && clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu".Translation("msgConfirmDelete", this.Name)))
            //{
            //    try
            //    {
            //        if (clsPersonnel.Instance.deleteEntry(((xPersonnel)grvPersonnelList.GetRow(grvPersonnelList.FocusedRowHandle)).KeyID))
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