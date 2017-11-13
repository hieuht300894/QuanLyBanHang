﻿using EntityModel.DataModel;
using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.DanhMuc
{
    class clsKhachHang : clsFunction<eKhachHang>
    {
        #region Contructor
        protected clsKhachHang() { }
        public new static clsKhachHang Instance
        {
            get { return new clsKhachHang(); }
        }
        #endregion
    }
}
