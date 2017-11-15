using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using EntityModel.DataModel.HeThong;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public class MyColor
    {
        public static Color GridDefaultRow { get { return Color.FromArgb(75, 145, 200); } }
        public static Color GridEditRow { get { return Color.FromArgb(75, 145, 200); } }
        public static Color GridForeHeader { get { return Color.FromArgb(0, 0, 10); } }
        public static Color GridForeRow { get { return Color.White; } }
        //public static Color BackColorEditing { get { return Color.FromArgb(232, 202, 200); } }
        public static Color BackColorEditing { get { return Color.White; } }
        public static Color ForeColorEditing { get { return Color.FromArgb(0, 0, 70); } }
    }

    public static class clsFormatControl
    {
        #region Variables
        public static string curDecimalFormat
        {
            get
            {
                Properties.Settings.Default.Reload();
                return Properties.Settings.Default.DecimalFormat;
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

        public static string curCulture
        {
            get
            {
                Properties.Settings.Default.Reload();
                return Properties.Settings.Default.CurrentCulture;
            }
        }

        static readonly string[] ChuSo = { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        static readonly string[] Tien = { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        #endregion

        #region Contructor
        #endregion

        #region Extension DataType
        public static string ToTitleCase(this string sSource)
        {
            while (sSource.Contains("  "))
                sSource = sSource.Replace("  ", " ");
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sSource.ToLower());
        }

        public static string AutoSpace(this string sSource)
        {
            string stRe = "";
            if (!string.IsNullOrEmpty(sSource.Replace(" ", "").Trim()))
            {
                System.Text.RegularExpressions.Regex rgxUpperLeter = new System.Text.RegularExpressions.Regex("[A-Z]");
                Char[] arrS = sSource.Replace(" ", "").ToCharArray();
                Array.Reverse(arrS);
                foreach (char arC in arrS)
                {
                    if (rgxUpperLeter.IsMatch(arC.ToString())) //Is UpperCase
                    {
                        System.Text.RegularExpressions.Regex rgxCheck = new System.Text.RegularExpressions.Regex("[A-Z][a-z]");
                        if (!string.IsNullOrEmpty(stRe) && stRe.Length > 1)
                        {
                            if (rgxUpperLeter.IsMatch(stRe.Substring(0, 1)) && rgxCheck.IsMatch(stRe.Substring(0, 2)) && !stRe.Substring(0, 2).EndsWith(" "))
                                stRe = stRe.Insert(0, arC.ToString() + " ");
                            else
                                stRe = stRe.Insert(0, arC.ToString());
                        }
                        else
                            stRe = stRe.Insert(0, arC.ToString());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(stRe) && rgxUpperLeter.IsMatch(stRe.Substring(0, 1)))
                            stRe = stRe.Insert(0, arC.ToString() + " ");
                        else
                            stRe = stRe.Insert(0, arC.ToString());
                    }
                }
            }
            if (!string.IsNullOrEmpty(stRe) && stRe.Contains(" "))
            {
                System.Text.RegularExpressions.Regex rgxSuffic = new System.Text.RegularExpressions.Regex("[A-Z]");
                if (!rgxSuffic.IsMatch(stRe.Substring(0, stRe.IndexOf(" "))))
                    stRe = stRe.Remove(0, stRe.IndexOf(" "));
            }

            return stRe.Trim();
        }

        public static string NoSign(this string sSource)
        {
            if (string.IsNullOrEmpty(sSource)) return string.Empty;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = sSource.Normalize(NormalizationForm.FormD);
            string nameNosign = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return nameNosign;
        }

        // Hàm đọc số thành chữ
        // Hàm đọc số có 3 chữ số
        static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                        KetQua += " mốt";
                    else
                        KetQua += ChuSo[donvi];
                    break;
                case 5:
                    if (chuc == 0)
                        KetQua += ChuSo[donvi];
                    else
                        KetQua += " lăm";
                    break;
                default:
                    if (donvi != 0)
                        KetQua += ChuSo[donvi];
                    break;
            }
            return KetQua;
        }
        public static string ToMoneyText(this decimal Money, string Tail = "đồng")
        {
            int lan, i;
            decimal so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (Money < 0) return "Số tiền âm!";
            if (Money == 0) return string.Format("Không {0}!", Tail.Trim());
            if (Money > 0)
                so = Money;
            else
                so = -Money;
            //Kiểm tra số quá lớn
            if (Money > 8999999999999999)
            {
                Money = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
                lan = 5;
            else if (ViTri[4] > 0)
                lan = 4;
            else if (ViTri[3] > 0)
                lan = 3;
            else if (ViTri[2] > 0)
                lan = 2;
            else if (ViTri[1] > 0)
                lan = 1;
            else
                lan = 0;
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + " " + Tail.Trim();
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        public static string ToMoneyText(this double Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this long Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this float Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this int Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }

        public static int MaxIndex<T>(this IEnumerable<T> source)
        {
            try { return source.LastOrDefault().GetInt32ByName("KeyID"); }
            catch { return 0; }
        }
        #endregion

        #region Language Display LayoutControl

        #endregion

        #region FormatControl
        #region LayoutControl
        public static void BestFitFormHeight(this LayoutControl lctMain)
        {
            int pHeight = lctMain.FindForm().Height + 3;
            int lHeight = lctMain.Height;
            int BestFitHeight = lctMain.Root.MinSize.Height + pHeight - lHeight;
            lctMain.FindForm().Height = BestFitHeight;
        }

        public static void Format(this LayoutControl lctMain)
        {
            lctMain.Appearance.DisabledLayoutItem.Options.UseFont = true;
            lctMain.Appearance.DisabledLayoutItem.ForeColor = Color.Black;

            lctMain.Appearance.ControlDisabled.Options.UseForeColor = true;
            lctMain.Appearance.ControlDisabled.ForeColor = Color.Black;

            lctMain.Appearance.Control.Options.UseForeColor = true;
            lctMain.Appearance.Control.ForeColor = Color.Black;

            foreach (var item in lctMain.Items)
            {
                if (item is LayoutControlGroup)
                {
                    LayoutControlGroup lcg = item as LayoutControlGroup;
                    lcg.OptionsItemText.TextAlignMode = TextAlignModeGroup.AlignWithChildren;
                }
                if (item is LayoutControlItem)
                {
                    LayoutControlItem lci = item as LayoutControlItem;
                    lci.AppearanceItemCaption.Options.UseForeColor = true;
                    lci.AppearanceItemCaption.ForeColor = Color.Black;
                }
            }
            foreach (Control _ctr in lctMain.Controls)
            {
                BaseEdit baseEdit = _ctr as BaseEdit;
                if (baseEdit != null)
                {
                    if (baseEdit is TreeListLookUpEdit) { }
                    else
                    {
                        baseEdit.LookAndFeel.Style = LookAndFeelStyle.Office2003;
                        baseEdit.LookAndFeel.UseDefaultLookAndFeel = false;
                    }

                }
            }
        }
        #endregion

        #region FormatTextEdit
        public static void Format(this TextEdit txtMain)
        {
            //New
            txtMain.Properties.MaxLength = 255;
            if (txtMain.Name.Contains("Code"))
                txtMain.Properties.MaxLength = 50;
            if (txtMain.Name.Contains("Name"))
                txtMain.Properties.MaxLength = 100;
        }

        public static void NotUnicode(this TextEdit txtMain, bool NoSpace = false, bool? AutoUperCase = null)
        {
            if (AutoUperCase.HasValue)
                txtMain.Properties.CharacterCasing = AutoUperCase.Value ? CharacterCasing.Upper : CharacterCasing.Lower;
            txtMain.KeyUp -= NotUnicode_KeyUp;
            txtMain.KeyUp += NotUnicode_KeyUp;
            if (NoSpace)
            {
                txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                txtMain.Properties.Mask.EditMask = "[a-zA-Z0-9\\-\\_]+";
            }
        }

        public static void NumberOnly(this TextEdit txtMain)
        {
            txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtMain.Properties.Mask.EditMask = "[0-9]+";
        }

        public static void PhoneOnly(this TextEdit txtMain)
        {
            txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtMain.Properties.Mask.EditMask = "[0-9|.]+";

        }

        static void NotUnicode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.NoSign();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }

        public static void IsPersonName(this TextEdit txtMain)
        {
            if (!string.IsNullOrEmpty(txtMain.Text))
            {
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            txtMain.KeyUp += IsPersonName_KeyUp;
        }

        static void IsPersonName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }

        static void txtMain_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }
        #endregion

        #region Format GridControl
        public static void Format(this GridControl gctMain, bool allowNewRow = false, bool showIndicator = true, bool ColumnAuto = true, bool ShowLines = false)
        {
            try
            {
                gctMain.ForceInitialize();
                gctMain.UseEmbeddedNavigator = false;

                GridView grvMain = gctMain.MainView as GridView;
                grvMain.Format(allowNewRow, showIndicator, ColumnAuto, ShowLines);
            }
            catch { }

        }

        public static void Format(this GridView grvMain, bool allowNewRow, bool showIndicator, bool ColumnAuto, bool ShowLines = false)
        {
            grvMain.RestoreLayout((XtraForm)grvMain.GridControl.FindForm());

            grvMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grvMain.OptionsView.ShowGroupPanel = false;
            grvMain.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grvMain.OptionsBehavior.Editable = true;
            grvMain.OptionsMenu.EnableColumnMenu = true;
            grvMain.OptionsCustomization.AllowFilter = true;
            grvMain.OptionsCustomization.AllowSort = true;
            //grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsSelection.MultiSelect = true;
            grvMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            grvMain.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = true;
            grvMain.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            //grvMain.OptionsFind.AlwaysVisible = true;
            grvMain.OptionsFind.ShowClearButton = false;
            grvMain.OptionsFind.ShowCloseButton = false;
            grvMain.OptionsFind.ShowFindButton = false;

            grvMain.OptionsView.ShowIndicator = showIndicator;
            if (showIndicator)
            {
                grvMain.IndicatorWidth = -1;
                grvMain.CustomDrawRowIndicator -= CustomDrawRowIndicator;
                grvMain.CustomDrawRowIndicator += CustomDrawRowIndicator;
            }

            grvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            grvMain.OptionsView.RowAutoHeight = true;
            grvMain.Appearance.FocusedRow.BackColor = grvMain.Appearance.FocusedRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.SelectedRow.BackColor = grvMain.Appearance.SelectedRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.HideSelectionRow.BackColor = grvMain.Appearance.HideSelectionRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.FocusedRow.ForeColor = grvMain.Appearance.HideSelectionRow.ForeColor = grvMain.Appearance.SelectedRow.ForeColor = MyColor.GridForeRow;
            grvMain.OptionsView.ColumnAutoWidth = ColumnAuto;
            grvMain.LeftCoord = 0;

            //Format header
            grvMain.OptionsView.AllowHtmlDrawHeaders = true;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            grvMain.Appearance.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;
            grvMain.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;

            //Format footer
            grvMain.Appearance.FooterPanel.Options.UseFont = true;
            grvMain.Appearance.FooterPanel.Font = new Font(grvMain.Appearance.FooterPanel.Font, FontStyle.Bold);

            grvMain.OptionsSelection.EnableAppearanceFocusedCell = true;
            grvMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grvMain.Appearance.FocusedCell.BackColor = MyColor.BackColorEditing;
            grvMain.Appearance.FocusedCell.ForeColor = MyColor.ForeColorEditing;
            grvMain.Appearance.FocusedCell.Font = new Font(grvMain.Appearance.FocusedCell.Font, FontStyle.Bold);

            //if (allowNewRow)
            //{
            //    //grvMain.GridControl.UseEmbeddedNavigator = false;

            //    //grvMain.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            //    //grvMain.Appearance.FocusedRow.BackColor = grvMain.Appearance.FocusedRow.BackColor2 = MyColor.GridEditRow;
            //    //grvMain.Appearance.HideSelectionRow.BackColor = grvMain.Appearance.HideSelectionRow.BackColor2 = MyColor.GridEditRow;
            //    //grvMain.Appearance.FocusedRow.ForeColor = MyColor.GridForeRow;

            //    grvMain.ShowingEditor -= (sender, e) => grvMain_ShowingEditor(sender, e, allowNewRow);
            //    grvMain.ShowingEditor += (sender, e) => grvMain_ShowingEditor(sender, e, allowNewRow);

            //    grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown -= realColumnEdit_KeyDown);
            //    grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown += realColumnEdit_KeyDown);
            //}
            //else
            //{
            //    grvMain.InvalidRowException -= grvMain_InvalidRowException;
            //    grvMain.InvalidRowException += grvMain_InvalidRowException;
            //}
            if (ShowLines)
            {
                grvMain.OptionsView.ShowHorizontalLines = DefaultBoolean.True;
                grvMain.OptionsView.ShowVerticalLines = DefaultBoolean.True;
                grvMain.Appearance.HorzLine.BackColor = Color.Black;
                grvMain.Appearance.HorzLine.BackColor2 = Color.Black;
                grvMain.Appearance.HorzLine.Options.UseBackColor = true;
                grvMain.Appearance.VertLine.BackColor = Color.Black;
                grvMain.Appearance.VertLine.BackColor2 = Color.Black;
                grvMain.Appearance.VertLine.Options.UseBackColor = true;
            }
            else
            {
                grvMain.OptionsView.EnableAppearanceOddRow = true;

                grvMain.Appearance.OddRow.BackColor = Color.AliceBlue;
                grvMain.Appearance.OddRow.BackColor2 = Color.AliceBlue;
                grvMain.Appearance.OddRow.BorderColor = Color.AliceBlue;
                grvMain.Appearance.OddRow.ForeColor = Color.Black;
                grvMain.Appearance.OddRow.Options.UseBackColor = true;
                grvMain.Appearance.OddRow.Options.UseBorderColor = true;
                grvMain.Appearance.OddRow.Options.UseForeColor = true;

                grvMain.Appearance.EvenRow.BackColor = Color.AliceBlue;
                grvMain.Appearance.EvenRow.BackColor2 = Color.AliceBlue;
                grvMain.Appearance.EvenRow.BorderColor = Color.AliceBlue;
                grvMain.Appearance.EvenRow.ForeColor = Color.Black;
                grvMain.Appearance.EvenRow.Options.UseBackColor = true;
                grvMain.Appearance.EvenRow.Options.UseBorderColor = true;
            }

            grvMain.FormatColumn();

            grvMain.KeyDown -= grvMain_KeyDown;
            grvMain.KeyDown += grvMain_KeyDown;
            grvMain.RowCountChanged -= grvMain_RowCountChanged;
            grvMain.RowCountChanged += grvMain_RowCountChanged;
            grvMain.DataSourceChanged -= grvMain_DataSourceChanged;
            grvMain.DataSourceChanged += grvMain_DataSourceChanged;
            grvMain.CalcRowHeight -= grvMain_CalcRowHeight;
            grvMain.CalcRowHeight += grvMain_CalcRowHeight;
            grvMain.ShowingEditor -= (sender, e) => grvMain_ShowingEditor(sender, e);
            grvMain.ShowingEditor += (sender, e) => grvMain_ShowingEditor(sender, e);
            grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown -= realColumnEdit_KeyDown);
            grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown += realColumnEdit_KeyDown);
            grvMain.InvalidRowException -= grvMain_InvalidRowException;
            grvMain.InvalidRowException += grvMain_InvalidRowException;
        }

        public static void SaveLayout(this GridView grvMain, XtraForm frmMain)
        {
            if (string.IsNullOrEmpty(frmMain.Name)) return;
            try
            {
                string dir = @"Layout\GridLayout";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string path = dir + @"\" + frmMain + "_" + grvMain.Name + ".xml";
                if (!File.Exists(path))
                    File.Create(path).Close();

                List<xDisplay> lstDisplays = new List<xDisplay>();
                foreach (GridColumn col in grvMain.Columns)
                {
                    xDisplay dis = new xDisplay();
                    dis.ParentName = frmMain.Name;
                    dis.Group = string.Empty;
                    dis.Showing = col.Visible;
                    dis.ColumnName = col.Name;
                    dis.FieldName = col.FieldName;
                    dis.EnableEdit = col.OptionsColumn.AllowEdit;
                    dis.VisibleIndex = col.VisibleIndex;
                    dis.Caption = col.Caption;
                    lstDisplays.Add(dis);
                }

                StreamWriter sw = new StreamWriter(path);
                sw.Write(lstDisplays.SerializeXML());
                sw.Close();
            }
            catch { }
        }

        static void RestoreLayout(this GridView grvMain, XtraForm frmMain)
        {
            if (frmMain == null) return;
            if (string.IsNullOrEmpty(frmMain.Name)) return;
            try
            {
                string dir = @"Layout\GridLayout";
                string path = dir + @"\" + frmMain.Name + "_" + grvMain.Name + ".xml";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        grvMain.BeginUpdate();
                        List<xDisplay> lstDisplays = sr.ReadToEnd().DeserializeXML<xDisplay>().OrderByDescending(x => x.VisibleIndex).ToList();

                        foreach (GridColumn col in grvMain.Columns)
                        {
                            xDisplay dis = lstDisplays.Find(x => x.ColumnName.Equals(col.Name)) ?? new xDisplay() { Showing = false };
                            col.Visible = dis.Showing;
                        }

                        List<xDisplay> lstVisibles = lstDisplays.Where(x => x.VisibleIndex >= 0).OrderBy(x => x.VisibleIndex).ToList();

                        foreach (xDisplay dis in lstVisibles)
                        {
                            GridColumn col = grvMain.Columns.FirstOrDefault(x => x.Name.Equals(dis.ColumnName));
                            col.VisibleIndex = dis.VisibleIndex;
                        }

                        grvMain.EndUpdate();
                    }
                }
            }
            catch { }
        }

        public static void ShowFooter(this GridView grvMain)
        {
            grvMain.BeginSummaryUpdate();
            try
            {
                grvMain.OptionsView.ShowFooter = true;

                foreach (GridColumn col in grvMain.VisibleColumns)
                {
                    if (col.ColumnEdit is RepositoryItemSpinEdit)
                    {
                        RepositoryItemSpinEdit spt = col.ColumnEdit as RepositoryItemSpinEdit;
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        col.SummaryItem.DisplayFormat = "{0:" + spt.EditMask + "}";
                    }
                }
            }
            catch { }
            finally { grvMain.EndSummaryUpdate(); }

        }

        static void grvMain_RowCountChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.IndicatorWidth = TextRenderer.MeasureText(view.RowCount.ToString(), view.Appearance.FocusedRow.Font).Width + 10;
        }

        static void grvMain_DataSourceChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.BestFitMaxRowCount = Properties.Settings.Default.RowsInPage;
            view.BestFitColumns();
        }

        static void grvMain_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView view = sender as GridView;
            e.RowHeight = view.Appearance.HeaderPanel.FontHeight;
        }

        static void grvMain_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
        }

        static void grvMain_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {
                if (view.IsFilterRow(view.FocusedRowHandle))
                    view.ActiveFilter.Clear();
                else if (!(view.FocusedColumn.ColumnEdit is RepositoryItemDateEdit))
                    view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn, 0);
            }
        }

        static void realColumnEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Delete)
            {
                BaseEdit editor = null;

                if (sender is LookUpEdit)
                    editor = (LookUpEdit)sender;
                if (sender is DateEdit)
                    editor = (DateEdit)sender;
                if (sender is SpinEdit)
                    editor = (SpinEdit)sender;

                if (editor == null)
                    return;

                GridControl grid = editor.Parent as GridControl;
                if (grid == null)
                    return;

                GridView view = grid.FocusedView as GridView;

                if (view != null && view.IsEditing)
                {
                    view.CloseEditor();
                    if (e.KeyCode == Keys.Delete && view.IsFilterRow(view.FocusedRowHandle))
                        view.ActiveFilter.Clear();
                }
            }
        }

        static void grvMain_ShowingEditor(object sender, CancelEventArgs e)
        {
            //GridView grvMain = (GridView)sender;
            //grvMain.OptionsSelection.EnableAppearanceFocusedCell = true;
            //grvMain.OptionsSelection.EnableAppearanceFocusedRow = true;
            //grvMain.OptionsSelection.EnableAppearanceHideSelection = true;

            //GridView grvMain = (GridView)sender;
            //if (grvMain.IsNewItemRow(grvMain.FocusedRowHandle))
            //    e.Cancel = !allowNewRow;
        }

        static void FormatColumn(this GridView grvMain)
        {
            grvMain.BeginInit();
            foreach (GridColumn col in grvMain.Columns)
            {
                col.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                col.OptionsFilter.ShowEmptyDateFilter = true;
                col.OptionsFilter.ShowBlanksFilterItems = DefaultBoolean.True;
                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;

                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                col.AppearanceHeader.Font = new Font(col.AppearanceHeader.Font, FontStyle.Bold);

                col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                col.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;

                if (col.ColumnEdit != null)
                {
                    if (col.ColumnEdit is RepositoryItemSpinEdit)
                    {
                        col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                        col.DisplayFormat.FormatType = FormatType.Numeric;
                    }
                    if (col.ColumnEdit is RepositoryItemDateEdit)
                    {
                        col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                        RepositoryItemDateEdit rItem = col.ColumnEdit as RepositoryItemDateEdit;

                        col.DisplayFormat.FormatType = FormatType.DateTime;
                        rItem.EditFormat.FormatType = FormatType.DateTime;
                        rItem.DisplayFormat.FormatType = FormatType.DateTime;

                        col.DisplayFormat.FormatString = string.IsNullOrEmpty(rItem.EditMask) ? Properties.Settings.Default.DateFormat : rItem.EditMask;
                        rItem.EditFormat.FormatString = string.IsNullOrEmpty(rItem.EditMask) ? Properties.Settings.Default.DateFormat : rItem.EditMask;
                        rItem.DisplayFormat.FormatString = string.IsNullOrEmpty(rItem.EditMask) ? Properties.Settings.Default.DateFormat : rItem.EditMask;

                        rItem.ShowClear = false;
                    }
                }
            }
            grvMain.OptionsNavigation.EnterMoveNextColumn = true;
            grvMain.EndInit();
        }

        static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0 && string.IsNullOrEmpty(e.Info.DisplayText))
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = VertAlignment.Center;
                e.Info.DisplayText = (Convert.ToInt32(e.RowHandle + 1)).ToString();
                e.Info.ImageIndex = -1;
            }
        }

        static void grvMain_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.Ignore;
        }
        #endregion

        #region Format TreeList
        public static void SaveLayout(this TreeList trlMain)
        {
            if (trlMain != null)
            {
                string fName = trlMain.FindForm().Name;
                if (string.IsNullOrEmpty(fName)) return;
                try
                {
                    string TreeLayoutPath = @"Layout\TreeLayout";
                    if (!System.IO.Directory.Exists(TreeLayoutPath))
                        System.IO.Directory.CreateDirectory(TreeLayoutPath);

                    string path;
                    path = TreeLayoutPath + @"\" + trlMain.FindForm().Name + "_" + trlMain.Name + ".xml";
                    if (File.Exists(path))
                        File.Delete(path);
                    var options = new LayoutSerializationOptions();
                    options.RestoreLayoutItemText = false;

                    trlMain.OptionsLayout.Assign(options);
                    trlMain.SaveLayoutToXml(path);
                }
                catch { }
            }
        }

        public static void Format(this TreeList trlMain, bool Autowidth = false, bool ShowColumnHeader = true)
        {
            trlMain.OptionsView.ShowCheckBoxes = true;
            trlMain.OptionsView.ShowColumns = ShowColumnHeader;
            trlMain.OptionsView.EnableAppearanceOddRow = true;
            trlMain.OptionsView.ShowIndicator = false;
            trlMain.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            trlMain.OptionsView.ShowCaption = true;
            trlMain.OptionsView.AutoWidth = Autowidth;
            trlMain.OptionsBehavior.AllowIndeterminateCheckState = false;
            trlMain.OptionsBehavior.AllowRecursiveNodeChecking = true;
            trlMain.OptionsSelection.MultiSelect = false;
            trlMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            trlMain.Appearance.FocusedRow.BackColor = trlMain.Appearance.FocusedRow.BackColor2 = MyColor.GridDefaultRow;
            trlMain.Appearance.FocusedRow.ForeColor = MyColor.GridForeRow;
            trlMain.Appearance.HideSelectionRow.BackColor = trlMain.Appearance.HideSelectionRow.BackColor2 = MyColor.GridDefaultRow;
            trlMain.Appearance.HideSelectionRow.ForeColor = MyColor.GridForeRow;
            trlMain.OptionsBehavior.AutoPopulateColumns = false;
            trlMain.OptionsBehavior.PopulateServiceColumns = true;

            trlMain.ColumnPanelRowHeight = 25;
            trlMain.BestFitColumns();

            trlMain.CalcNodeHeight -= trlMain_CalcNodeHeight;
            trlMain.CalcNodeHeight += trlMain_CalcNodeHeight;
        }

        static void trlMain_CalcNodeHeight(object sender, CalcNodeHeightEventArgs e)
        {
            TreeList view = sender as TreeList;
            e.NodeHeight = view.Appearance.HeaderPanel.FontHeight;
        }

        static void trlMain_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            TreeList trl = (TreeList)sender;
            TreeListColumn colKeyID = trl.Columns.FirstOrDefault(x => x.Name.Equals("colKeyID") || x.Name.Equals("col_KeyID"));
            TreeListColumn colIsEnable = trl.Columns.FirstOrDefault(x => x.Name.Equals("colIsEnable") || x.Name.Equals("col_IsEnable"));
            if (colKeyID != null && colIsEnable != null)
            {
                var idTemp = e.Node.GetValue(colKeyID);
                int id = idTemp != null ? Convert.ToInt32(idTemp) : 0;

                var isEnbaleTemp = e.Node.GetValue(colIsEnable);

                if (id > 0 && isEnbaleTemp != null && !((bool)isEnbaleTemp))
                    e.Appearance.ForeColor = Color.Red;
            }
        }

        static void trlMain_NodeChanged(object sender, NodeChangedEventArgs e)
        {
            if (e.ChangeType != NodeChangeTypeEnum.CheckedState)
                return;

            checkedNode(e.Node);
        }

        static void checkedNode(TreeListNode node)
        {
            if (node.ParentNode == null)
            {
                if (node.CheckState == CheckState.Checked)
                    node.CheckAll();
                if (node.CheckState == CheckState.Unchecked)
                    node.UncheckAll();
            }
            else
            {
                if (node.CheckState == CheckState.Checked)
                    node.CheckAll();
                if (node.CheckState == CheckState.Unchecked)
                    node.UncheckAll();

                TreeListNode parentNode = node.ParentNode;

                if (parentNode.Nodes.Any(x => x.CheckState == CheckState.Checked || x.CheckState == CheckState.Indeterminate))
                    parentNode.CheckState = CheckState.Indeterminate;
                if (parentNode.Nodes.All(x => x.CheckState == CheckState.Checked))
                    parentNode.CheckState = CheckState.Checked;
                if (parentNode.Nodes.All(x => x.CheckState == CheckState.Unchecked))
                    parentNode.CheckState = CheckState.Unchecked;

                checkedNode(parentNode);
            }
        }

        public static void Translation(this TreeList trlMain)
        {
            //string fName = "";
            //try
            //{
            //    fName = trlMain.FindForm().Name;
            //}
            //catch { }
            //if (!string.IsNullOrEmpty(fName) && trlMain != null && trlMain.Columns.Count > 0)
            //{
            //    db = new aModel();
            //    List<xMsgDictionary> lstAdd = new List<xMsgDictionary>();
            //    foreach (TreeListColumn col in trlMain.Columns)
            //    {
            //        string mName = string.Format("{0}_{1}", trlMain.Name, col.Name);
            //        var myTrans = db.xMsgDictionaries.FirstOrDefault<xMsgDictionary>(n => n.FormName.Equals(fName) && n.MsgName.Equals(mName));
            //        if (myTrans == null)
            //        {
            //            var k = col.GetTextCaption();
            //            lstAdd.Add(myTrans = new xMsgDictionary()
            //            {
            //                FormName = fName,
            //                MsgName = mName,
            //                VN = !string.IsNullOrEmpty(col.Caption) ? col.Caption : col.GetCaption(),
            //                EN = col.Name.AutoSpace()
            //            });

            //        }
            //        col.Caption = myTrans.GetStringByName(curCulture);
            //        col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //    }
            //    //if (lstAdd != null && lstAdd.Count() > 0)
            //    //{
            //    //    try
            //    //    {
            //    //        db.xMsgDictionaries.AddRange(lstAdd);
            //    //        db.SaveChanges();
            //    //    }
            //    //    catch { }
            //    //}
            //}
        }

        public static void FormatColumnTreeList(this TreeList trlMain, string fName = "")
        {
            //if (trlMain.Columns.Count > 0 && trlMain.Columns[0].AppearanceHeader.ForeColor != MyColor.GridForeHeader)
            //{
            //    if (string.IsNullOrEmpty(fName))
            //    {
            //        try { fName = trlMain.FindForm().Name; }
            //        catch { return; }
            //    }
            //    if (string.IsNullOrEmpty(fName)) return;
            //    List<xDisplay> lstAdd = new List<xDisplay>();
            //    trlMain.BeginInit();
            //    bool addCol = false;
            //    foreach (TreeListColumn col in trlMain.Columns)
            //    {
            //        addCol = false;
            //        xDisplay myDisplay = null;
            //        try
            //        {
            //            myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(trlMain.Name) && hts.ColumnName.Equals(col.Name));

            //            addCol = (myDisplay == null);
            //        }
            //        catch { addCol = true; }
            //        finally
            //        {
            //            if (addCol && trlMain.DataSource != null)
            //            {
            //                myDisplay = new xDisplay();
            //                myDisplay.ParentName = fName;
            //                myDisplay.Group = trlMain.Name;
            //                myDisplay.ColumnName = col.Name;
            //                myDisplay.FieldName = col.FieldName;
            //                myDisplay.Showing = col.Visible;

            //                string cType = "None";
            //                string cAlign = "Default";
            //                if (col.Format.FormatType == FormatType.DateTime || col.ColumnType == typeof(Nullable<DateTime>) || col.ColumnType == typeof(DateTime))
            //                {
            //                    cType = "DateTime"; cAlign = "Center";
            //                }
            //                else if (col.Format.FormatType == FormatType.Numeric || col.ColumnType == typeof(Nullable<Decimal>) || col.ColumnType == typeof(Decimal) || col.ColumnType == typeof(Nullable<int>) || col.ColumnType == typeof(int) || col.ColumnType == typeof(Nullable<Double>) || col.ColumnType == typeof(Double) || col.ColumnType == typeof(Nullable<long>) || col.ColumnType == typeof(long) || col.ColumnType == typeof(Nullable<float>) || col.ColumnType == typeof(float))
            //                {
            //                    cType = "Numeric"; cAlign = "Far";
            //                    if (col.ColumnEdit != null)
            //                        cAlign = "Near";
            //                }
            //                else if (col.Format.FormatType == FormatType.Custom)
            //                {
            //                    cType = "Custom"; cAlign = "Near";
            //                }

            //                myDisplay.Type = cType;
            //                myDisplay.TextAlign = cAlign;
            //                myDisplay.EnableEdit = col.OptionsColumn.AllowEdit;
            //                lstAdd.Add(myDisplay);
            //            }
            //            else if (myDisplay == null)
            //                myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(trlMain.Name) && hts.ColumnName.Equals(col.Name));

            //            if (myDisplay != null)
            //            {
            //                col.Visible = myDisplay.Showing;
            //                col.FieldName = myDisplay.FieldName;
            //                if (myDisplay.Type != null)
            //                {
            //                    col.Format.FormatType = (FormatType)Enum.Parse(typeof(FormatType), myDisplay.Type);
            //                    col.AppearanceCell.TextOptions.HAlignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), myDisplay.TextAlign);

            //                    if (myDisplay.Type.Equals("Numeric") && !string.IsNullOrEmpty(curDecimalFormat) && string.IsNullOrEmpty(col.Format.FormatString))
            //                    {
            //                        col.Format.FormatType = FormatType.Numeric;
            //                        col.Format.FormatString = curDecimalFormat;
            //                        if (col.ColumnEdit != null)
            //                        {
            //                            col.ColumnEdit.EditFormat.FormatType = col.ColumnEdit.DisplayFormat.FormatType = FormatType.Numeric;
            //                            col.ColumnEdit.EditFormat.FormatString = col.ColumnEdit.DisplayFormat.FormatString = curDecimalFormat;
            //                        }

            //                    }
            //                    else if (myDisplay.Type.Equals("DateTime") && curDecimalFormat != null && string.IsNullOrEmpty(col.Format.FormatString))
            //                    {
            //                        col.Format.FormatType = FormatType.DateTime;
            //                        col.Format.FormatString = curDateFormat;
            //                        if (col.ColumnEdit != null)
            //                        {
            //                            col.ColumnEdit.EditFormat.FormatType = col.ColumnEdit.DisplayFormat.FormatType = FormatType.DateTime;
            //                            col.ColumnEdit.EditFormat.FormatString = col.ColumnEdit.DisplayFormat.FormatString = curDecimalFormat;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    trlMain.EndInit();
            //    //if (lstAdd != null && lstAdd.Count > 0)
            //    //{
            //    //    try
            //    //    {
            //    //        db = new aModel();
            //    //        db.xDisplays.AddRange(lstAdd);
            //    //        db.SaveChanges();
            //    //    }
            //    //    catch { }
            //    //}
            //}
            //trlMain.ExpandAll();
        }

        static void trlMain_NodesReloaded(object sender, EventArgs e)
        {
            TreeList trlMain = (TreeList)sender;
            if (trlMain == null || trlMain.Columns.Count == 0 || trlMain.Columns[0].AppearanceHeader.ForeColor == MyColor.GridForeHeader)
                return;
            else
                trlMain.FormatColumnTreeList();
        }
        #endregion

        #region Format SpinEdit
        public static void Format(this SpinEdit spnMain, int DecimalScale = 0, bool LeftAlight = true, bool NotNegative = true)
        {
            spnMain.Properties.Buttons.Clear();
            spnMain.Properties.Mask.UseMaskAsDisplayFormat = true;
            spnMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            spnMain.Properties.AppearanceReadOnly.TextOptions.HAlignment = spnMain.Properties.AppearanceFocused.TextOptions.HAlignment = spnMain.Properties.Appearance.TextOptions.HAlignment = LeftAlight ? HorzAlignment.Near : HorzAlignment.Far;
            spnMain.Properties.Mask.EditMask = spnMain.Properties.DisplayFormat.FormatString = spnMain.Properties.EditFormat.FormatString = "N" + DecimalScale.ToString();

            if (NotNegative)
            {
                spnMain.KeyPress += NotNegative_KeyPress;
                if (spnMain.Properties.MinValue == spnMain.Properties.MaxValue)
                {
                    spnMain.Properties.MaxValue = decimal.MaxValue;
                }
                if (spnMain.Properties.MinValue < 0)
                    spnMain.Properties.MinValue = 0;
            }
            //spnMain.CustomDisplayText -= spnMain_CustomDisplayText;
            //spnMain.CustomDisplayText += spnMain_CustomDisplayText;
        }

        static void spnMain_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                decimal val = Convert.ToDecimal(e.Value);
                if (val == 0)
                    e.DisplayText = "-";
            }
        }

        public static decimal ToDecimal(this SpinEdit spnMain)
        {
            try
            {
                return Convert.ToDecimal(spnMain.EditValue);
            }
            catch { return 0; }
        }

        public static void NotNegative_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        #endregion

        #region Format RepositorySpinEdit
        public static void Format(this RepositoryItemSpinEdit rspnMain, int DecimalScale = 0, bool LeftAlight = true, bool NotNegative = true)
        {
            rspnMain.Buttons.Clear();
            rspnMain.Mask.UseMaskAsDisplayFormat = true;
            rspnMain.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rspnMain.AppearanceReadOnly.TextOptions.HAlignment = rspnMain.AppearanceFocused.TextOptions.HAlignment = rspnMain.Appearance.TextOptions.HAlignment = LeftAlight ? HorzAlignment.Near : HorzAlignment.Far;
            rspnMain.Mask.EditMask = rspnMain.DisplayFormat.FormatString = rspnMain.EditFormat.FormatString = "N" + DecimalScale.ToString();
            if (NotNegative)
            {
                rspnMain.KeyPress += NotNegative_KeyPress;
                if (rspnMain.MinValue == rspnMain.MaxValue)
                {
                    rspnMain.MaxValue = decimal.MaxValue;
                }
                if (rspnMain.MinValue < 0)
                    rspnMain.MinValue = 0;
            }
            rspnMain.CustomDisplayText -= rspnMain_CustomDisplayText;
            rspnMain.CustomDisplayText += rspnMain_CustomDisplayText;
        }

        static void rspnMain_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                decimal val = Convert.ToDecimal(((decimal)e.Value).ToString("0"));
                if (val == 0)
                    e.DisplayText = "-";
            }
        }
        #endregion

        #region Format LookUpEdit
        public static void Format(this LookUpEdit lokMain, bool showHeader = false)
        {
            lokMain.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lokMain.Properties.ShowFooter = false;
            lokMain.Properties.NullText = String.Empty;
            lokMain.Properties.ShowHeader = showHeader;
            lokMain.Properties.TextEditStyle = TextEditStyles.Standard;

            lokMain.Properties.SearchMode = SearchMode.AutoFilter;
            lokMain.Properties.AllowNullInput = DefaultBoolean.True;
            lokMain.Properties.AutoSearchColumnIndex = 1;
            lokMain.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center;
            lokMain.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = VertAlignment.Center;

            lokMain.Properties.HighlightedItemStyle = HighlightStyle.Standard;
            lokMain.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            lokMain.Properties.LookAndFeel.Style = LookAndFeelStyle.Office2003;

            lokMain.Properties.KeyDown -= rlok_KeyDown;
            lokMain.Properties.KeyDown += rlok_KeyDown;

            if (lokMain.Properties.Columns.Count == 0 && !string.IsNullOrEmpty(lokMain.Properties.DisplayMember))
                lokMain.Properties.Columns.Add(new LookUpColumnInfo() { FieldName = lokMain.Properties.DisplayMember, Visible = true });

            //lokMain.Translation();
            //lokMain.FormatColumnLookUpEdit();
        }

        static void rlok_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is LookUpEdit)
            {
                LookUpEdit lok = sender as LookUpEdit;
                if (e.KeyCode == Keys.Delete || string.IsNullOrEmpty(lok.Text.Trim()))
                    lok.EditValue = null;
            }
        }

        public static void Translation(this LookUpEdit lokMain)
        {
            //string fName = "";
            //try { fName = lokMain.FindForm().Name; }
            //catch { }
            //if (!string.IsNullOrEmpty(fName) && lokMain != null && lokMain.Properties.Columns.Count > 0)
            //{
            //    db = new aModel();
            //    List<xMsgDictionary> lstAdd = new List<xMsgDictionary>();
            //    foreach (LookUpColumnInfo col in lokMain.Properties.Columns)
            //    {
            //        string mName = string.Format("{0}_{1}", lokMain.Name, col.FieldName);
            //        var myTrans = db.xMsgDictionaries.FirstOrDefault<xMsgDictionary>(n => n.FormName.Equals(fName) && n.MsgName.Equals(mName));
            //        if (myTrans == null)
            //        {
            //            lstAdd.Add(myTrans = new xMsgDictionary()
            //            {
            //                FormName = fName,
            //                MsgName = mName,
            //                VN = col.Caption,
            //                EN = col.FieldName.AutoSpace()
            //            });

            //        }
            //        col.Caption = myTrans.GetStringByName(curCulture);
            //    }
            //    if (lstAdd != null && lstAdd.Count() > 0)
            //    {
            //        try
            //        {
            //            db.xMsgDictionaries.AddRange(lstAdd);
            //            db.SaveChanges();
            //        }
            //        catch { }
            //    }
            //}
        }

        public static void FormatColumnLookUpEdit(this LookUpEdit lokMain, string fName = "")
        {
            //if (string.IsNullOrEmpty(fName))
            //{
            //    try { fName = lokMain.FindForm().Name; }
            //    catch { }
            //}
            //if (string.IsNullOrEmpty(fName) || lokMain.Properties.Columns.Count == 0 || !lokMain.Properties.ShowHeader) return;

            //db = new aModel();
            //List<xDisplay> lstAdd = new List<xDisplay>();

            //bool addCol = false;
            //foreach (LookUpColumnInfo col in lokMain.Properties.Columns)
            //{
            //    addCol = false;
            //    xDisplay myDisplay = null;
            //    try
            //    {
            //        myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(n => n.ParentName.Equals(fName) && n.Group.Equals(lokMain.Name) && n.ColumnName.Equals(col.FieldName));

            //        addCol = (myDisplay == null);
            //    }
            //    catch { addCol = true; }
            //    finally
            //    {
            //        if (addCol && lokMain.Properties.DataSource != null)
            //        {
            //            myDisplay = new xDisplay();
            //            myDisplay.ParentName = fName;
            //            myDisplay.Group = lokMain.Name;
            //            myDisplay.ColumnName = col.FieldName;
            //            myDisplay.FieldName = col.FieldName;
            //            myDisplay.Showing = col.Visible;

            //            string cType = "None";
            //            string cAlign = "Default";
            //            if (col.FormatType == FormatType.DateTime)
            //            {
            //                cType = "DateTime"; cAlign = "Center";
            //            }
            //            else if (col.FormatType == FormatType.Numeric)
            //            {
            //                cType = "Numeric"; cAlign = "Far";
            //            }
            //            else
            //            {
            //                cType = "Custom"; cAlign = "Near";
            //            }

            //            myDisplay.Type = cType;
            //            myDisplay.TextAlign = cAlign;
            //            myDisplay.EnableEdit = false;
            //            lstAdd.Add(myDisplay);
            //        }
            //        else if (myDisplay == null)
            //            myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(lokMain.Name) && hts.ColumnName.Equals(col.FieldName));

            //        if (myDisplay != null)
            //        {
            //            col.Visible = myDisplay.Showing;
            //            col.FieldName = myDisplay.FieldName;
            //            if (myDisplay.Type != null)
            //            {
            //                if (lokMain.Properties.DataSource != null)
            //                    lokMain.Properties.AppearanceDropDownHeader.ForeColor = MyColor.GridForeHeader;

            //                col.FormatType = (FormatType)Enum.Parse(typeof(FormatType), myDisplay.Type);
            //                col.Alignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), myDisplay.TextAlign);

            //                if (myDisplay.Type.Equals("Numeric") && curDecimalFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDecimalFormat;
            //                else if (myDisplay.Type.Equals("DateTime") && curDateFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDateFormat;
            //            }
            //        }
            //    }
            //}

            //if (lstAdd != null && lstAdd.Count > 0)
            //{
            //    try
            //    {
            //        db = new aModel();
            //        db.xDisplays.AddRange(lstAdd);
            //        db.SaveChanges();
            //    }
            //    catch { }
            //}
        }

        public static int ToInt32(this LookUpEdit lokMain)
        {
            try
            {
                if (lokMain.ItemIndex < 0)
                    return 0;
                else
                    return Convert.ToInt32(lokMain.EditValue);
            }
            catch { return 0; }
        }
        #endregion

        #region Format RepositoryLookUpEdit
        public static void Format(this RepositoryItemLookUpEdit rlokMain, bool showHeader = false)
        {
            rlokMain.NullText = "";
            rlokMain.ShowFooter = false;
            rlokMain.AllowFocused = false;
            rlokMain.ShowHeader = showHeader;
            rlokMain.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center;
            rlokMain.AppearanceDropDownHeader.TextOptions.VAlignment = VertAlignment.Center;
            rlokMain.AppearanceDropDownHeader.Options.UseFont = true;
            rlokMain.TextEditStyle = TextEditStyles.Standard;
            rlokMain.BestFitMode = BestFitMode.BestFitResizePopup;

            rlokMain.HighlightedItemStyle = HighlightStyle.Standard;
            rlokMain.LookAndFeel.UseDefaultLookAndFeel = false;
            rlokMain.LookAndFeel.Style = LookAndFeelStyle.Office2003;

            if (rlokMain.Columns.Count == 0 && !string.IsNullOrEmpty(rlokMain.DisplayMember))
                rlokMain.Columns.Add(new LookUpColumnInfo() { FieldName = rlokMain.DisplayMember, Visible = true });

            rlokMain.KeyDown -= rlokMain_KeyDown;
            rlokMain.KeyDown += rlokMain_KeyDown;
        }

        static void rlokMain_KeyDown(object sender, KeyEventArgs e)
        {
            LookUpEdit lok = sender as LookUpEdit;
            IPopupControl popupEdit = sender as IPopupControl;
            PopupLookUpEditForm popupWindow = popupEdit.PopupWindow as PopupLookUpEditForm;
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) && popupWindow != null)
            {
                int index = popupWindow.SelectedIndex;
                int count = 0;
                if (lok.Properties.DataSource != null)
                {
                    IList lst = lok.Properties.DataSource as IList;
                    if (lst != null)
                        count = lst.Count;
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (popupWindow != null)
                    {
                        if (index != -1 && index < (count - 1))
                            index++;
                    }
                }
                if (e.KeyCode == Keys.Up)
                    index = index > 0 ? index - 1 : index;
                lok.ItemIndex = index;
            }

            if (e.KeyCode == Keys.Delete)
                lok.EditValue = null;
        }

        public static void Translation(this RepositoryItemLookUpEdit rlokMain, string fName)
        {
            //if (!string.IsNullOrEmpty(fName) && rlokMain != null && rlokMain.Columns.Count > 0)
            //{
            //    db = new aModel();
            //    List<xMsgDictionary> lstAdd = new List<xMsgDictionary>();
            //    foreach (LookUpColumnInfo col in rlokMain.Columns)
            //    {
            //        string mName = string.Format("{0}_{1}", rlokMain.Name, col.FieldName);
            //        var myTrans = db.xMsgDictionaries.FirstOrDefault<xMsgDictionary>(n => n.FormName.Equals(fName) && n.MsgName.Equals(mName));
            //        if (myTrans == null)
            //        {
            //            lstAdd.Add(myTrans = new xMsgDictionary()
            //            {
            //                FormName = fName,
            //                MsgName = mName,
            //                VN = col.Caption,
            //                EN = col.FieldName.AutoSpace()
            //            });

            //        }
            //        col.Caption = myTrans.GetStringByName(curCulture);
            //    }
            //    if (lstAdd != null && lstAdd.Count() > 0)
            //    {
            //        try
            //        {
            //            db.xMsgDictionaries.AddRange(lstAdd);
            //            db.SaveChanges();
            //        }
            //        catch { }
            //    }
            //}
        }

        public static void FormatColumnRepositoryLookUpEdit(this RepositoryItemLookUpEdit rlokMain, string fName)
        {
            //db = new aModel();
            //List<xDisplay> lstAdd = new List<xDisplay>();

            //bool addCol = false;
            //foreach (LookUpColumnInfo col in rlokMain.Columns)
            //{
            //    addCol = false;
            //    xDisplay myDisplay = null;
            //    try
            //    {
            //        myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(rlokMain.Name) && hts.ColumnName.Equals(col.FieldName));

            //        if (myDisplay == null)
            //            addCol = true;
            //    }
            //    catch { addCol = true; }
            //    finally
            //    {
            //        if (addCol && rlokMain.DataSource != null)
            //        {
            //            myDisplay = new xDisplay();
            //            myDisplay.ParentName = fName;
            //            myDisplay.Group = rlokMain.Name;
            //            myDisplay.ColumnName = col.FieldName;
            //            myDisplay.FieldName = col.FieldName;
            //            myDisplay.Showing = col.Visible;

            //            string cType = "None";
            //            string cAlign = "Default";
            //            if (col.FormatType == FormatType.DateTime)
            //            {
            //                cType = "DateTime"; cAlign = "Center";
            //            }
            //            else if (col.FormatType == FormatType.Numeric)
            //            {
            //                cType = "Numeric"; cAlign = "Far";
            //            }
            //            else
            //            {
            //                cType = "Custom"; cAlign = "Near";
            //            }

            //            myDisplay.Type = cType;
            //            myDisplay.TextAlign = cAlign;
            //            myDisplay.EnableEdit = false;
            //            lstAdd.Add(myDisplay);
            //        }
            //        else if (myDisplay == null)
            //            myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(rlokMain.Name) && hts.ColumnName.Equals(col.FieldName));


            //        if (myDisplay != null)
            //        {
            //            col.Visible = myDisplay.Showing;
            //            col.FieldName = myDisplay.FieldName;
            //            if (myDisplay.Type != null)
            //            {
            //                if (rlokMain.DataSource != null)
            //                    rlokMain.AppearanceDropDownHeader.ForeColor = MyColor.GridForeHeader;

            //                col.FormatType = (FormatType)Enum.Parse(typeof(FormatType), myDisplay.Type);
            //                col.Alignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), myDisplay.TextAlign);

            //                if (myDisplay.Type.Equals("Numeric") && curDecimalFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDecimalFormat;
            //                else if (myDisplay.Type.Equals("DateTime") && curDateFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDateFormat;
            //            }
            //        }
            //    }
            //}

            //if (lstAdd != null && lstAdd.Count() > 0)
            //{
            //    try
            //    {
            //        db = new aModel();
            //        db.xDisplays.AddRange(lstAdd);
            //        db.SaveChanges();
            //    }
            //    catch { }
            //}
        }
        #endregion

        #region DateEdit
        public static void Format(this DateEdit dateEdit, string fText = "dd/MM/yyyy", bool IsCurrentDate = false)
        {
            if (IsCurrentDate)
                dateEdit.DateTime = DateTime.Now.ServerNow();
            dateEdit.Properties.EditMask = fText;
            dateEdit.Properties.ShowClear = false;
            dateEdit.Properties.MinValue = new DateTime(1900, 1, 1);
            dateEdit.Properties.MaxValue = DateTime.Now.ServerNow();
        }
        #endregion

        #region RepositoryDateEdit
        public static void Format(this RepositoryItemDateEdit dateEdit, string fText = "dd/MM/yyyy")
        {
            dateEdit.EditMask = fText;
            dateEdit.ShowClear = false;
            dateEdit.MinValue = new DateTime(1900, 1, 1);
            dateEdit.MaxValue = DateTime.Now.ServerNow();
        }
        #endregion

        #region SearchLookupEdit
        public static void Format(this SearchLookUpEdit slokMain, bool showHeader = true, bool showIndicator = true, bool ColumnAuto = true)
        {
            if (slokMain.Properties.View.Columns.Count == 0 && !string.IsNullOrEmpty(slokMain.Properties.DisplayMember))
            {
                GridColumn col = new GridColumn();
                col.Name = $"col{slokMain.Properties.DisplayMember}";
                col.FieldName = slokMain.Properties.DisplayMember;
                col.OptionsColumn.AllowEdit = false;
                col.Visible = true;
                slokMain.Properties.View.Columns.Add(col);
            }
            slokMain.Properties.ShowFooter = false;
            slokMain.Properties.ShowClearButton = false;

            slokMain.Properties.View.Format(false, showIndicator, ColumnAuto, false);
            slokMain.Properties.View.OptionsView.ShowColumnHeaders = showHeader;
            slokMain.Properties.View.OptionsSelection.MultiSelect = false;

            slokMain.Popup -= lokMain_Popup;
            slokMain.Popup += lokMain_Popup;
        }

        static void lokMain_Popup(object sender, EventArgs e)
        {
            Control f = (sender as IPopupControl).PopupWindow;
            string[] controlNames = new string[] { "btClear", "btFind" };
            foreach (string name in controlNames)
            {
                Control[] controls = f.Controls.Find(name, true);
                if (controls.Length > 0)
                {
                    Control ctr = controls[0];
                    LayoutControl layoutControl = ctr.Parent as LayoutControl;
                    if (layoutControl != null)
                        layoutControl.GetItemByControl(ctr).Visibility = LayoutVisibility.Never;
                }
            }
            SearchLookUpEdit lokMain = sender as SearchLookUpEdit;
            lokMain.Popup -= lokMain_Popup;
        }

        public static int ToInt32(this SearchLookUpEdit lokMain)
        {
            try
            {
                return Convert.ToInt32(lokMain.EditValue);
            }
            catch { return 0; }
        }
        #endregion
        #endregion
    }

    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static List<T> Clone<T>(this List<T> source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<List<T>>(serialized);
        }

        public static string SerializeJSON<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return serialized;
        }

        public static T DeserializeJSON<T>(this string source) where T : new()
        {
            try { return JsonConvert.DeserializeObject<T>(source); }
            catch { return new T(); }
        }
    }

    public static class ReflectionPopulator
    {
        public static List<Dictionary<string, object>> CreateObjects(this SqlDataReader reader, Type type)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            var properties = type.GetProperties();

            while (reader.Read())
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                results.Add(dic);
                foreach (var property in properties)
                {
                    object Value = null;
                    Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    int index = reader.GetOrdinal(property.Name);
                    switch (convertTo.Name)
                    {
                        case "Int16":
                        case "Int32":
                        case "Int64":
                            Value = reader.IsDBNull(index) ? 0 : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "String":
                            Value = reader.IsDBNull(index) ? string.Empty : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "Boolean":
                            Value = reader.IsDBNull(index) ? false : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "DateTime":
                            Value = reader.IsDBNull(index) ? null : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        default:
                            Value = null;
                            break;
                    }

                    dic.Add(property.Name, Value);
                }
            }
            reader.Close();
            return results;
        }

        public static List<Dictionary<string, object>> CreateObjects(this SqlDataReader reader, string[] FieldNames)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            Type convertTo = typeof(String);
            while (reader.Read())
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                results.Add(dic);
                foreach (string FieldName in FieldNames)
                {
                    object Value = null;

                    int index = reader.GetOrdinal(FieldName);
                    switch (convertTo.Name)
                    {
                        case "Int16":
                        case "Int32":
                        case "Int64":
                            Value = reader.IsDBNull(index) ? 0 : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "String":
                            Value = reader.IsDBNull(index) ? string.Empty : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "Boolean":
                            Value = reader.IsDBNull(index) ? false : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        case "DateTime":
                            Value = reader.IsDBNull(index) ? null : Convert.ChangeType(reader.GetValue(index), convertTo);
                            break;
                        default:
                            Value = null;
                            break;
                    }

                    dic.Add(FieldName, Value);
                }
            }
            reader.Close();
            return results;
        }

        public static object CreateObject(this SqlDataReader reader, Type type)
        {
            var properties = type.GetProperties();
            while (reader.Read())
            {
                var item = type.Clone();
                foreach (var property in properties)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        item.SetValue(property.Name, reader[property.Name]);
                    }
                }
                return item;
            }
            return null;
        }
    }

    public static class Converter
    {
        public static string GetStringByName(this object oSource, string pName)
        {
            if (oSource == null) return string.Empty;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? oRe.ToString() : string.Empty;
        }

        public static int GetInt16ByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToInt16(oRe) : 0;
        }

        public static int GetInt32ByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToInt32(oRe) : 0;
        }

        public static bool GetBooleanByName(this object oSource, string pName)
        {
            if (oSource == null) return false;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToBoolean(oRe) : false;
        }

        public static decimal GetDecimalByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToDecimal(oRe) : 0;
        }

        public static object GetObjectByName(this Type oSource, string pName, Type convertTo)
        {
            if (oSource == null) return Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);

            var properties = oSource.GetProperties();
            oSource.Clone();
            var oRe = oSource.GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ChangeType(oRe, convertTo) : Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
        }

        public static void SetValue(this object obj, string FieldName, object Value)
        {
            if (obj == null) return;

            obj.GetType().GetProperties().Where(x => x.Name.Equals(FieldName)).ToList().ForEach(x =>
            {
                if (x.PropertyType.GenericTypeArguments.Length > 0)
                    x.SetValue(obj, Convert.ChangeType(Value, x.PropertyType.GenericTypeArguments[0]));
                else
                    x.SetValue(obj, Convert.ChangeType(Value, x.PropertyType));
            });
        }

        public static Dictionary<string, object> ObjectToDictionary(this object source)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (PropertyInfo pInfo in source.GetType().GetProperties())
            {
                var tempType = pInfo.PropertyType;
                var tempValue = pInfo.GetValue(source);
                if (tempValue != null)
                {
                    if (tempType.IsGenericType)
                    {
                        if (tempType.GetGenericTypeDefinition() == typeof(ICollection<>)) { }
                        else if (tempType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            dic.Add(pInfo.Name, Convert.ChangeType(tempValue, Nullable.GetUnderlyingType(tempType)));
                    }
                    else
                        dic.Add(pInfo.Name, Convert.ChangeType(tempValue, tempType));
                }
                else
                    dic.Add(pInfo.Name, tempValue);
            }
            return dic;
        }

        #region ToDataTable
        public class ObjectShredder<T>
        {
            private System.Reflection.FieldInfo[] _fi;
            private System.Reflection.PropertyInfo[] _pi;
            private System.Collections.Generic.Dictionary<string, int> _ordinalMap;
            private System.Type _type;

            // ObjectShredder constructor.
            public ObjectShredder()
            {
                _type = typeof(T);
                _fi = _type.GetFields();
                _pi = _type.GetProperties();
                _ordinalMap = new Dictionary<string, int>();
            }

            /// <summary>
            /// Loads a DataTable from a sequence of objects.
            /// </summary>
            /// <param name="source">The sequence of objects to load into the DataTable.</param>
            /// <param name="table">The input table. The schema of the table must match that 
            /// the type T.  If the table is null, a new table is created with a schema 
            /// created from the public properties and fields of the type T.</param>
            /// <param name="options">Specifies how values from the source sequence will be applied to 
            /// existing rows in the table.</param>
            /// <returns>A DataTable created from the source sequence.</returns>
            public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                // Load the table from the scalar sequence if T is a primitive type.
                if (typeof(T).IsPrimitive)
                {
                    return ShredPrimitive(source, table, options);
                }

                // Create a new table if the input table is null.
                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                // Initialize the ordinal map and extend the table schema based on type T.
                table = ExtendTable(table, typeof(T));

                // Enumerate the source sequence and load the object values into rows.
                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        if (options != null)
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), true);
                        }
                    }
                }
                table.EndLoadData();

                // Return the table.
                return table;
            }

            public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                // Create a new table if the input table is null.
                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                if (!table.Columns.Contains("Value"))
                {
                    table.Columns.Add("Value", typeof(T));
                }

                // Enumerate the source sequence and load the scalar values into rows.
                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    Object[] values = new object[table.Columns.Count];
                    while (e.MoveNext())
                    {
                        values[table.Columns["Value"].Ordinal] = e.Current;

                        if (options != null)
                        {
                            table.LoadDataRow(values, (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(values, true);
                        }
                    }
                }
                table.EndLoadData();

                // Return the table.
                return table;
            }

            public object[] ShredObject(DataTable table, T instance)
            {

                FieldInfo[] fi = _fi;
                PropertyInfo[] pi = _pi;

                if (instance.GetType() != typeof(T))
                {
                    // If the instance is derived from T, extend the table schema
                    // and get the properties and fields.
                    ExtendTable(table, instance.GetType());
                    fi = instance.GetType().GetFields();
                    pi = instance.GetType().GetProperties();
                }

                // Add the property and field values of the instance to an array.
                Object[] values = new object[table.Columns.Count];
                foreach (FieldInfo f in fi)
                {
                    values[_ordinalMap[f.Name]] = f.GetValue(instance);
                }

                foreach (PropertyInfo p in pi)
                {
                    values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
                }

                // Return the property and field values of the instance.
                return values;
            }

            public DataTable ExtendTable(DataTable table, Type type)
            {
                // Extend the table schema if the input table was null or if the value 
                // in the sequence is derived from type T.            
                foreach (FieldInfo f in type.GetFields())
                {
                    if (!_ordinalMap.ContainsKey(f.Name))
                    {
                        // Add the field as a column in the table if it doesn't exist
                        // already.
                        DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                            : table.Columns.Add(f.Name, (f.FieldType.IsGenericType && f.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? typeof(object) : f.FieldType);

                        // Add the field to the ordinal map.
                        _ordinalMap.Add(f.Name, dc.Ordinal);
                    }
                }
                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (!_ordinalMap.ContainsKey(p.Name))
                    {
                        // Add the property as a column in the table if it doesn't exist
                        // already.
                        DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                            : table.Columns.Add(p.Name, (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? typeof(object) : p.PropertyType);

                        // Add the property to the ordinal map.
                        _ordinalMap.Add(p.Name, dc.Ordinal);
                    }
                }

                // Return the table.
                return table;
            }
        }
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }
        #endregion
    }
}