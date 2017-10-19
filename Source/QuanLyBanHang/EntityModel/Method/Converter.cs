using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Method
{
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
    }
}
