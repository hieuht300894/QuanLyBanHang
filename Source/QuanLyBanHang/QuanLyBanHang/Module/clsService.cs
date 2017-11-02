using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Module
{
    public class clsService
    {
        public static Dictionary<string, BackgroundWorker> dThreads = new Dictionary<string, BackgroundWorker>();
        public static Dictionary<string, List<ThreadObject>> dManageThreads = new Dictionary<string, List<ThreadObject>>();
        //public static Dictionary<string, List<ControlObject>> dManageControls = new Dictionary<string, List<ControlObject>>();
    }
    public class ThreadObject
    {
        public string Name { get; set; }
        public XtraForm FrmMain { get; set; }
        public Control CtrMain { get; set; }
        public RepositoryItem RepoMain { get; set; }
        public CancellationTokenSource TokenSource { get; set; }
        public Task Task { get; set; }
    }
    public class ControlObject
    {
        public Control ctrMain { get; set; }
        public RepositoryItem repoMain { get; set; }
    }
}
