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

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmBackupDatabase : Form
    {
        Server myServer = null;

        public frmBackupDatabase()
        {
            InitializeComponent();
        }

        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            CheckServer();
            if (myServer == null) return;

            FullDatabaseBackup();

        }

        private void CheckServer()
        {
            ServerConnection conn = new ServerConnection(EntityModel.Module.dbConnectString);
            Server myServer = new Server(conn);
        }

        private void FullDatabaseBackup()
        {
            Backup bkpDBFull = new Backup();
            /* Specify whether you want to back up database or files or log */
            bkpDBFull.Action = BackupActionType.Database;
            /* Specify the name of the database to back up */
            bkpDBFull.Database = myServer.Name;
            /* You can take backup on several media type (disk or tape), here I am
             * using File type and storing backup on the file system */
            bkpDBFull.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);
            bkpDBFull.BackupSetName = "Adventureworks database Backup";
            bkpDBFull.BackupSetDescription = "Adventureworks database - Full Backup";
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
            bkpDBFull.PercentComplete += CompletionStatusInPercent;
            bkpDBFull.Complete += Backup_Completed;

            /* SqlBackup method starts to take back up
             * You can also use SqlBackupAsync method to perform the backup 
             * operation asynchronously */
            bkpDBFull.SqlBackup(myServer);
        }
        private void DifferentialDatabaseBackup()
        {
            Backup bkpDBDifferential = new Backup();
            /* Specify whether you want to backup database, files or log */
            bkpDBDifferential.Action = BackupActionType.Database;
            /* Specify the name of the database to backup */
            bkpDBDifferential.Database = myServer.Name;
            /* You can issue backups on several media types (disk or tape), here I am * using the File type and storing the backup on the file system */
            bkpDBDifferential.Devices.AddDevice(@"D:\AdventureWorksDifferential.bak", DeviceType.File);
            bkpDBDifferential.BackupSetName = "Adventureworks database Backup";
            bkpDBDifferential.BackupSetDescription = "Adventureworks database - Differential Backup";
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
            bkpDBDifferential.PercentComplete += CompletionStatusInPercent;
            bkpDBDifferential.Complete += Backup_Completed;

            /* SqlBackup method starts to take back up
             * You cab also use SqlBackupAsync method to perform backup 
             * operation asynchronously */
            bkpDBDifferential.SqlBackup(myServer);
        }
        private void TransactionLogBackup()
        {
            Backup bkpDBLog = new Backup();
            /* Specify whether you want to back up database or files or log */
            bkpDBLog.Action = BackupActionType.Log;
            /* Specify the name of the database to back up */
            bkpDBLog.Database = myServer.Name;
            /* You can take backup on several media type (disk or tape), here I am
             * using File type and storing backup on the file system */
            bkpDBLog.Devices.AddDevice(@"D:\AdventureWorksLog.bak", DeviceType.File);
            bkpDBLog.BackupSetName = "Adventureworks database Backup";
            bkpDBLog.BackupSetDescription = "Adventureworks database - Log Backup";
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
            bkpDBLog.PercentComplete += CompletionStatusInPercent;
            bkpDBLog.Complete += Backup_Completed;

            /* SqlBackup method starts to take back up
             * You cab also use SqlBackupAsync method to perform backup 
             * operation asynchronously */
            bkpDBLog.SqlBackup(myServer);
        }

        private static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Percent completed: {0}%.", args.Percent);
        }
        private static void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Hurray...Backup completed.");
            Console.WriteLine(args.Error.Message);
        }
        private static void Restore_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Hurray...Restore completed.");
            Console.WriteLine(args.Error.Message);
        }
    }
}
