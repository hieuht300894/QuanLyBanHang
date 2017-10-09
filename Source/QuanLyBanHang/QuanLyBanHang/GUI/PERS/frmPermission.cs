using DevExpress.XtraTreeList.Nodes;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPermission : frmBase
    {
        #region Variables
        public delegate void LoadData(int KeyID);
        public LoadData ReloadData;

        public xPermission _iEntry;
        xPermission _acEntry;
        Timer tmMess;
        #endregion

        #region Form Events
        public frmPermission()
        {
            InitializeComponent();
        }

        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);

            loadDataForm();
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

                    //if (fe.KeyID.StartsWith("bbi"))
                    //{
                    //    usr.IsAdd = true;
                    //    usr.IsEdit = true;
                    //    usr.IsDelete = true;
                    //}
                    //else
                    //{
                    //    usr.IsAdd = fe.IsAdd;
                    //    usr.IsEdit = fe.IsEdit;
                    //    usr.IsDelete = fe.IsDelete;
                    //}
                    //if (usr.KeyID == 0)
                    //{
                    //    usr.IDFeature = fe.KeyID;
                    //    _acEntry.xUserFeatures.Add(usr);
                    //}
                }

                //if (clsPermission.Instance.accessEntry(_acEntry))
                //{
                //    disableEdit();
                //    //loadDataForm(_acEntry.KeyID);
                //    lblMessage.Text = "Lưu dữ liệu thành công".Translation("msgSaveSuccess", this.Name);
                //}
                //else
                //{
                //    lblMessage.Text = "Lưu dữ liệu không thành công!".Translation("msgSaveFailed", this.Name);
                //}
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Exception");
            }
        }

        private void btnrCancel_Click(object sender, EventArgs e)
        {
            disableEdit();
            setControlValue();
        }

        private void trlFeature_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsAdd || e.Column == colIsEdit || e.Column == colIsDelete ||
                e.Column == colIsSave || e.Column == colIsSaveAndAdd || e.Column == colIsCancel ||
                e.Column == colIsPrintPreview || e.Column == colIsExportExcel)
            {
                List<TreeListNode> lstNode = new List<TreeListNode>();
                checkedNode(e.Node, (bool)e.Value);
                e.Node.SetValue(e.Column, e.Value);
            }
        }
        #endregion

        #region Base Button Events
        #endregion

        #region Methods
        private void enableEdit()
        {
            //if (_acEntry.KeyID == 0)
            //    dkpPermission.Text = "THÊM MỚI QUYỀN".Translation("capAddPermission", this.Name);
            //else
            //    dkpPermission.Text = "CẬP NHẬT QUYỀN".Translation("capUpdatePermission", this.Name);

            //txtName.ReadOnly = mmeDescription.ReadOnly = false;
            //txtName.Properties.AllowFocused = mmeDescription.Properties.AllowFocused = false;
            //txtName.TabStop = mmeDescription.TabStop = false;
            //lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lciEmtySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void disableEdit()
        {
            //dkpPermission.Text = "PHÂN QUYỀN".Translation("capPermission", this.Name);
            //txtName.ReadOnly = mmeDescription.ReadOnly  = true;
            //txtName.Properties.AllowFocused = mmeDescription.Properties.AllowFocused = true;
            //txtName.TabStop = mmeDescription.TabStop = true;
            //lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //lciEmtySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void loadFeature()
        {
            trlFeature.Nodes.Clear();

            trlFeature.DataSource = clsFeature.Instance.Search(true);
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
            colIsSave.Visible = true;
            colIsSaveAndAdd.Visible = true;
            colIsCancel.Visible = true;
            colIsPrintPreview.Visible = true;
            colIsExportExcel.Visible = true;

            resetCheckedNodes();
        }

        private void loadDataForm()
        {
            _iEntry = _iEntry ?? new xPermission();
            _acEntry = clsPermission.Instance.GetEntry(_iEntry.KeyID);

            setControlValue();
        }

        private void setControlValue()
        {
            txtName.Text = _acEntry.Name;
            mmeDescription.Text = _acEntry.Description;

            loadFeature();
            foreach (var usr in _acEntry.xUserFeatures.Where(n => n.IsEnable && !string.IsNullOrEmpty(n.IDFeature)))
            {
                TreeListNode node = trlFeature.FindNodeByKeyID(usr.IDFeature);
                node.CheckState = CheckState.Checked;
                node.SetValue(colIsAdd, usr.IsAdd);
                node.SetValue(colIsEdit, usr.IsEdit);
                node.SetValue(colIsDelete, usr.IsDelete);
                node.SetValue(colIsSave, usr.IsSave);
                node.SetValue(colIsSaveAndAdd, usr.IsSaveAndAdd);
                node.SetValue(colIsCancel, usr.IsCancel);
                node.SetValue(colIsPrintPreview, usr.IsPrintPreview);
                node.SetValue(colIsExportExcel, usr.IsExportExcel);
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
            colIsSave.Visible = true;
            colIsSaveAndAdd.Visible = true;
            colIsCancel.Visible = true;
            colIsPrintPreview.Visible = true;
            colIsExportExcel.Visible = true;
        }
        #endregion
    }
}