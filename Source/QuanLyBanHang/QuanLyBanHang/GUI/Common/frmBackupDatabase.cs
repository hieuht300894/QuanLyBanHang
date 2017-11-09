using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmBackupDatabase : Form
    {
        #region Variable
        Server myServer = null;
        //string path = @"D:\TEST";
        #endregion

        #region Method
        public frmBackupDatabase()
        {
            InitializeComponent();
        }
        private void CheckServer()
        {
            bool _wAu = Properties.Settings.Default.sWinAu;
            string _sName = clsGeneral.Decrypt(Properties.Settings.Default.sServerName);
            string _sDatabase = clsGeneral.Decrypt(Properties.Settings.Default.sDBName);
            string _sUser = clsGeneral.Decrypt(Properties.Settings.Default.sUserName);
            string _sPass = clsGeneral.Decrypt(Properties.Settings.Default.sPassword);

            string _conString = "";
            if (_wAu)
                _conString = "data source={0};initial catalog={1};Integrated Security={2};";
            else
                _conString = "data source={0};initial catalog={1};Integrated Security={2};user id={3};password={4};";

            SqlConnection conn = new SqlConnection(string.Format(_conString, _sName, "master", _wAu, _sUser, _sPass));
            ServerConnection server = new ServerConnection();
            myServer = new Server(server);
        }
        #endregion

        #region Backup
        private void FullDatabaseBackup()
        {
            Backup bkpDBFull = new Backup();
            /* Specify whether you want to back up database or files or log */
            bkpDBFull.Action = BackupActionType.Database;
            /* Specify the name of the database to back up */
            bkpDBFull.Database = lokDB.Text;
            /* You can take backup on several media type (disk or tape), here I am
             * using File type and storing backup on the file system */
            bkpDBFull.Devices.AddDevice($@"{btePath.Text}\{ lokDB.Text}Full.bak", DeviceType.File);
            bkpDBFull.BackupSetName = $"{ lokDB.Text} database Backup";
            bkpDBFull.BackupSetDescription = $"{ lokDB.Text} database - Full Backup";
            /* You can specify the expiration date for your backup data
             * after that date backup data would not be relevant */
            bkpDBFull.ExpirationDate = DateTime.Now.ServerNow().AddYears(1);

            /* You can specify Initialize = false (default) to create a new 
             * backup set which will be appended as last backup set on the media. You
             * can specify Initialize = true to make the backup as first set on the
             * medium and to overwrite any other existing backup sets if the all the
             * backup sets have expired and specified backup set name matches with
             * the name on the medium */
            bkpDBFull.Initialize = false;

            /* Wiring up events for progress monitoring */
            bkpDBFull.PercentComplete += PercentComplete;
            bkpDBFull.Complete += (sender, e) => Completed(sender, e, "Backup");

            /* SqlBackup method starts to take back up
             * You can also use SqlBackupAsync method to perform the backup 
             * operation asynchronously */
            bkpDBFull.SqlBackupAsync(myServer);
        }
        private void DifferentialDatabaseBackup()
        {
            Backup bkpDBDifferential = new Backup();
            /* Specify whether you want to backup database, files or log */
            bkpDBDifferential.Action = BackupActionType.Database;
            /* Specify the name of the database to backup */
            bkpDBDifferential.Database = lokDB.Text;
            /* You can issue backups on several media types (disk or tape), here I am * using the File type and storing the backup on the file system */
            bkpDBDifferential.Devices.AddDevice($@"{btePath.Text}\{ lokDB.Text}Differential.bak", DeviceType.File);
            bkpDBDifferential.BackupSetName = $"{ lokDB.Text} database Backup";
            bkpDBDifferential.BackupSetDescription = $"{ lokDB.Text} database - Differential Backup";
            /* You can specify the expiration date for your backup data
             * after that date backup data would not be relevant */
            bkpDBDifferential.ExpirationDate = DateTime.Now.ServerNow().AddYears(1);

            /* You can specify Initialize = false (default) to create a new 
             * backup set which will be appended as last backup set on the media.
             * You can specify Initialize = true to make the backup as the first set
             * on the medium and to overwrite any other existing backup sets if the
             * backup sets have expired and specified backup set name matches
             * with the name on the medium */
            bkpDBDifferential.Initialize = false;

            /* You can specify Incremental = false (default) to perform full backup
             * or Incremental = true to perform differential backup since most recent
             * full backup */
            bkpDBDifferential.Incremental = true;

            /* Wiring up events for progress monitoring */
            bkpDBDifferential.PercentComplete += PercentComplete;
            bkpDBDifferential.Complete += (sender, e) => Completed(sender, e, "Backup");

            /* SqlBackup method starts to take back up
             * You cab also use SqlBackupAsync method to perform backup 
             * operation asynchronously */
            bkpDBDifferential.SqlBackupAsync(myServer);
        }
        private void TransactionLogBackup()
        {
            Backup bkpDBLog = new Backup();
            /* Specify whether you want to back up database or files or log */
            bkpDBLog.Action = BackupActionType.Log;
            /* Specify the name of the database to back up */
            bkpDBLog.Database = lokDB.Text;
            /* You can take backup on several media type (disk or tape), here I am
             * using File type and storing backup on the file system */
            bkpDBLog.Devices.AddDevice($@"{btePath.Text}\{ lokDB.Text}Log.bak", DeviceType.File);
            bkpDBLog.BackupSetName = $"{ lokDB.Text} database Backup";
            bkpDBLog.BackupSetDescription = $"{ lokDB.Text} database - Log Backup";
            /* You can specify the expiration date for your backup data
             * after that date backup data would not be relevant */
            bkpDBLog.ExpirationDate = DateTime.Now.ServerNow().AddYears(1);

            /* You can specify Initialize = false (default) to create a new 
             * backup set which will be appended as last backup set on the media. You
             * can specify Initialize = true to make the backup as first set on the
             * medium and to overwrite any other existing backup sets if the all the
             * backup sets have expired and specified backup set name matches with
             * the name on the medium */
            bkpDBLog.Initialize = false;

            /* Wiring up events for progress monitoring */
            bkpDBLog.PercentComplete += PercentComplete;
            bkpDBLog.Complete += (sender, e) => Completed(sender, e, "Backup");

            /* SqlBackup method starts to take back up
             * You cab also use SqlBackupAsync method to perform backup 
             * operation asynchronously */
            bkpDBLog.SqlBackupAsync(myServer);
        }
        private void CompressionBackup()
        {
            /* Apply for SQL 2008 */
            Backup bkpDBFullWithCompression = new Backup();

            /* Specify whether you want to back up database or files or log */
            bkpDBFullWithCompression.Action = BackupActionType.Database;

            /* Specify the name of the database to back up */
            bkpDBFullWithCompression.Database = lokDB.Text;

            /* You can use back up compression technique of SQL Server 2008,
             * specify CompressionOption property to On for compressed backup */
            bkpDBFullWithCompression.CompressionOption = BackupCompressionOptions.On;
            bkpDBFullWithCompression.Devices.AddDevice($@"{btePath.Text}\{ lokDB.Text}FullWithCompression.bak", DeviceType.File);
            bkpDBFullWithCompression.BackupSetName = $"{ lokDB.Text} database Backup";
            bkpDBFullWithCompression.BackupSetDescription = $"{ lokDB.Text} database - Full With Compression Backup";

            /* Wiring up events for progress monitoring */
            bkpDBFullWithCompression.PercentComplete += PercentComplete;
            bkpDBFullWithCompression.Complete += (sender, e) => Completed(sender, e, "Backup");

            /* SqlBackup method starts to take back up
          * You cab also use SqlBackupAsync method to perform backup 
          * operation asynchronously */
            bkpDBFullWithCompression.SqlBackupAsync(myServer);
        }
        #endregion

        #region Restore
        private void RestoreDatabase()
        {
            Restore restoreDB = new Restore();

            /* Specify whether you want to restore database or files or log etc */
            restoreDB.Action = RestoreActionType.Database;
            restoreDB.Devices.AddDevice($"{bteFile.Text}", DeviceType.File);
            DataTable dataTable = restoreDB.ReadBackupHeader(myServer);
            if (dataTable.Rows.Count > 0)
                restoreDB.Database = dataTable.Rows[0]["DatabaseName"].ToString();

            /* You can specify ReplaceDatabase = false (default) to not create a new image
             * of the database, the specified database must exist on SQL Server instance.
             * If you can specify ReplaceDatabase = true to create new database image 
             * regardless of the existence of specified database with same name */
            restoreDB.ReplaceDatabase = true;

            /* If you have differential or log restore to be followed, you would need
             * to specify NoRecovery = true, this will ensure no recovery is done after the 
             * restore and subsequent restores are allowed. It means it will database
             * in the Restoring state. */
            restoreDB.NoRecovery = false;

            /* Wiring up events for progress monitoring */
            restoreDB.PercentComplete += PercentComplete;
            restoreDB.Complete += (sender, e) => Completed(sender, e, "Restore");

            /* SqlRestore method starts to restore database
             * You cab also use SqlRestoreAsync method to perform restore 
             * operation asynchronously */
            restoreDB.SqlRestoreAsync(myServer);
        }
        private void RestoreDatabaseLog()
        {
            Restore restoreDBLog = new Restore();

            restoreDBLog.Action = RestoreActionType.Log;
            restoreDBLog.Devices.AddDevice($"{bteFile.Text}", DeviceType.File);
            DataTable dataTable = restoreDBLog.ReadBackupHeader(myServer);
            if (dataTable.Rows.Count > 0)
                restoreDBLog.Database = dataTable.Rows[0]["DatabaseName"].ToString();

            /* You can specify NoRecovery = false (default) so that transactions are
             * rolled forward and recovered. */
            restoreDBLog.NoRecovery = true;

            /* Wiring up events for progress monitoring */
            restoreDBLog.PercentComplete += PercentComplete;
            restoreDBLog.Complete += (sender, e) => Completed(sender, e, "Restore");

            /* SqlRestore method starts to restore database
             * You cab also use SqlRestoreAsync method to perform restore 
             * operation asynchronously */
            restoreDBLog.SqlRestoreAsync(myServer);
        }
        private void RestoreDatabaseWithDifferentNameAndLocation()
        {
            Restore restoreDB = new Restore();

            /* Specify whether you want to restore database or files or log etc */
            restoreDB.Action = RestoreActionType.Database;
            restoreDB.Devices.AddDevice($"{bteFile.Text}", DeviceType.File);
            DataTable dataTable = restoreDB.ReadBackupHeader(myServer);
            if (dataTable.Rows.Count > 0)
                restoreDB.Database = dataTable.Rows[0]["DatabaseName"].ToString() + "New";

            /* You can specify ReplaceDatabase = false (default) to not create a new image
             * of the database, the specified database must exist on SQL Server instance.
             * You can specify ReplaceDatabase = true to create new database image 
             * regardless of the existence of specified database with same name */
            restoreDB.ReplaceDatabase = true;

            /* If you have differential or log restore to be followed, you would need
             * to specify NoRecovery = true, this will ensure no recovery is done after the 
             * restore and subsequent restores are allowed. It means it will database
             * in the Restoring state. */
            restoreDB.NoRecovery = false;

            /* RelocateFiles collection allows you to specify the logical file names and 
             * physical file names (new locations) if you want to restore to a different location.*/
            restoreDB.RelocateFiles.Add(new RelocateFile($"{ lokDB.Text}_Data", $@"{btePath.Text}\{ lokDB.Text}New_Data.mdf"));
            restoreDB.RelocateFiles.Add(new RelocateFile($"{ lokDB.Text}_Log", $@"{btePath.Text}\{ lokDB.Text}New_Log.ldf"));

            /* Wiring up events for progress monitoring */
            restoreDB.PercentComplete += PercentComplete;
            restoreDB.Complete += (sender, e) => Completed(sender, e, "Restore");

            /* SqlRestore method starts to restore database
             * You cab also use SqlRestoreAsync method to perform restore 
             * operation asynchronously */
            restoreDB.SqlRestoreAsync(myServer);
        }
        #endregion

        #region Event
        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {
            CheckServer();
            if (myServer != null)
            {
                List<string> lstDB = new List<string>();
                for (int i = 0; i < myServer.Databases.Count; i++) { lstDB.Add(myServer.Databases[i].Name); }
                lokDB.Properties.DataSource = lstDB;
            }

            lokDB.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sDBName);
            lokDB.Format();
            rgFunction.EditValueChanged += rgFunction_EditValueChanged;
            bteFile.Properties.ButtonClick += bteFile_ButtonClick;
            btePath.Properties.ButtonClick += btePath_ButtonClick;
            lokDB.Properties.ButtonClick += lokDB_ButtonClick;
        }

        private void btePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                btePath.EditValue = dialog.SelectedPath;
        }

        private void lokDB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                CheckServer();
                if (myServer != null)
                {
                    List<string> lstDB = new List<string>();
                    for (int i = 0; i < myServer.Databases.Count; i++) { lstDB.Add(myServer.Databases[i].Name); }
                    lokDB.Properties.DataSource = lstDB;
                }
            }
        }

        private void bteFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
                bteFile.EditValue = dialog.FileName;
        }

        private void rgFunction_EditValueChanged(object sender, EventArgs e)
        {
            if ((int)rgFunction.EditValue == 1)
            {
                lciPath.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciBackup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciRestore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if ((int)rgFunction.EditValue == 2)
            {
                lciPath.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciBackup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciRestore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            lbMessage.Items.Clear();
            pgPercent.EditValue = 0;

            CheckServer();
            if (myServer == null) return;

            if ((int)rgFunction.EditValue == 1)
            {
                if ((int)rgMode.EditValue == 1)
                {
                    FullDatabaseBackup();
                }
                if ((int)rgMode.EditValue == 2)
                {
                    DifferentialDatabaseBackup();
                }
                if ((int)rgMode.EditValue == 3)
                {
                    TransactionLogBackup();
                }

            }
            if ((int)rgFunction.EditValue == 2)
            {
                if ((int)rgMode.EditValue == 1)
                {
                    RestoreDatabase();
                }
                if ((int)rgMode.EditValue == 2)
                {
                    RestoreDatabaseLog();
                }
                if ((int)rgMode.EditValue == 3)
                {
                    RestoreDatabaseWithDifferentNameAndLocation();
                }
            }

            //FullDatabaseBackup();
            //DifferentialDatabaseBackup();
            //TransactionLogBackup();
            //CompressionBackup();

            //RestoreDatabase();
            //RestoreDatabaseLog();
            //RestoreDatabaseWithDifferentNameAndLocation();
        }
        private void PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            pgPercent.Invoke(new Action<int>((value) => { pgPercent.EditValue = value; }), e.Percent);
            lbMessage.Invoke(new Action<string>((value) => { lbMessage.Items.Add(value); }), e.Message);
        }
        private void Completed(object sender, ServerMessageEventArgs e, string Function)
        {
            lbMessage.Invoke(new Action<string>((value) => { lbMessage.Items.Add(value); }), $"{Function} completed");
            lbMessage.Invoke(new Action<string>((value) => { lbMessage.Items.Add(value); }), e.Error.Message);
        }
        #endregion
    }
}
