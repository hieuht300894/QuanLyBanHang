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
using EntityModel.DataModel;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Nodes;
using System.Data.Entity;
using QuanLyBanHang.BLL.PERS;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPermission : frmBase
    {
        #region Variables
        xPermission _acEntry;
        Timer tmMess;
        #endregion

        #region Form Events
        public frmPermission()
        {
            InitializeComponent();
        }

        private void frmPermission_Load(object sender, EventArgs e)
        {
            disableEdit();
            initCollection();
            loadData(0);
            customForm();
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMessage.Text))
            {
                tmMess = new Timer();
                tmMess.Interval = 5000;
                tmMess.Tick += tmMess_Tick;
                tmMess.Start();
            }
        }

        void tmMess_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tmMess.Stop();
        }

        private void trlFeature_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.CanCheck = !txtName.ReadOnly;
        }

        private void btnrSave_Click(object sender, EventArgs e)
        {
            _acEntry.Name = txtName.Text.Trim();
            _acEntry.Description = mmeDescription.Text.Trim();
            _acEntry.IDAgency = clsGeneral.curPersonnel.IDAgency;
            if (_acEntry.KeyID == 0)
            {
                _acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
            }
            try
            {
                //List<string> lstFeature = new List<string>();
                //trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n)).KeyID));

                //_acEntry.xUserFeatures.Where(n => !lstFeature.Contains(n.IDFeature)).ToList().ForEach(n => _acEntry.xUserFeatures.Remove(n));

                //foreach (string f in lstFeature)
                //{
                //    if (((f.StartsWith("frm") || f.StartsWith("bbi")) && !_acEntry.xUserFeatures.Any(n => n.IDFeature.Equals(f))))
                //        _acEntry.xUserFeatures.Add(new xUserFeature()
                //        {
                //            IDFeature = f
                //        });
                //}

                List<xFeature> lstFeature = new List<xFeature>();
                trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n))));

                _acEntry.xUserFeatures.ToList().ForEach(x => x.IsEnable = false);

                foreach (var fe in lstFeature)
                {
                    xUserFeature usr = _acEntry.xUserFeatures.FirstOrDefault(x => x.IDFeature.Equals(fe.KeyID)) ?? new xUserFeature();
                    usr.IsEnable = true;

                    if (fe.KeyID.StartsWith("bbi"))
                    {
                        usr.IsAdd = true;
                        usr.IsEdit = true;
                        usr.IsDelete = true;
                    }
                    else
                    {
                        usr.IsAdd = fe.IsAdd;
                        usr.IsEdit = fe.IsEdit;
                        usr.IsDelete = fe.IsDelete;
                    }
                    if (usr.KeyID == 0)
                    {
                        usr.IDFeature = fe.KeyID;
                        _acEntry.xUserFeatures.Add(usr);
                    }
                }

                if (clsPermission.Instance.accessEntry(_acEntry))
                {
                    disableEdit();
                    loadData(_acEntry.KeyID);
                    lblMessage.Text = "Lưu dữ liệu thành công".Translation("msgSaveSuccess", this.Name);
                }
                else
                {
                    lblMessage.Text = "Lưu dữ liệu không thành công!".Translation("msgSaveFailed", this.Name);
                }
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Exception");
            }
        }

        private void btnrCancel_Click(object sender, EventArgs e)
        {
            disableEdit();
            getRowEntry();
            setControlValue();
        }

        private void trlFeature_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsAdd || e.Column == colIsEdit || e.Column == colIsDelete)
            {
                List<TreeListNode> lstNode = new List<TreeListNode>();
                checkedNode(e.Node, (bool)e.Value);
                e.Node.SetValue(e.Column, e.Value);
            }
        }
        #endregion

        #region Grid Events
        private void grvUserRoleList_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvPermission.CalcHitInfo(mouse.Location);
            if (grvPermission.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                updateEntry();
            }
        }

        private void gctUserRoleList_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e);
        }

        private void grvUserRoleList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void grvPermission_Click(object sender, EventArgs e)
        {
            getRowEntry();
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
        private void insertEntry()
        {
            _acEntry = new xPermission() { IsEnable = true };
            setControlValue();
            enableEdit();
            txtName.Select();
        }

        private void updateEntry()
        {
            if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0)
            {
                xPermission eEntry = (xPermission)grvPermission.GetRow(grvPermission.FocusedRowHandle);
                _acEntry = clsPermission.Instance.getEntry(eEntry.KeyID);
                setControlValue();
                enableEdit();
                txtName.Select();
            }
        }

        private void deleteEntry()
        {
            if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0 && clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu".Translation("msgConfirmDelete", this.Name)))
            {
                try
                {
                    if (clsPermission.Instance.deleteEntry(((xPermission)grvPermission.GetRow(grvPermission.FocusedRowHandle)).KeyID))
                    {
                        loadData(0);
                    }
                    else
                        clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgDeleteFailed"));

                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Thông tin lỗi".Translation("msgException"));
                }
            }
        }

        private void refreshEntry()
        {
            loadData(0);
        }

        private void enableEdit()
        {
            if (_acEntry.KeyID == 0)
                dkpPermission.Text = "THÊM MỚI QUYỀN".Translation("capAddPermission", this.Name);
            else
                dkpPermission.Text = "CẬP NHẬT QUYỀN".Translation("capUpdatePermission", this.Name);

            txtName.ReadOnly = mmeDescription.ReadOnly = false;
            txtName.Properties.AllowFocused = mmeDescription.Properties.AllowFocused = false;
            txtName.TabStop = mmeDescription.TabStop = false;
            lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lciEmtySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void disableEdit()
        {
            dkpPermission.Text = "PHÂN QUYỀN".Translation("capPermission", this.Name);
            txtName.ReadOnly = mmeDescription.ReadOnly  = true;
            txtName.Properties.AllowFocused = mmeDescription.Properties.AllowFocused = true;
            txtName.TabStop = mmeDescription.TabStop = true;
            lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciEmtySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void loadNhanVien()
        {
            rlokPersonnel.DataSource = clsPermission.Instance.getAllPersonnel();
            rlokPersonnel.ValueMember = "KeyID";
            rlokPersonnel.DisplayMember = "FullName";
        }

        private void loadFeature()
        {
            trlFeature.Nodes.Clear();

            trlFeature.DataSource = clsPermission.Instance.getAllFeature();
            trlFeature.KeyFieldName = "KeyID";
            trlFeature.ParentFieldName = "IDGroup";
            if (Properties.Settings.Default.CurrentCulture.Equals("VN"))
            {
                colEN.Visible = false;
                colVN.Visible = true;
            }
            else
            {
                colEN.Visible = true;
                colVN.Visible = false;
            }

            colIsAdd.Visible = true;
            colIsEdit.Visible = true;
            colIsDelete.Visible = true;

            resetCheckedNodes();
        }

        private void initCollection()
        {
            loadFeature();
        }

        private void loadData(int KeyID)
        {
            loadNhanVien();
            gctPermission.DataSource = clsPermission.Instance.searchUserRole(true);
            if (KeyID > 0)
                grvPermission.FocusedRowHandle = grvPermission.LocateByValue("KeyID", KeyID);
        }

        private void getRowEntry()
        {
            if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0)
                _acEntry = (xPermission)grvPermission.GetRow(grvPermission.FocusedRowHandle);
            else
                _acEntry = new xPermission();
            disableEdit();
            setControlValue();
        }

        private void setControlValue()
        {
            txtName.Text = _acEntry.Name;
            mmeDescription.Text = _acEntry.Description;
            loadFeature();
            //if (_acEntry.xUserFeatures != null && _acEntry.xUserFeatures.Count() > 0)
            // _acEntry.xUserFeatures.Where(n => n.IsEnable && !string.IsNullOrEmpty(n.IDFeature)).ToList().ForEach(n => trlFeature.SetNodeCheckState(trlFeature.FindNodeByKeyID(n.IDFeature), CheckState.Checked, true));
            foreach (var usr in _acEntry.xUserFeatures.Where(n => n.IsEnable && !string.IsNullOrEmpty(n.IDFeature)))
            {
                TreeListNode node = trlFeature.FindNodeByKeyID(usr.IDFeature);
                node.CheckState = CheckState.Checked;
                node.SetValue(colIsAdd, usr.IsAdd);
                node.SetValue(colIsEdit, usr.IsEdit);
                node.SetValue(colIsDelete, usr.IsDelete);
            }
        }

        private void resetCheckedNodes()
        {
            trlFeature.GetNodeList().ToList().ForEach(x => x.CheckState = CheckState.Unchecked);
        }

        private void checkedNode(TreeListNode node, bool checkedVal)
        {
            foreach (TreeListNode _node in node.Nodes)
            {
                _node.SetValue(trlFeature.FocusedColumn, checkedVal);
                bool _checkedVal = checkedVal;
                checkedNode(_node, _checkedVal);
            }
        }

        private void customForm()
        {
            disableEdit();
            gctPermission.Format();
            trlFeature.Format(true, true);
            if (Properties.Settings.Default.CurrentCulture.Equals("VN"))
            {
                colEN.Visible = false;
                colVN.Visible = true;
            }
            else
            {
                colEN.Visible = true;
                colVN.Visible = false;
            }
            colIsAdd.Visible = true;
            colIsEdit.Visible = true;
            colIsDelete.Visible = true;

            trlFeature.OptionsBehavior.AllowIndeterminateCheckState = false;
            trlFeature.OptionsBehavior.AllowRecursiveNodeChecking = true;
            trlFeature.OptionsSelection.MultiSelect = false;
            trlFeature.OptionsView.ShowCheckBoxes = true;
            trlFeature.OptionsView.ShowCaption = true;

            lctPermission.Translation();
            btnrSave.Text = "Lưu lại".Translation("capSave");
            btnrCancel.Text = "Hủy bỏ".Translation("capCancel");

            lctPermission.BestFitText();
            lctRole.BestFitText();
        }
        #endregion
    }
}