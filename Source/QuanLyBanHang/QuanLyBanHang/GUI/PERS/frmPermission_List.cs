using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.GUI.PER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PERS
{
    public partial class frmPermission_List : frmBase
    {
        #region Variables
        List<xPersonnel> lstPersonel = new List<xPersonnel>();
        #endregion

        #region Form Events
        public frmPermission_List()
        {
            InitializeComponent();
        }

        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);

            loadData(0);
            customForm();
        }
        #endregion

        #region Grid Events
        private void grvPermission_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvPermission.CalcHitInfo(mouse.Location);
            if (grvPermission.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                updateEntry();
            }
        }
        private void gctPersonnelList_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e);
        }
        private void grvPermission_ShownEditor(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView.IsFilterRow(gridView.FocusedRowHandle))
            {
                switch (gridView.FocusedColumn.FieldName)
                {
                    case "CreatedBy":
                    case "ModifiedBy":
                        LookUpEdit lok = gridView.ActiveEditor as LookUpEdit;
                        lok.Properties.DataSource = lstPersonel.Where(x => x.IsEnable).ToList();
                        break;
                }
            }
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
            lstPersonel = new List<xPersonnel>(clsPersonnel.Instance.GetAll());
            rlokPersonnel.DataSource = lstPersonel;
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
        }

        private void loadData(int KeyID)
        {
            loadPersonnel();
            gctPermission.DataSource = clsPermission.Instance.Search(true);
            if (KeyID > 0)
                grvPermission.FocusedRowHandle = grvPermission.LocateByValue("KeyID", KeyID);
        }

        private void insertEntry()
        {
            using (frmPermission _frm = new frmPermission())
            {
                _frm.Text = "Thêm mới quyền";
                _frm.fType = eFormType.Add;
                _frm.ReloadData = this.loadData;
                _frm.ShowDialog();
            }
        }

        private void updateEntry()
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
                        _frm.ReloadData = this.loadData;
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

        private void refreshEntry()
        {
            loadData(0);
        }

        private void customForm()
        {
            gctPermission.Format();
            lctPersonnel.BestFitText();

            gctPermission.MouseClick += gctPersonnelList_MouseClick;
            grvPermission.DoubleClick += grvPermission_DoubleClick;
            grvPermission.ShownEditor += grvPermission_ShownEditor;
        }
        #endregion
    }
}
