﻿using DevExpress.XtraTreeList.Nodes;
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

        private void trlFeature_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsAdd || e.Column == colIsEdit || e.Column == colIsDelete ||
                e.Column == colIsSave || e.Column == colIsPrintPreview || e.Column == colIsExportExcel)
            {
                List<TreeListNode> lstNode = new List<TreeListNode>();
                checkedNode(e.Node, (bool)e.Value);
                e.Node.SetValue(e.Column, e.Value);
            }
        }
        #endregion

        #region Base Button Events
        protected override void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validationForm())
            {
                if (saveData())
                    DialogResult = DialogResult.OK;
            }
        }
        protected override void btnSaveAndAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validationForm())
            {
                if (saveData())
                {
                    _iEntry = null;
                    loadDataForm();
                }
            }
        }
        protected override void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadDataForm();
        }
        #endregion

        #region Methods
        private void loadFeature()
        {
            trlFeature.Nodes.Clear();

            trlFeature.DataSource = clsFeature.Instance.SearchFeature(true);
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

            trlFeature.CellValueChanging -= trlFeature_CellValueChanging;
            loadFeature();
            //foreach (var usr in _acEntry.xUserFeatures.Where(n => n.IsEnable && !string.IsNullOrEmpty(n.IDFeature)))
            //{
            //    TreeListNode node = trlFeature.FindNodeByKeyID(usr.IDFeature);
            //    node.CheckState = CheckState.Checked;
            //    node.SetValue(colIsAdd, usr.IsAdd);
            //    node.SetValue(colIsEdit, usr.IsEdit);
            //    node.SetValue(colIsDelete, usr.IsDelete);
            //    node.SetValue(colIsSave, usr.IsSave);
            //    node.SetValue(colIsPrintPreview, usr.IsPrintPreview);
            //    node.SetValue(colIsExportExcel, usr.IsExportExcel);
            //}
            trlFeature.CellValueChanging += trlFeature_CellValueChanging;
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

        private bool validationForm()
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

        private bool saveData()
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

            //List<string> lstFeature = new List<string>();
            //trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n)).KeyID));

            //_acEntry.xUserFeatures.Where(n => !lstFeature.Contains(n.IDFeature)).ToList().ForEach(n => _acEntry.xUserFeatures.Remove(n));

            //foreach (string f in lstFeature)
            //{
            //    if (((f.StartsWith("frm") || f.StartsWith("bbi")) && !_acEntry.xUserFeatures.Any(n => n.IDFeature.Equals(f))))
            //        _acEntry.xUserFeatures.Add(new xUserFeature() { IDFeature = f });
            //}

            List<xFeature> lstFeature = new List<xFeature>();
            trlFeature.GetAllCheckedNodes().ForEach(n => lstFeature.Add(((xFeature)trlFeature.GetDataRecordByNode(n))));

           // _acEntry.xUserFeatures.ToList().ForEach(x => x.IsEnable = false);

            foreach (var fe in lstFeature)
            {
                //xUserFeature usr = _acEntry.xUserFeatures.FirstOrDefault(x => x.IDFeature.Equals(fe.KeyID)) ?? new xUserFeature();
                //usr.IsEnable = true;

                //if (fe.KeyID.StartsWith("bbi"))
                //{
                //    usr.IsAdd = true;
                //    usr.IsEdit = true;
                //    usr.IsDelete = true;
                //    usr.IsSave = true;
                //    usr.IsPrintPreview = true;
                //    usr.IsExportExcel = true;
                //}
                //else
                //{
                //    usr.IsAdd = fe.IsAdd;
                //    usr.IsEdit = fe.IsEdit;
                //    usr.IsDelete = fe.IsDelete;
                //    usr.IsSave = fe.IsSave;
                //    usr.IsPrintPreview = fe.IsPrintPreview;
                //    usr.IsExportExcel = fe.IsExportExcel;
                //}
                //if (usr.KeyID == 0)
                //{
                //    usr.IDFeature = fe.KeyID;
                //   // _acEntry.xUserFeatures.Add(usr);
                //}
            }

            chk = _acEntry.KeyID > 0 ? clsPermission.Instance.UpdateEntry(_acEntry) : clsPermission.Instance.InsertEntry(_acEntry);

            if (chk && ReloadData != null)
                ReloadData(_acEntry.KeyID);

            return chk;
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
            colIsPrintPreview.Visible = true;
            colIsExportExcel.Visible = true;

            trlFeature.CellValueChanging += trlFeature_CellValueChanging;
        }
        #endregion
    }
}