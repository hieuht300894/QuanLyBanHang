using DevExpress.XtraEditors;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmConfiguration : XtraForm
    {
        #region Variables
        xAgency _acEntry;
        #endregion

        #region Form
        public frmConfiguration()
        {
            InitializeComponent();
        }
        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            loadData();
            customForm();
        }
        #endregion

        #region Method
        private async void loadData()
        {
            _acEntry = await clsAgency.Instance.GetByID(Properties.Settings.Default.IDAgency);
            await Task.Factory.StartNew(() => { setControlValue(); });

        }
        private void setControlValue()
        {
            Invoke(new Action(() =>
            {
                if (_acEntry.KeyID > 0)
                {
                    lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    btnConfirm.Select();
                }
                else
                {
                    lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnSave.Select();
                }

                txt_Agency_Code.EditValue = _acEntry.Code;
                txt_Agency_Name.EditValue = _acEntry.Name;
                txt_Agency_Address.EditValue = _acEntry.Address;
                txt_Agency_Phone.EditValue = _acEntry.Phone;
                txt_Agency_Mail.EditValue = _acEntry.Email;
                mme_Agency_Note.EditValue = _acEntry.Description;

                picLogo.Image = clsGeneral.byteArrayToImage(_acEntry.Logo);
                if (picLogo.Image == null)
                    picLogo.Image = Properties.Resources.default_logo;
            }));
        }
        private async void saveData()
        {
            _acEntry.Code = txt_Agency_Code.Text.Trim();
            _acEntry.Name = txt_Agency_Name.Text.Trim();
            _acEntry.Address = txt_Agency_Address.Text.Trim();
            _acEntry.Phone = txt_Agency_Phone.Text.Trim();
            _acEntry.Email = txt_Agency_Mail.Text.Trim();
            _acEntry.Description = mme_Agency_Note.Text.Trim();
            _acEntry.Logo = clsGeneral.imageToByteArray(picLogo.Image);
            _acEntry.IsEnable = true;

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

            bool chk = false;
            chk = await clsAgency.Instance.AddOrUpdate(_acEntry);
            if (chk)
            {
                clsGeneral.curAgency = _acEntry;
                Properties.Settings.Default.IDAgency = clsGeneral.curAgency.KeyID;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                DialogResult = DialogResult.OK;
            }
        }
        private void customForm()
        {
            txt_Agency_Code.NotUnicode(true, true);
            txt_Agency_Phone.PhoneOnly();
            layoutControl1.Format();
        }
        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            clsGeneral.curAgency = _acEntry;
            DialogResult = DialogResult.OK;
        }
        private void picLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.JPEG;*.GIF)|*.BMP;*.PNG;*.JPG;*.JPEG;*.GIF";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(dialog.FileName);
                picLogo.Image = bitmap;
            }
        }
        #endregion
    }
}
