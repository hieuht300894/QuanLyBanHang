using System;
using System.Collections.Generic;
using System.Linq;
using EntityModel.DataModel;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.Utils;
using System.Drawing;
using System.Data.Entity.Migrations;

namespace QuanLyBanHang
{

    public static class TranslateDictionary
    {
        #region String Translation

        public static string curCulture
        {
            get
            {
                Properties.Settings.Default.Reload();
                return Properties.Settings.Default.CurrentCulture;
            }
        }

        public static string curDateFormat
        {
            get
            {
                Properties.Settings.Default.Reload();
                return Properties.Settings.Default.DateFormat;
            }
        }
        public static string Translation(this string stIn, string mName, string fName = "")
        {
            return stIn;

            //Get Method Name
            //System.Diagnostics.StackTrace _sTrace = new System.Diagnostics.StackTrace();
            //using (System.IO.Stream myFile = new System.IO.FileStream("Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write))
            //{
            //    using (System.IO.StreamWriter wr = new System.IO.StreamWriter(myFile))
            //    {
            //        foreach (System.Diagnostics.StackFrame iF in _sTrace.GetFrames().Where(n => n.GetMethod().DeclaringType.BaseType == typeof(System.Windows.Forms.Form) || n.GetMethod().DeclaringType.BaseType == typeof(DevExpress.XtraEditors.XtraForm)))
            //        {
            //            var d = iF.GetType();
            //            var g = iF.GetMethod().DeclaringType;
            //            string j = g.Name;
            //            string line = string.Format("{0}: {1}|{2}", j, stIn, mName);
            //            wr.WriteLine(line);
            //            wr.Flush();
            //        }
            //    }
            //}

            //if (string.IsNullOrEmpty(fName) || fName.ToUpper().Equals("DEFAULT"))
            //{
            //    try
            //    {
            //        string stRe = "";
            //        if (Properties.Settings.Default.CurrentCulture.Equals("VN"))
            //            stRe = MultiLanguage.VN.ResourceManager.GetString(mName);
            //        else
            //            stRe = MultiLanguage.EN.ResourceManager.GetString(mName);
            //        return !string.IsNullOrEmpty(stRe) ? stRe : stIn;
            //    }
            //    catch { return stIn; }
            //}
            //else
            //{
            //    bool isAdd = false;
            //    string stRe = "";
            //    try
            //    {
            //        db = new aModel();
            //        var msgDic = db.xMsgDictionary.FirstOrDefault<xMsgDictionary>(m => m.FormName.Equals(fName) && m.MsgName.Equals(mName));
            //        if (msgDic != null)
            //            stRe = msgDic.GetStringByName(curCulture);
            //        else
            //            isAdd = true;
            //    }
            //    catch { }
            //    finally
            //    {
            //        if (isAdd || string.IsNullOrEmpty(stRe))
            //        {
            //            db = new aModel();
            //            xMsgDictionary _nMsg = new xMsgDictionary();
            //            _nMsg.FormName = fName;
            //            _nMsg.MsgName = mName;
            //            if (string.IsNullOrEmpty(stIn))
            //                stIn = fName;
            //            _nMsg.VN = stIn;
            //            _nMsg.EN = mName.AutoSpace();
            //            if (!db.xMsgDictionary.Any(m => m.FormName.Equals(_nMsg.FormName) && m.MsgName.Equals(_nMsg.MsgName)))
            //            {
            //                db.xMsgDictionary.AddOrUpdate(_nMsg);
            //                db.SaveChanges();
            //            }
            //            stRe = _nMsg.GetStringByName(curCulture);
            //        }
            //    }
            //    return stRe;
            //}
        }
        #endregion

        #region LayoutControl Translation
        //static List<LayoutControlGroup> lstGroupItem = null;
        //static List<LayoutControlItem> lstItem = null;

        //private static void ProcessLayoutControlGroup(LayoutControlGroup group)
        //{
        //    lstGroupItem.Add(group);
        //    foreach (var item in group.Items)
        //    {
        //        if (item is LayoutControlGroup)
        //            ProcessLayoutControlGroup((LayoutControlGroup)item);
        //        if (item is TabbedControlGroup)
        //            ProcessTabbedGroup((TabbedControlGroup)item);
        //        if (item is LayoutControlItem)
        //            ProcessLayoutControlItem(((LayoutControlItem)item));
        //    }
        //}

        //private static void ProcessTabbedGroup(TabbedControlGroup group)
        //{
        //    foreach (LayoutControlGroup page in group.TabPages)
        //        ProcessLayoutControlGroup(page);
        //}

        //private static void ProcessLayoutControlItem(LayoutControlItem item)
        //{
        //    lstItem.Add(item);
        //}

