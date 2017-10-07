using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EntityModel.DataModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmAgency : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        xAgency _acEntry;
        #endregion

        #region Form Events
        public frmAgency()
        {
            InitializeComponent();
        }

        private void frmAgency_Load(object sender, EventArgs e)
        {
            LoadAgeny();
            LoadData();
            CustomForm();
        }

        private void lokAgency_EditValueChanged(object sender, EventArgs e)
        {
            _acEntry = (xAgency)lokAgency.Properties.GetDataSourceRowByKeyValue(lokAgency.EditValue);
            SetControlValue();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _acEntry.Code = txtCode.Text.Trim();
            _acEntry.Name = txtName.Text.Trim();
            _acEntry.Address = txtAddress.Text.Trim();
            _acEntry.Phone = txtPhone.Text.Trim();
            _acEntry.Email = txtEmail.Text.Trim();
            _acEntry.Description = mmeDescription.Text.Trim();
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
            if (clsEntity.AccessAgency(_acEntry))
            {
                Properties.Settings.Default.IDAgency = _acEntry.KeyID;
                Properties.Settings.Default.Save();
                clsGeneral.curAgency = clsAgency.Instance.GetAgency(_acEntry.KeyID);
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void pteLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                //ofd.Filter = "Image|*.jpg|*.jpeg|*.bmp";
                ofd.Filter = "Image|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _acEntry.Logo = ResizeImage(ofd.FileName);
                    LoadImage(_acEntry.Logo);
                }
            }
        }
        #endregion

        #region Methods
        private void CustomForm()
        {
            lctAgency.Translation();
            lokAgency.Format();
            txtCode.NotUnicode(true, true);
            //txtName.IsPersonName();
            txtPhone.PhoneOnly();
            lctAgency.BestFitFormHeight();
            lctAgency.BestFitText();
            this.CenterToScreen();
        }

        private byte[] ResizeImage(string FilePath)
        {
            Image image = Image.FromFile(FilePath);
            int width = 240, height = 240;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            image.Dispose();
            return clsGeneral.imageToByteArray(destImage);
        }

        private void LoadAgeny()
        { 
            List<xAgency> lstAgency = clsEntity.GetAllAgency();
            lokAgency.Properties.DataSource = lstAgency;
            lokAgency.Properties.ValueMember = "KeyID";
            lokAgency.Properties.DisplayMember = "Name";
            lokAgency.ItemIndex = lstAgency.Count > 0 ? 1 : 0;
        }

        private void LoadData()
        {
            _acEntry = _acEntry ?? new xAgency();
            SetControlValue();
        }

        private void SetControlValue()
        {
            txtCode.Text = _acEntry.Code;
            txtName.Text = _acEntry.KeyID > 0 ? _acEntry.Name : "";
            txtAddress.Text = _acEntry.Address;
            txtPhone.Text = _acEntry.Phone;
            txtEmail.Text = _acEntry.Email;
            mmeDescription.Text = _acEntry.Description;
            LoadImage(_acEntry.Logo);
            if (lokAgency.ToInt() > 0)
                btnSave.Select();
            else
                txtCode.Select();
        }

        private void LoadImage(byte[] bLogo)
        {
            pteLogo.Image = clsGeneral.byteArrayToImage(bLogo);
        }
        #endregion
    }
}