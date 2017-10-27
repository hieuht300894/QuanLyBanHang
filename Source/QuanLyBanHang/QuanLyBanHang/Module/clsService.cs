using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyBanHang.Module
{
    public class clsService
    {
        public static Dictionary<string, BackgroundWorker> dThreads = new Dictionary<string, BackgroundWorker>();
        public static Dictionary<string, CancellationTokenSource> dManagerThreads = new Dictionary<string, CancellationTokenSource>();
        public static Dictionary<string, List<Control>> dControls = new Dictionary<string, List<Control>>();
    }
}
