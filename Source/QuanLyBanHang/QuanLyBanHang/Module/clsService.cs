using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyBanHang.Module
{
    public class clsService
    {
        public static Dictionary<string, BackgroundWorker> dThreads = new Dictionary<string, BackgroundWorker>();
        public static Dictionary<string, ThreadObject> dManageThreads = new Dictionary<string, ThreadObject>();
        public static Dictionary<string, List<ControlObject>> dManageControls = new Dictionary<string, List<ControlObject>>();
    }
    public class ThreadObject
    {
        public XtraForm frmMain { get; set; }
        public Control ctrMain { get; set; }
        public RepositoryItem repoMain { get; set; }
        public CancellationTokenSource TokenSource { get; set; }
        public IAsyncResult AsyncResult { get; set; }
    }
    public class ControlObject
    {
        public Control ctrMain { get; set; }
        public RepositoryItem repoMain { get; set; }
    }
}
