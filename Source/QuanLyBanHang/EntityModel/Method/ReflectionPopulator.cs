using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Method
{
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
        public static List<Dictionary<string, object>> CreateObjects(this SqlDataReader reader, Dictionary<string, Type> types)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                results.Add(dic);
                foreach (var type in types)
                {
                    object Value = null;
                    int index = reader.GetOrdinal(type.Key);
                    Type convertTo = type.Value;
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

                    dic.Add(type.Key, Value);
                }
            }
            reader.Close();
            return results;
        }
        public static List<Dictionary<string, object>> CreateObjects(this List<dynamic> reader, Dictionary<string, Type> types)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            foreach (object d in reader)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                results.Add(dic);

                foreach (var type in types)
                {
                    string ValueTemp = d.GetStringByName(type.Key);
                    object Value = null;
                    Type convertTo = type.Value;
                    switch (convertTo.Name)
                    {
                        case "Int16":
                        case "Int32":
                        case "Int64":
                            Value = string.IsNullOrEmpty(ValueTemp) ? 0 : Convert.ChangeType(ValueTemp, convertTo);
                            break;
                        case "String":
                            Value = string.IsNullOrEmpty(ValueTemp) ? string.Empty : Convert.ChangeType(ValueTemp, convertTo);
                            break;
                        case "Boolean":
                            Value = string.IsNullOrEmpty(ValueTemp) ? false : Convert.ChangeType(ValueTemp, convertTo);
                            break;
                        case "DateTime":
                            Value = string.IsNullOrEmpty(ValueTemp) ? DateTime.MinValue : Convert.ChangeType(ValueTemp, convertTo);
                            break;
                    }
                    dic.Add(type.Key, Value);
                }
            }
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
}
