using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPermission : frmBaseEdit
    {
        #region Variables
        public delegate void LoadData(object KeyID);
        public LoadData ReloadData;
        public xPermission _iEntry;
        xPermission _aEntry;
        IList<xUserFeature> lstUserFeatures = new List<xUserFeature>();
        #endregion

        #region Form Events
        public frmPermission()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadFeature();
            LoadDataForm();
            CustomForm();
        }
        private void trlFeature_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            trlFeature.CellValueChanging -= trlFeature_CellValueChanging;

            if (e.Column == colIsAdd || e.Column == colIsEdit || e.Column == colIsDelete ||
                e.Column == colIsSave || e.Column == colIsPrintPreview || e.Column == colIsExportExcel)
            {
                //List<TreeListNode> lstNode = new List<TreeListNode>();
                CheckedNode(e.Node, e.Column, (bool)e.Value);
                e.Node.SetValue(e.Column, e.Value);
            }

            trlFeature.CellValueChanging += trlFeature_CellValueChanging;
        }
        #endregion

        #region Methods
        private async void LoadFeature()
        {
            IList<xFeature> list = await clsFeature.Instance.SearchFeature(true);
            await RunMethodAsync(() =>
            {
                trlFeature.Nodes.Clear();
                trlFeature.DataSource = list;
                ResetCheckedNodes();
            });
        }
        private async void LoadUserFeature(int IDPermission)
        {
            lstUserFeatures = await clsUserRole.Instance.SearchUserFeature(IDPermission);
            await RunMethodAsync(() =>
            {
                trlFeature.CellValueChanging -= trlFeature_CellValueChanging;
                ResetCheckedNodes();
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

                foreach (TreeListColumn column in trlFeature.Columns)
                {
                    if (column == colIsAdd || column == colIsEdit || column == colIsDelete || column == colIsSave || column == colIsPrintPreview || column == colIsExportExcel)
                    {
                        foreach (var usr in lstUserFeatures)
                        {
                            TreeListNode node = trlFeature.FindNodeByKeyID(usr.IDFeature);
                            if (node != null)
                                CheckedNode(node, column, usr.IsEnable);
                        }
                    }
                }
                trlFeature.CellValueChanging += trlFeature_CellValueChanging;
            });
        }
        public override async void LoadDataForm()
        {
            _iEntry = _iEntry ?? new xPermission();
            _aEntry = await clsPermission.Instance.GetByID(_iEntry.KeyID);

            LoadUserFeature(_aEntry.KeyID);
            SetControlValue();
        }
        public override void SetControlValue()
        {
            txtName.DataBindings.Add("EditValue", _aEntry, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeDescription.DataBindings.Add("EditValue", _aEntry, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void ResetCheckedNodes()
        {
            await RunMethodAsync(() => { trlFeature.GetNodeList().ToList().ForEach(x => x.CheckState = CheckState.Unchecked); });
        }
        private void CheckedNode(TreeListNode node, TreeListColumn column, bool checkedVal)
        {
            foreach (TreeListNode _node in node.Nodes)
            {
                _node.SetValue(column, checkedVal);
                bool _checkedVal = checkedVal;
                CheckedNode(_node, column, _checkedVal);
            }
        }
        public override bool ValidationForm()
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
        public override async Task<bool> SaveData()
        {
            if (_aEntry.KeyID == 0)
            {
                _aEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
                _aEntry.IsEnable = true;
            }
            else
            {
                _aEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            List<xFeature> lstFeature = new List<xFeature>();
            trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n))));

            lstUserFeatures.ToList().ForEach(x => x.IsEnable = false);

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
                    usr.IDPermission = _aEntry.KeyID;
                    lstUserFeatures.Add(usr);
                }
            }

            bool chk = false;
            chk = await clsPermission.Instance.AddOrUpdate(_aEntry, lstUserFeatures.ToList());
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
        public override void RenewData()
        {
            _iEntry = _aEntry = null;
        }
        #endregion
    }
}