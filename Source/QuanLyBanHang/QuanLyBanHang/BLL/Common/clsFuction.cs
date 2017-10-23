using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors.Repository;

namespace QuanLyBanHang.BLL.Common
{
    public class clsFuction
    {
        XtraForm frmMain;
        BarEditItem betPercent;
        Bar barBottom;
        AlertControl alertMsg;

        public static clsFuction Instance
        {
            get { return new clsFuction(frmMain, betPercent, barBottom, alertMsg); }
        }

        protected clsFuction(XtraForm frmMain, BarEditItem betPercent, Bar barBottom, AlertControl alertMsg)
        {
            this.frmMain = frmMain;
            this.betPercent = betPercent;
            this.barBottom = barBottom;
            this.alertMsg = alertMsg;
        }

        #region Delegate Method
        private void LoadPercent(int Percent)
        {
            betPercent.EditValue = Percent;
        }
        private void LoadMessage(string Msg)
        {
            clsGeneral.showMessage(Msg);
        }
        private void LoadError(Exception Ex)
        {
            clsGeneral.showErrorException(Ex);
        }
        private void OpenProgress()
        {
            Action action = () =>
            {
                barBottom.Visible = true;
                betPercent.EditValue = 0;
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            };
            frmMain.Invoke(action);
        }
        private void CloseProgress()
        {
            Action action = () =>
            {
                barBottom.Visible = false;
                betPercent.EditValue = 0;
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            };
            frmMain.Invoke(action);
        }
        private void ShowAlert(string Title = "", string Text = "")
        {
            alertMsg.Show(frmMain, Title, Text);
        }
        #endregion

        #region LoadData
        private void SetAction<T>(clsSelect<T> select, bool IsShowPercent, bool IsShowMessage, bool IsShowError) where T : class, new()
        {
            if (IsShowPercent)
            {
                select._OpenProgress = OpenProgress;
                select._CloseProgress = CloseProgress;
                select._ReloadPercent = LoadPercent;
            }
            if (IsShowMessage)
            {
                select._ReloadMessage = LoadMessage;
            }
            if (IsShowError)
            {
                select._ReloadError = LoadError;
            }
        }
        private void SetAction(clsCustomForm custom, bool IsShowPercent, bool IsShowMessage, bool IsShowError)
        {
            if (IsShowPercent)
            {
                custom._OpenProgress = OpenProgress;
                custom._CloseProgress = CloseProgress;
                custom.ReloadPercent = LoadPercent;
            }
            if (IsShowMessage)
            {
                custom.ReloadMessage = LoadMessage;
            }
            if (IsShowError)
            {
                custom.ReloadError = LoadError;
            }
        }

        public void LoadData<T>(int KeyID, GridControl gctMain, IList<T> ListData, Dictionary<string, object> dValueFrom, Dictionary<string, object> dValueTo, bool IsShowPercent = false, bool IsShowMessage = false, bool IsShowError = false) where T : class, new()
        {
            gctMain.DataSource = ListData;

            clsSelect<T> select = new clsSelect<T>();
            select.Init();
            select.SetEntity(ListData);
            select.SetSearch(dValueFrom, dValueTo);
            SetAction(select, IsShowPercent, IsShowMessage, IsShowError);
            select._InsertObjectToList = AddData;
            select.StartRun();
        }
        public void LoadData<T>(int KeyID, LookUpEdit lokMain, IList<T> ListData, Dictionary<string, object> dValueFrom, Dictionary<string, object> dValueTo, bool IsShowPercent = false, bool IsShowMessage = false, bool IsShowError = false) where T : class, new()
        {
            lokMain.Properties.DataSource = ListData;

            clsSelect<T> select = new clsSelect<T>();
            select.Init();
            select.SetEntity(ListData);
            select.SetSearch(dValueFrom, dValueTo);
            SetAction(select, IsShowPercent, IsShowMessage, IsShowError);
            select._InsertObjectToList = AddData;
            select.StartRun();
        }
        public void LoadData<T>(int KeyID, RepositoryItemLookUpEdit rlokMain, IList<T> ListData, Dictionary<string, object> dValueFrom, Dictionary<string, object> dValueTo, bool IsShowPercent = false, bool IsShowMessage = false, bool IsShowError = false) where T : class, new()
        {
            rlokMain.DataSource = ListData;

            clsSelect<T> select = new clsSelect<T>();
            select.Init();
            select.SetEntity(ListData);
            select.SetSearch(dValueFrom, dValueTo);
            SetAction(select, IsShowPercent, IsShowMessage, IsShowError);
            select._InsertObjectToList = AddData;
            select.StartRun();
        }
        private void AddData<T>(T TObject, IList<T> ListData) where T : class, new()
        {
            Action action = () => { ListData.Add(TObject); };
            frmMain.Invoke(action);
        }
        #endregion
    }
}
