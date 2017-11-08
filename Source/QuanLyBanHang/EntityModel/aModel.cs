using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using EntityModel.Method;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{

    public class aModel : zModel
    {
        #region Code 4
        //public override int SaveChanges()
        //{
        //    List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
        //    .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
        //    .ToList());
        //    if (entries != null && entries.Count > 0)
        //    {
        //        Exception exception = AutoLog(entries);
        //        if (exception != null) throw exception;
        //    }
        //    return Convert.ToInt32(true);
        //}
        //private Exception AutoLog(List<DbEntityEntry> changeTrack)
        //{
        //    var dateQuery = Database.SqlQuery<DateTime>("SELECT GETDATE()");
        //    DateTime CurrentDate = dateQuery.AsEnumerable().First();
        //    if (CurrentAccount != null && CurrentPersonnel != null)
        //    {
        //        List<xLog> lstLogs = new List<xLog>();
        //        foreach (var entry in changeTrack)
        //        {
        //            if (entry.Entity != null)
        //            {
        //                xLog log = new xLog()
        //                {
        //                    IDPersonnel = CurrentPersonnel.KeyID,
        //                    AccessDate = CurrentDate,
        //                    TableName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name,
        //                    State = entry.State.ToString()
        //                };

        //                if (entry.State == EntityState.Added)
        //                {
        //                    var qColumnsKey = new List<ColumnKey>(GetPrimaryKeys(log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.PK_ColumnName).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsNew = entry.Entity.ObjectToDictionary();

        //                    foreach (var key in qColumnsKey)
        //                    {
        //                        if (key.PK_Indentity)
        //                            ParamsNew.Remove(key.PK_ColumnName);
        //                    }

        //                    foreach (var key in qColumnsKey)
        //                    {
        //                        if (key.PK_Indentity)
        //                        {
        //                            int? KeyID = SaveInsert(log.TableName, ParamsNew);
        //                            if (KeyID.HasValue)
        //                            {
        //                                if (KeyID == 0)
        //                                    return new Exception($"Insert {log.TableName} not success");
        //                                else
        //                                    entry.CurrentValues[key.PK_ColumnName] = KeyID.Value;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            int? KeyID = SaveInsert(log.TableName, ParamsNew);
        //                            if (KeyID.HasValue)
        //                            {
        //                                if (KeyID == 0)
        //                                    return new Exception($"Insert {log.TableName} not success");
        //                            }
        //                        }
        //                    }

        //                    log.OldValue = new Dictionary<string, object>().SerializeJSON();
        //                    log.NewValue = entry.Entity.SerializeJSON();
        //                    lstLogs.Add(log);
        //                }
        //                else if (entry.State == EntityState.Modified)
        //                {
        //                    var qColumnsKey = new List<ColumnKey>(GetPrimaryKeys(log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.PK_ColumnName).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsOld = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsUpdate = new Dictionary<string, object>();

        //                    foreach (string prop in entry.OriginalValues.PropertyNames)
        //                    {
        //                        ParamsOld.Add(prop, entry.OriginalValues[prop]);
        //                    }

        //                    foreach (string prop in entry.CurrentValues.PropertyNames)
        //                    {
        //                        ParamsNew.Add(prop, entry.CurrentValues[prop]);
        //                    }

        //                    foreach (ColumnKey key in qColumnsKey)
        //                    {
        //                        ParamsKey.Add(key.PK_ColumnName, entry.OriginalValues[key.PK_ColumnName]);
        //                    }

        //                    foreach (string prop in qColumnsNotKey)
        //                    {
        //                        object OldValue = ParamsOld[prop];
        //                        object NewValue = ParamsNew[prop];

        //                        if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { ParamsUpdate.Add(prop, NewValue); }
        //                        else if (OldValue != null && NewValue == null) { ParamsUpdate.Add(prop, NewValue); }
        //                        else if (OldValue == null && NewValue != null) { ParamsUpdate.Add(prop, NewValue); }
        //                        else { }
        //                    }

        //                    SaveUpdate(log.TableName, ParamsKey, ParamsUpdate);

        //                    log.OldValue = ParamsOld.SerializeJSON();
        //                    log.NewValue = ParamsNew.SerializeJSON();
        //                    lstLogs.Add(log);
        //                }
        //                else if (entry.State == EntityState.Deleted)
        //                {
        //                    var qColumnsKey = new List<ColumnKey>(GetPrimaryKeys(log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.PK_ColumnName).ToList(), entry.OriginalValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsKey = new Dictionary<string, object>();

        //                    foreach (ColumnKey prop in qColumnsKey)
        //                    {
        //                        ParamsKey.Add(prop.PK_ColumnName, entry.OriginalValues[prop.PK_ColumnName]);
        //                    }

        //                    SaveDelete(log.TableName, ParamsKey);

        //                    log.OldValue = entry.Entity.SerializeJSON();
        //                    log.NewValue = new Dictionary<string, object>().SerializeJSON();
        //                    lstLogs.Add(log);
        //                }
        //                entry.State = EntityState.Unchanged;
        //            }
        //        }

        //        #region Save Log
        //        foreach (var log in lstLogs)
        //        {
        //            Dictionary<string, object> dInsert = new Dictionary<string, object>();
        //            dInsert.Add("IDPersonnel", log.IDPersonnel);
        //            dInsert.Add("AccessDate", log.AccessDate);
        //            dInsert.Add("State", log.State);
        //            dInsert.Add("TableName", log.TableName);
        //            dInsert.Add("OldValue", log.OldValue);
        //            dInsert.Add("NewValue", log.NewValue);
        //            int? KeyID = SaveInsert(typeof(xLog).Name, dInsert);
        //            if (KeyID.HasValue && KeyID == 0) return new Exception($"Insert {typeof(xLog).Name} not success");
        //        }
        //        #endregion

        //        return null;
        //    }
        //    else { return new Exception("CurrentAccount is null or CurrentPersonnel is null"); }
        //}
        //public List<ColumnKey> GetPrimaryKeys(string TableName)
        //{
        //    var qColumnsKey = Module.ListKeys.Where(x => x.PK_TableName.Equals(TableName)).ToList();
        //    return qColumnsKey ?? new List<ColumnKey>();
        //}
        //public List<ColumnKey> GetForeignKeys(string TableName)
        //{
        //    var qColumnsKey = Module.ListKeys.Where(x => x.FK_TableName.Equals(TableName)).ToList();
        //    return qColumnsKey ?? new List<ColumnKey>();
        //}
        //public List<string> GetColumnNotKeys(List<string> lstColumnKeys, List<string> lstColumns, string TableName)
        //{
        //    var qColumnsNotKey = lstColumns.Except(lstColumnKeys).ToList();
        //    return qColumnsNotKey ?? new List<string>();
        //}
        //public int? SaveInsert(string TableName, Dictionary<string, object> dParams)
        //{
        //    string qFormat = $"INSERT INTO {{0}} ({{1}}) VALUES ({{2}}) SELECT SCOPE_IDENTITY()";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    string qFields = "";
        //    string qParams = "";

        //    int i = 0;
        //    int length = dParams.Count - 1;
        //    dParams.ToList().ForEach(x =>
        //    {
        //        qFields += $"{x.Key}{(i < length ? ", " : "")}";
        //        qParams += $"@{x.Key}{(i < length ? ", " : "")}";
        //        i++;
        //        parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
        //    });

        //    decimal? res = Database.SqlQuery<decimal?>(string.Format(qFormat, TableName, qFields, qParams), parameters.ToArray()).FirstOrDefault();

        //    if (res.HasValue) { return Convert.ToInt32(res.Value); }
        //    else { return null; }
        //}
        //public void SaveUpdate(string TableName, Dictionary<string, object> dParamKeys, Dictionary<string, object> dParamValues)
        //{
        //    string qFormat = $"UPDATE {{0}} SET {{1}} WHERE {{2}}";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    string qConditions = "";
        //    string qAssigns = "";

        //    int i = 0;
        //    int length = dParamKeys.Count - 1;
        //    dParamKeys.ToList().ForEach(x =>
        //    {
        //        qConditions += $"{x.Key}=@{x.Key} {(i++ < length ? " AND " : "")}";
        //        parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
        //    });

        //    i = 0;
        //    length = dParamValues.Count - 1;
        //    dParamValues.ToList().ForEach(x =>
        //    {
        //        qAssigns += $"{x.Key}=@{x.Key}{(i++ < length ? ", " : "")}";
        //        parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
        //    });

        //    Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qAssigns, qConditions), parameters.ToArray());
        //}
        //public void SaveDelete(string TableName, Dictionary<string, object> dParamKeys)
        //{
        //    string qFormat = $"DELETE FROM {{0}} WHERE {{1}}";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    string qConditions = "";

        //    int i = 0;
        //    int length = dParamKeys.Count - 1;
        //    dParamKeys.ToList().ForEach(x =>
        //    {
        //        qConditions += $"{x.Key}=@{x.Key} {(i++ < length ? " AND " : "")}";
        //        parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
        //    });

        //    Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qConditions), parameters.ToArray());
        //}
        //public DbRawSqlQuery SearchRange(string TableName, Type type, Dictionary<string, object> dParamKeysFrom, Dictionary<string, object> dParamKeysTo)
        //{
        //    string query = "";
        //    string qSelectFormat = $"SELECT TOP {Module.RowsInPage} * FROM {{0}} ";
        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count > 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} BETWEEN {1} AND {2} {3}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysFrom.Count - 1;
        //        dParamKeysFrom.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}From", $"@{x.Key}To", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}From", Value = x.Value ?? DBNull.Value });
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}To", Value = dParamKeysTo[x.Key] ?? DBNull.Value });
        //        });

        //        query = string.Format(qSelectFormat, TableName, qConditions);
        //    }
        //    else if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count == 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} >= {1} {2}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysFrom.Count - 1;
        //        dParamKeysFrom.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
        //        });

        //        query = string.Format(qSelectFormat, TableName, qConditions);
        //    }
        //    else if (dParamKeysFrom.Count == 0 && dParamKeysTo.Count > 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} <= {1} {2}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysTo.Count - 1;
        //        dParamKeysTo.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
        //        });

        //        query = string.Format(qSelectFormat, TableName, qConditions);
        //    }
        //    else
        //    {
        //        query = string.Format(qSelectFormat, TableName);
        //    }

        //    return Database.SqlQuery(type, query, parameters.ToArray());
        //}
        //public Int32 GetTotalRow(string TableName, Dictionary<string, object> dParamKeysFrom, Dictionary<string, object> dParamKeysTo)
        //{
        //    string query = "";
        //    string qCountFormat = "SELECT COUNT(*) FROM ({0}) TEMP";
        //    string qSelectFormat = $"SELECT TOP {Module.RowsInPage} * FROM {{0}} ";
        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count > 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} BETWEEN {1} AND {2} {3}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysFrom.Count - 1;
        //        dParamKeysFrom.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}From", $"@{x.Key}To", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}From", Value = x.Value ?? DBNull.Value });
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}To", Value = dParamKeysTo[x.Key] ?? DBNull.Value });
        //        });

        //        query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
        //    }
        //    else if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count == 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} >= {1} {2}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysFrom.Count - 1;
        //        dParamKeysFrom.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
        //        });

        //        query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
        //    }
        //    else if (dParamKeysFrom.Count == 0 && dParamKeysTo.Count > 0)
        //    {
        //        qSelectFormat += "WHERE {1}";
        //        string qConditionFormat = "{0} <= {1} {2}";
        //        string qConditions = "";

        //        int i = 0;
        //        int length = dParamKeysTo.Count - 1;
        //        dParamKeysTo.ToList().ForEach(x =>
        //        {
        //            qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
        //            parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
        //        });

        //        query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
        //    }
        //    else
        //    {
        //        query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName));
        //    }

        //    return Database.SqlQuery<Int32>(query, parameters.ToArray()).First();
        //}
        #endregion


        public override int SaveChanges()
        {
            List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
            .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
            .ToList());
            var lstObjs = AutoLog(entries);
            int res = base.SaveChanges();
            SaveLog(lstObjs);
            return res;
        }
        private List<ObjectBinding> AutoLog(List<DbEntityEntry> lstEntries)
        {
            List<ObjectBinding> lstObjs = new List<ObjectBinding>();
            if (CurrentAccount != null && CurrentPersonnel != null)
            {
                foreach (var entry in lstEntries)
                {
                    ObjectBinding obj = new ObjectBinding();

                    if (entry.State == EntityState.Added)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.CurrentValues = entry.CurrentValues;
                        lstObjs.Add(obj);
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.OriginalValues = entry.OriginalValues;
                        obj.CurrentValues = entry.CurrentValues;
                        lstObjs.Add(obj);
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.OriginalValues = entry.OriginalValues;
                        lstObjs.Add(obj);
                    }
                }
            }
            return lstObjs;
        }
        private async void SaveLog(List<ObjectBinding> lstObjs)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    using (zModel db = new zModel())
                    {
                        var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                        DateTime CurrentDate = dateQuery.AsEnumerable().First();
                        foreach (var obj in lstObjs)
                        {
                            xLog log = new xLog();
                            log.IDPersonnel = CurrentPersonnel.KeyID;
                            log.AccessDate = CurrentDate;
                            log.TableName = ObjectContext.GetObjectType(obj.Entity.Entity.GetType()).Name;
                            log.State = obj.State.ToString();

                            if (obj.OriginalValues != null)
                            {
                                Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                                foreach (string prop in obj.OriginalValues.PropertyNames) { ParamsValues.Add(prop, obj.OriginalValues[prop]); }
                                log.OldValue = ParamsValues.SerializeJSON();
                            }
                            else
                            {
                                Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                                log.OldValue = ParamsValues.SerializeJSON();
                            }
                            if (obj.CurrentValues != null)
                            {
                                Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                                foreach (string prop in obj.CurrentValues.PropertyNames) { ParamsValues.Add(prop, obj.CurrentValues[prop]); }
                                log.NewValue = ParamsValues.SerializeJSON();
                            }
                            else
                            {
                                Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                                log.NewValue = ParamsValues.SerializeJSON();
                            }
                            db.xLog.Add(log);
                        }
                        db.SaveChanges();
                    }
                });
            }
            catch { }
        }
    }

    public partial class zModel
    {
        private xPersonnel _CurrentPersonnel;
        private xAccount _CurrentAccount;
        public xPersonnel CurrentPersonnel { get { return _CurrentPersonnel = _CurrentPersonnel ?? Module.CurPer; } }
        public xAccount CurrentAccount { get { return _CurrentAccount = _CurrentAccount ?? Module.CurAcc; } }
    }

    public class ColumnKey
    {
        public string PK_TableName { get; set; }
        public string PK_ColumnName { get; set; }
        public bool PK_Indentity { get; set; }
        public string FK_TableName { get; set; }
        public string FK_ColumnName { get; set; }
        public bool FK_Indentity { get; set; }
    }

    public class ObjectBinding
    {
        public EntityState State { get; set; }
        public DbEntityEntry Entity { get; set; }
        public DbPropertyValues CurrentValues { get; set; }
        public DbPropertyValues OriginalValues { get; set; }
    }
}
