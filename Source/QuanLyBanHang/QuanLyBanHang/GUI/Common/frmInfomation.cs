using DevExpress.XtraEditors;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
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
    public partial class frmInfomation : XtraForm
    {
        #region Variables
        public delegate void LoadData();
        public LoadData ReloadData;
        xAgency _acEntry;
        #endregion

        #region Form
        public frmInfomation()
        {
            InitializeComponent();
        }

        private void frmInfomation_Load(object sender, EventArgs e)
        {
            loadData();
            customForm();
        }
        #endregion

        #region Method
        private void loadAgency()
        {
            lokAgency.EditValue = null;

            List<xAgency> lst = clsAgency.Instance.GetAllAgency();
            lokAgency.Properties.DataSource = lst;
            lokAgency.Properties.ValueMember = "KeyID";
            lokAgency.Properties.DisplayMember = "Name";

            if (Properties.Settings.Default.IDAgency > 0)
                lokAgency.EditValue = Properties.Settings.Default.IDAgency;
            else if (lst.Any(x => x.KeyID > 0))
                lokAgency.ItemIndex = lst.FindIndex(x => x.KeyID > 0);
            else
                lokAgency.ItemIndex = 0;
        }

        private void loadData()
        {
            _acEntry = _acEntry ?? new xAgency();
            loadAgency();
            setControlValue();
        }

        private void setControlValue()
        {
            txt_Agency_Code.EditValue = _acEntry.Code;
            txt_Agency_Name.EditValue = _acEntry.KeyID > 0 ? _acEntry.Name : "";
            txt_Agency_Address.EditValue = _acEntry.Address;
            txt_Agency_Phone.EditValue = _acEntry.Phone;
            txt_Agency_Mail.EditValue = _acEntry.Email;
            mme_Agency_Note.EditValue = _acEntry.Description;
            if (lokAgency.ToInt() > 0)
                btnSave.Select();
            else
                txt_Agency_Code.Select();
        }

        private void saveData()
        {
            _acEntry.Code = txt_Agency_Code.Text.Trim();
            _acEntry.Name = txt_Agency_Name.Text.Trim();
            _acEntry.Address = txt_Agency_Address.Text.Trim();
            _acEntry.Phone = txt_Agency_Phone.Text.Trim();
            _acEntry.Email = txt_Agency_Mail.Text.Trim();
            _acEntry.Description = mme_Agency_Note.Text.Trim();
            _acEntry.IsEnable = true;

            if (_acEntry.KeyID == 0)
            {
                _acEntry.CreatedBy = 0;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _acEntry.ModifiedBy = 0;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
            }
            if (clsAgency.Instance.accessEntry(_acEntry))
            {
                clsGeneral.curAgency = clsAgency.Instance.GetAgency(_acEntry.KeyID);
                Properties.Settings.Default.IDAgency = clsGeneral.curAgency.KeyID;
                //Properties.Settings.Default.IsConfigAgency = true;
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            if (ReloadData != null)
            {
                this.DialogResult = DialogResult.OK;
                ReloadData();
            }
            Application.Restart();
        }

        private void customForm()
        {
            lokAgency.Format(false);
            txt_Agency_Code.NotUnicode(true, true);
            txt_Agency_Phone.PhoneOnly();

            layoutControl1.BestFitText();
        }
        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void lokAgency_EditValueChanged(object sender, EventArgs e)
        {
            if (lokAgency.EditValue != null)
                _acEntry = (xAgency)lokAgency.Properties.GetDataSourceRowByKeyValue(lokAgency.EditValue);
            setControlValue();
        }
        #endregion
    }
}
