using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;


namespace QuanLyBanHang.GUI.PER
{
    public partial class frmAccount_List : frmBase
    {
        #region Variables
        #endregion

        #region Form Events
        public frmAccount_List()
        {
            InitializeComponent();
        }

        private void frmAccount_List_Load(object sender, EventArgs e)
        {
            loadData(0);
            customForm();
        }
        #endregion

        #region Grid Events
        private void grvAccountList_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvAccountList.CalcHitInfo(mouse.Location);
            if (grvAccountList.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                updateEntry();
            }
        }

        private void gctAccountList_MouseClick(object sender, MouseEventArgs e)
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

        protected override void btsIsEnable_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
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
        private void loadRepositoryAccount()
        {
            rlokPersonnel.DataSource = clsAccount.Instance.getAllPersonnel();
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
        }

        private void loadData(int KeyID)
        {
            loadRepositoryAccount();
            gctAccountList.DataSource = clsAccount.Instance.searchAccount(base.isEnable);
            if (KeyID > 0)
                grvAccountList.FocusedRowHandle = grvAccountList.LocateByValue("IDPersonnel", KeyID);
        }

        private void insertEntry()
        {
            using (frmAccount _frm = new frmAccount())
            {
                _frm.Text = "Thêm mới tài khoản".Translation("ftxtAddAccount", _frm.Name); ;
                _frm.fType = eFormType.Add;
                _frm.ReLoadParent = this.loadData;
                _frm.ShowDialog();
            }
        }

        private void updateEntry()
        {
            if (grvAccountList.RowCount > 0 && grvAccountList.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmAccount _frm = new frmAccount())
                    {
                        xAccount _eEntry = (xAccount)grvAccountList.GetRow(grvAccountList.FocusedRowHandle);
                        _frm.iEntry = _eEntry;
                        _frm.Text = "Cập nhật tài khoản".Translation("ftxtUpdateAccount", _frm.Name);
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
            if (grvAccountList.RowCount > 0 && grvAccountList.FocusedRowHandle >= 0 && clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu".Translation("msgConfirmDelete", this.Name)))
            {
                try
                {
                    if (clsAccount.Instance.deleteEntry(((xAccount)grvAccountList.GetRow(grvAccountList.FocusedRowHandle)).IDPersonnel))
                    {
                        loadData(0);
                    }
                    else
                        clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgDeleteFailed", this.Name));

                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }

        private void refreshEntry()
        {
            loadData(0);
        }

        private void customForm()
        {
            gctAccountList.Format();

            lctAccountList.BestFitText();
        }
        #endregion
    }
}