using DevExpress.XtraTreeList.Nodes;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPermission : frmBase
    {
        #region Variables
        public delegate void LoadData(int KeyID);
        public LoadData ReloadData;

        public xPermission _iEntry;
        xPermission _acEntry;
        List<xUserFeature> lstUserFeatures = new List<xUserFeature>();
        #endregion

        #region Form Events
        public frmPermission()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadDataForm();
            CustomForm();
        }
        private void trlFeature_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsAdd || e.Column == colIsEdit || e.Column == colIsDelete ||
                e.Column == colIsSave || e.Column == colIsPrintPreview || e.Column == colIsExportExcel)
            {
                List<TreeListNode> lstNode = new List<TreeListNode>();
                CheckedNode(e.Node, (bool)e.Value);
                e.Node.SetValue(e.Column, e.Value);
            }
        }
        #endregion

        #region Base Button Events
        protected override void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                if (SaveData())
                    DialogResult = DialogResult.OK;
            }
        }
        protected override void btnSaveAndAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                if (SaveData())
                {
                    _iEntry = null;
                    LoadDataForm();
                }
            }
        }
        protected override void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadDataForm();
        }
        #endregion

        #region Methods
        private void LoadFeature()
        {
            trlFeature.Nodes.Clear();

            List<xFeature> list = new List<xFeature>(clsFeature.Instance.SearchFeature(true));
            //list = list.Where(x => ((x.Level == 0 || x.Level == 1) && x.ItemCount > 0) || (x.Level == 2 && x.ItemCount == 0)).ToList();
            trlFeature.DataSource = list;
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
            colIsPrintPreview.Visible = true;
            colIsExportExcel.Visible = true;

            ResetCheckedNodes();
        }

        private void LoadUserFeature(int IDPermission)
        {
            lstUserFeatures = new List<xUserFeature>(clsUserRole.Instance.GetUserFeature(IDPermission));
        }

        private void LoadDataForm()
        {
            _iEntry = _iEntry ?? new xPermission();
            _acEntry = clsPermission.Instance.GetByID<xPermission>(_iEntry.KeyID);

            SetControlValue();
        }

        private void SetControlValue()
        {
            trlFeature.CellValueChanging -= trlFeature_CellValueChanging;

            txtName.Text = _acEntry.Name;
            mmeDescription.Text = _acEntry.Description;

            LoadFeature();
            LoadUserFeature(_acEntry.KeyID);

            foreach (var usr in lstUserFeatures)
            {
                TreeListNode node = trlFeature.FindNodeByKeyID(usr.IDFeature);
                if (node != null)
                {
                    node.CheckState = CheckState.Checked;
                    node.SetValue(colIsAdd, usr.IsAdd);
                    node.SetValue(colIsEdit, usr.IsEdit);
                    node.SetValue(colIsDelete, usr.IsDelete);
                    node.SetValue(colIsSave, usr.IsSave);
                    node.SetValue(colIsPrintPreview, usr.IsPrintPreview);
                    node.SetValue(colIsExportExcel, usr.IsExportExcel);
                }
            }

            trlFeature.CellValueChanging += trlFeature_CellValueChanging;
        }

        private void ResetCheckedNodes()
        {
            trlFeature.GetNodeList().ToList().ForEach(x => x.CheckState = CheckState.Unchecked);
        }

        private void CheckedNode(TreeListNode node, bool checkedVal)
        {
            foreach (TreeListNode _node in node.Nodes)
            {
                _node.SetValue(trlFeature.FocusedColumn, checkedVal);
                bool _checkedVal = checkedVal;
                CheckedNode(_node, _checkedVal);
            }
        }

        private bool ValidationForm()
        {
            bool chk = true;

            txtName.ErrorText = string.Empty;
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.ErrorText = "Tên quyền không để trống";
                chk = false;
            }
            return chk;
        }

        private bool SaveData()
        {
            bool chk = false;

            _acEntry.Name = txtName.Text.Trim();
            _acEntry.Description = mmeDescription.Text.Trim();

            if (_acEntry.KeyID == 0)
            {
                _acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
                _acEntry.IDAgency = clsGeneral.curPersonnel.IDAgency;
                _acEntry.IsEnable = true;
            }
            else
            {
                _acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            List<xFeature> lstFeature = new List<xFeature>();
            trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n))));

            lstUserFeatures.ForEach(x => x.IsEnable = false);

            foreach (var fe in lstFeature)
            {
                xUserFeature usr = lstUserFeatures.FirstOrDefault(x => x.IDFeature.Equals(fe.KeyID)) ?? new xUserFeature();
                usr.IsEnable = true;

                if (fe.KeyID.StartsWith("bbi"))
                {
                    usr.IsAdd = true;
                    usr.IsEdit = true;
                    usr.IsDelete = true;
                    usr.IsSave = true;
                    usr.IsPrintPreview = true;
                    usr.IsExportExcel = true;
                }
                else
                {
                    usr.IsAdd = fe.IsAdd;
                    usr.IsEdit = fe.IsEdit;
                    usr.IsDelete = fe.IsDelete;
                    usr.IsSave = fe.IsSave;
                    usr.IsPrintPreview = fe.IsPrintPreview;
                    usr.IsExportExcel = fe.IsExportExcel;
                }
                if (usr.KeyID == 0)
                {
                    usr.IDFeature = fe.KeyID;
                    usr.IDUserRole = _acEntry.KeyID;
                    lstUserFeatures.Add(usr);
                }
            }

            chk = clsPermission.Instance.AddOrUpdate(_acEntry, lstUserFeatures);

            if (chk && ReloadData != null)
                ReloadData(_acEntry.KeyID);

            return chk;
        }

        public override void CustomForm()
        {
            base.CustomForm();
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
            colIsPrintPreview.Visible = true;
            colIsExportExcel.Visible = true;

            trlFeature.CellValueChanging += trlFeature_CellValueChanging;
        }
        #endregion
    }
}