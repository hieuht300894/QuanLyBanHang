using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Module
{
    public class clsService
    {
        public static Dictionary<string, BackgroundWorker> dThreads = new Dictionary<string, BackgroundWorker>();
        public static Dictionary<string, List<Control>> dControls = new Dictionary<string, List<Control>>();
    }
}
