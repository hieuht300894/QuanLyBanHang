using DevExpress.XtraEditors;
using QuanLyBanHang.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmBaseEdit : frmBase
    {
        #region Method
        public frmBaseEdit()
        {
            InitializeComponent();
        }
        #endregion

        #region override
        protected async override void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                bool res = await SaveData();
                if (res)
                    DialogResult = DialogResult.OK;
            }
        }
        protected async override void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                bool res = await SaveData();
                if (res)
                {
                    clsGeneral.showMessage("Lưu dữ liệu thành công.");
                    fType = eFormType.Add;
                    Text = MsgAdd;
                    RenewData();
                    ResetControl();
                    LoadDataForm();
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu thất bại. Xin vui lòng thử lại.");
            }
        }
        protected override void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControl();
            LoadDataForm();
        }
        protected async override void bbpSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                bool res = await SaveData();
                if (res)
                    DialogResult = DialogResult.OK;
            }
        }
        protected async override void bbpSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
            {
                bool res = await SaveData();
                if (res)
                {
                    clsGeneral.showMessage("Lưu dữ liệu thành công.");
                    fType = eFormType.Add;
                    Text = MsgAdd;
                    RenewData();
                    ResetControl();
                    LoadDataForm();
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu thất bại. Xin vui lòng thử lại.");
            }
        }
        protected override void bbpCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControl();
            LoadDataForm();
        }
        #endregion

        #region Implement Method
        public virtual void LoadDataForm()
        {
        }
        public async virtual Task<bool> SaveData()
        {
            return await Task<bool>.Factory.StartNew(() => { return true; });
        }
        public virtual void SetControlValue()
        {
        }
        public virtual bool ValidationForm()
        {
            return true;
        }
        public virtual void RenewData()
        {
        }
        public virtual void ResetControl()
        {
            lstChildControls.ForEach(x =>
            {
                if (x.ctrMain != null)
                {
                    BaseEdit baseEdit = x.ctrMain as BaseEdit;
                    if (baseEdit != null)
                        baseEdit.DataBindings.Clear();
                }
            });
        }
        #endregion
    }
}
