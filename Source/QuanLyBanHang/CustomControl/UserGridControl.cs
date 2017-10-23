using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace CustomControl
{
    [ToolboxItem(true)]
    public partial class UserGridControl : UserControl
    {
        private bool _IsLoadingData;
        public bool IsLoadingData { get { return _IsLoadingData; } }
        public GridControl GridControl { get { return gctMain; } }
        public GridView GridView { get { return grvMain; } }

        public void SetLoading(bool Value)
        {
            _IsLoadingData = Value;
        }

        public UserGridControl()
        {
            InitializeComponent();
        }
    }
}
