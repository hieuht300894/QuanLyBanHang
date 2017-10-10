using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace QuanLyBanHang
{
    public class clsCallForm
    {
        public static List<FormItem> fList = null;
        public static void InitFormCollection()
        {
            fList = new List<FormItem>();            
            try
            {
                System.Reflection.Assembly projectA = System.Reflection.Assembly.GetExecutingAssembly();
                foreach (Type t in projectA.GetTypes())
                {
                    if (t.BaseType == typeof(frmBase))
                    {
                        var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                        if (emptyCtor != null)
                        {
                            var f = (frmBase)emptyCtor.Invoke(new object[] { });
                            if (clsEntity.Check_Role(clsGeneral.curPersonnel.xAccount, f.Name))
                                fList.Add(new FormItem(f.Name, f));
                        }
                    }
                    else if (t.BaseType == typeof(XtraForm))
                    {
                        var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                        if (emptyCtor != null)
                        {
                            var f = (XtraForm)emptyCtor.Invoke(new object[] { });
                            if (clsEntity.Check_Role(clsGeneral.curPersonnel.xAccount, f.Name))
                                fList.Add(new FormItem(f.Name, f));
                        }
                    }
                    else if (t.BaseType == typeof(frmBaseGrid))
                    {
                        var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                        if (emptyCtor != null)
                        {
                            var f = (XtraForm)emptyCtor.Invoke(new object[] { });
                            if (clsEntity.Check_Role(clsGeneral.curPersonnel.xAccount, f.Name))
                                fList.Add(new FormItem(f.Name, f));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Exception");
            }
        }

        public static XtraForm CreateNewForm(string bbiName)
        {
            if (fList == null)
                return null;
            try
            {
                return fList.Find(f => f.BbiName.Equals(bbiName)).CForm;
            }
            catch { return null; }
        }
    }

    public class FormItem
    {
        string _bbiName;

        public string BbiName
        {
            get { return _bbiName; }
            set { _bbiName = value; }
        }
        XtraForm _cForm;
        Type _fType;

        public FormItem(string bbiName, XtraForm frmIn)
        {
            this._bbiName = bbiName;
            this._cForm = frmIn;
            this._fType = frmIn.GetType();
        }
        public XtraForm CForm
        {
            get
            {
                if (_cForm == null || !_cForm.IsHandleCreated)
                {
                    _cForm = (XtraForm)Activator.CreateInstance(_fType);
                }
                return _cForm;
            }
            set { _cForm = value; }
        }
    }
}
