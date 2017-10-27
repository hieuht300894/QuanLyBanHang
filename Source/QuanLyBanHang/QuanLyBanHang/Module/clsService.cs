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
        public static Dictionary<string, ThreadObject> dManagerThreads = new Dictionary<string, ThreadObject>();
        public static Dictionary<string, List<Control>> dControls = new Dictionary<string, List<Control>>();
    }
    public class ThreadObject
    {
        public XtraForm frmMain { get; set; }
        public Control ctrMain { get; set; }
        public RepositoryItem repoMain { get; set; }
        public CancellationTokenSource TokenSource { get; set; }
        public IAsyncResult AsyncResult { get; set; }
    }
}
