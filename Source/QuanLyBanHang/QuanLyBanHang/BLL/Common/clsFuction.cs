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
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL.Common
{
    public class clsFuction<T> : Function<T> where T : class, new()
    {
        public clsFuction(string FormName, string ControlName) : base(FormName, ControlName)
        {
        }
    }
}