        //private static void setCaptionGroup(string FormName, string lctName, LayoutControlGroup gItem)
        //{
        //    //xLayoutItemCaption _cCaption = null;
        //    try
        //    {
        //        //if (db.xLayoutItemCaptions.Any(n => n.FormName.Equals(FormName) && n.LayoutControlItem.Equals(gItem.Name)))
        //        //    _cCaption = db.xLayoutItemCaptions.FirstOrDefault<xLayoutItemCaption>(n => n.FormName.Equals(FormName) && n.LayoutControlItem.Equals(gItem.Name));
        //        //else
        //        //{
        //        //    _cCaption = new xLayoutItemCaption();
        //        //    _cCaption.FormName = FormName;
        //        //    _cCaption.LayoutControlName = lctName;
        //        //    _cCaption.LayoutControlItem = gItem.Name;
        //        //    _cCaption.VN = gItem.Text;
        //        //    _cCaption.EN = gItem.Name.AutoSpace();
        //        //    _cCaption.Visibility = gItem.Visibility.ToString();
        //        //    _cCaption.TextVisible = gItem.TextVisible;
        //        //    _cCaption.TextLocation = gItem.TextLocation.ToString();
        //        //    _cCaption.ControlAlignment = "NotSet";
        //        //    if (!db.xLayoutItemCaptions.Any(n => n.FormName.Equals(FormName) && n.LayoutControlName.Equals(lctName) && n.LayoutControlItem.Equals(gItem.Name)))
        //        //    {
        //        //        db.xLayoutItemCaptions.AddOrUpdate(_cCaption);
        //        //        db.SaveChanges();
        //        //    }
        //        //}
        //        //if (_cCaption != null)
        //        //    SetCaption(gItem, _cCaption);
        //    }
        //    catch { }
        //}

        //private static void SetCaption(LayoutControlGroup gItem, xLayoutItemCaption _Caption)
        //{
        //    string iText = _Caption.GetStringByName(curCulture);
        //    if (string.IsNullOrEmpty(iText))
        //    {
        //        if (curCulture.Equals("EN"))
        //            iText = gItem.Name.AutoSpace();
        //        else
        //            iText = gItem.Text;
        //    }
        //    gItem.Text = iText;
        //    gItem.Visibility = (LayoutVisibility)Enum.Parse(typeof(LayoutVisibility), _Caption.Visibility);
        //    gItem.TextVisible = _Caption.TextVisible;
        //    gItem.TextLocation = (Locations)Enum.Parse(typeof(Locations), _Caption.TextLocation);
        //}

        //private static void setCaptionItem(string FormName, string lctName, LayoutControlItem iItem)
        //{
        //    //xLayoutItemCaption _cCaption = null;
        //    try
        //    {
        //        //if (db.xLayoutItemCaptions.Any(n => n.FormName.Equals(FormName) && n.LayoutControlItem.Equals(iItem.Name)))
        //        //    _cCaption = db.xLayoutItemCaptions.FirstOrDefault<xLayoutItemCaption>(n => n.FormName.Equals(FormName) && n.LayoutControlItem.Equals(iItem.Name));
        //        //else
        //        //{
        //        //    _cCaption = new xLayoutItemCaption();
        //        //    _cCaption.FormName = FormName;
        //        //    _cCaption.LayoutControlName = lctName;
        //        //    _cCaption.LayoutControlItem = iItem.Name;
        //        //    _cCaption.VN = iItem.Text;
        //        //    _cCaption.EN = iItem.Name.Replace("_List", "").AutoSpace();
        //        //    _cCaption.Visibility = iItem.Visibility.ToString();
        //        //    _cCaption.TextVisible = iItem.TextVisible;
        //        //    _cCaption.TextLocation = iItem.TextLocation.ToString();
        //        //    _cCaption.ControlAlignment = iItem.ControlAlignment.ToString();

        //        //    if (!db.xLayoutItemCaptions.Any(n => n.FormName.Equals(FormName) && n.LayoutControlName.Equals(lctName) && n.LayoutControlItem.Equals(iItem.Name)))
        //        //    {
        //        //        db.xLayoutItemCaptions.Add(_cCaption);
        //        //        db.SaveChanges();
        //        //    }
        //        //}
        //        //if (_cCaption != null)
        //        //    SetCaption(iItem, _cCaption);
        //    }
        //    catch { }
        //}

        //private static void SetCaption(LayoutControlItem iItem, xLayoutItemCaption lciCaption)
        //{
        //    string iText = lciCaption.GetStringByName(curCulture);
        //    if (string.IsNullOrEmpty(iText))
        //    {
        //        if (curCulture.Equals("EN"))
        //            iText = iItem.Name.Replace("_List", "").AutoSpace();
        //        else
        //            iText = iItem.Text;
        //    }
        //    iItem.Text = iText;
        //    iItem.Visibility = (LayoutVisibility)Enum.Parse(typeof(LayoutVisibility), lciCaption.Visibility);
        //    iItem.TextVisible = lciCaption.TextVisible;
        //    iItem.TextLocation = (Locations)Enum.Parse(typeof(Locations), lciCaption.TextLocation);
        //    iItem.ControlAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), lciCaption.ControlAlignment);
        //}
        #endregion
    }
}