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
        #region Code 1
        //static bool acLog = true;
        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return Convert.ToInt32(true);
        //        //List<DbEntityEntry> entries = null;
        //        //entries = base.ChangeTracker.Entries()
        //        //.Where(e => e.Entity.GetType().Name.StartsWith("e") && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
        //        //.ToList();
        //        //if (entries != null && entries.Count > 0)
        //        //    AutoLog(entries);
        //    }
        //    catch { return Convert.ToInt32(false); }
        //    //return base.SaveChanges();
        //}

        //public void AutoLog(List<DbEntityEntry> changeTrack)
        //{
        //    var s = this.CurrentAccount;
        //    if (acLog && CurrentPersonnel != null)
        //    {
        //        List<xUserLog> AuditLogs = new List<xUserLog>();
        //        //var changeTrack = Context.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
        //        foreach (var entry in changeTrack)
        //        {
        //            if (entry.Entity != null)
        //            {
        //                xUserLog nLog = null;
        //                string entityName = string.Empty;
        //                string state = string.Empty;
        //                switch (entry.State)
        //                {
        //                    case EntityState.Modified:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = CurrentPersonnel.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.OriginalValues.PropertyNames)
        //                        {
        //                            object currentValue = entry.CurrentValues[prop];
        //                            object originalValue = entry.OriginalValues[prop];
        //                            if (!currentValue.Equals(originalValue))
        //                            {
        //                                string nValue = Convert.ToString(currentValue).Trim();
        //                                string oValue = Convert.ToString(originalValue).Trim();
        //                                if (!string.IsNullOrEmpty((nValue + oValue)))
        //                                {
        //                                    nLog.NewValue += string.Format("{0}: [{1}] -> [{2}]\r\n", prop, oValue, nValue);
        //                                }
        //                            }
        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    case EntityState.Added:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = CurrentPersonnel.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.CurrentValues.PropertyNames)
        //                        {
        //                            string nValue = Convert.ToString(entry.CurrentValues[prop]).Trim();
        //                            if (!string.IsNullOrEmpty(nValue))
        //                                nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, nValue);

        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    case EntityState.Deleted:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = CurrentPersonnel.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.OriginalValues.PropertyNames)
        //                        {
        //                            string oValue = Convert.ToString(entry.OriginalValues[prop]).Trim();
        //                            if (!string.IsNullOrEmpty(oValue))
        //                                nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, oValue);

        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        if (AuditLogs != null && AuditLogs.Count > 0)
        //        {
        //            try
        //            {
        //                acLog = false;
        //                using (zModel db = new zModel())
        //                {
        //                    db.xUserLog.AddRange(AuditLogs);
        //                    db.SaveChanges();
        //                }
        //            }
        //            catch { }
        //            finally { acLog = true; }
        //        }
        //    }
        //}
        #endregion

        #region Code 2
        //SqlConnection Conn;
        //SqlTransaction Tran;
        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
        //        .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
        //        .ToList());
        //        if (entries != null && entries.Count > 0)
        //            AutoLog(entries);
        //        return Convert.ToInt32(true);
        //    }
        //    catch { return Convert.ToInt32(false); }
        //}
        //public void AutoLog(List<DbEntityEntry> changeTrack)
        //{
        //    zModel db = new zModel();
        //    var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
        //    DateTime CurrentDate = dateQuery.AsEnumerable().First();
        //    Conn = new SqlConnection(db.Database.Connection.ConnectionString);
        //    if (CurrentAccount != null && CurrentPersonnel != null)
        //    {
        //        try
        //        {
        //            BeginTransaction();

        //            string qSelectPrimaryKey =
        //                "select distinct Tab.TABLE_NAME, Col.COLUMN_NAME, p.IS_IDENTITY " +
        //                "from INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab " +
        //                "left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col on Col.Table_Name = Tab.Table_Name " +
        //                "left join ( " +
        //                "	select c.name cName, c.is_identity IS_IDENTITY, t.name tName " +
        //                "	from sys.tables t " +
        //                "	left join sys.columns c on c.object_id=t.object_id) p on p.cName=Col.COLUMN_NAME and p.tName=Tab.TABLE_NAME " +
        //                "WHERE Col.Constraint_Name = Tab.Constraint_Name AND Constraint_Type = 'PRIMARY KEY'";
        //            SqlCommand cmdSelectPrimaryKey = new SqlCommand(qSelectPrimaryKey, Conn, Tran);
        //            List<Dictionary<string, object>> lstPrimaryKeys =
        //                new List<Dictionary<string, object>>(
        //                    cmdSelectPrimaryKey.
        //                    ExecuteReader().
        //                    CreateObjects(
        //                        new Dictionary<string, Type>()
        //                        {
        //                            { "TABLE_NAME", typeof(String) },
        //                            { "COLUMN_NAME", typeof(String) },
        //                            { "IS_IDENTITY", typeof(Boolean) }
        //                        }));

        //            List<xLog> lstLogs = new List<xLog>();
        //            foreach (var entry in changeTrack)
        //            {
        //                if (entry.Entity != null)
        //                {
        //                    xLog log = new xLog()
        //                    {
        //                        IDPersonnel = CurrentPersonnel.KeyID,
        //                        AccessDate = CurrentDate,
        //                        TableName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name,
        //                        State = entry.State.ToString()
        //                    };

        //                    if (entry.State == EntityState.Added)
        //                    {
        //                        var qColumnsKey = lstPrimaryKeys.Where(x => x.Any(y => y.Value.Equals(log.TableName))).FirstOrDefault().Where(x => x.Key.Equals("COLUMN_NAME")).Select(x => x.Value).ToList();
        //                        var qColumnsNotKey = entry.CurrentValues.PropertyNames.Except(qColumnsKey).ToList();

        //                        Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsOld = new Dictionary<string, object>();
        //                        foreach (string prop in qColumnsNotKey)
        //                        {
        //                            ParamsNew.Add(prop, entry.CurrentValues[prop]);
        //                        }
        //                        ParamsNew.Add(qColumnsKey.FirstOrDefault().ToString(), SaveInsert(Conn, Tran, log.TableName, ParamsNew));
        //                        log.OldValue = ParamsOld.SerializeJSON();
        //                        log.NewValue = ParamsNew.SerializeJSON();
        //                        lstLogs.Add(log);
        //                    }
        //                    else if (entry.State == EntityState.Modified)
        //                    {
        //                        var qColumnsKey = lstPrimaryKeys.Where(x => x.Any(y => y.Value.Equals(log.TableName))).FirstOrDefault().Where(x => x.Key.Equals("COLUMN_NAME")).Select(x => x.Value).ToList();
        //                        var qColumnsNotKey = entry.CurrentValues.PropertyNames.Except(qColumnsKey).ToList();

        //                        Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsOld = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsUpdate = new Dictionary<string, object>();
        //                        foreach (string prop in qColumnsKey)
        //                        {
        //                            ParamsKey.Add(prop, entry.OriginalValues[prop]);
        //                        }
        //                        foreach (string prop in qColumnsNotKey)
        //                        {
        //                            object OldValue = entry.OriginalValues[prop];
        //                            object NewValue = entry.CurrentValues[prop];

        //                            ParamsOld.Add(prop, OldValue);
        //                            ParamsNew.Add(prop, NewValue);

        //                            if (OldValue == null && NewValue == null) { }
        //                            else if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue))
        //                                ParamsUpdate.Add(prop, NewValue);
        //                            else if (OldValue != null && NewValue == null)
        //                                ParamsUpdate.Add(prop, NewValue);
        //                            else if (OldValue == null && NewValue != null)
        //                                ParamsUpdate.Add(prop, NewValue);
        //                        }
        //                        SaveUpdate(Conn, Tran, log.TableName, ParamsKey, ParamsUpdate);
        //                        ParamsKey.ToList().ForEach(x =>
        //                        {
        //                            ParamsOld.Add(x.Key, x.Value);
        //                            ParamsNew.Add(x.Key, x.Value);
        //                        });
        //                        log.OldValue = ParamsOld.SerializeJSON();
        //                        log.NewValue = ParamsNew.SerializeJSON();
        //                        lstLogs.Add(log);
        //                    }
        //                    else if (entry.State == EntityState.Deleted)
        //                    {
        //                        var qColumnsKey = lstPrimaryKeys.Where(x => x.Any(y => y.Value.Equals(log.TableName))).FirstOrDefault().Where(x => x.Key.Equals("COLUMN_NAME")).Select(x => x.Value).ToList();
        //                        var qColumnsNotKey = entry.OriginalValues.PropertyNames.Except(qColumnsKey).ToList();

        //                        Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                        Dictionary<string, object> ParamsOld = new Dictionary<string, object>();

        //                        foreach (string prop in qColumnsKey)
        //                        {
        //                            ParamsKey.Add(prop, entry.OriginalValues[prop]);
        //                        }
        //                        foreach (string prop in qColumnsNotKey)
        //                        {
        //                            ParamsOld.Add(prop, entry.OriginalValues[prop]);
        //                        }
        //                        SaveDelete(Conn, Tran, log.TableName, ParamsKey);
        //                        ParamsKey.ToList().ForEach(x => { ParamsOld.Add(x.Key, x.Value); });
        //                        log.OldValue = ParamsOld.SerializeJSON();
        //                        log.NewValue = ParamsNew.SerializeJSON();
        //                        lstLogs.Add(log);
        //                    }
        //                }
        //            }
        //            foreach (var log in lstLogs)
        //            {
        //                Dictionary<string, object> dInsert = new Dictionary<string, object>();
        //                dInsert.Add("IDPersonnel", log.IDPersonnel);
        //                dInsert.Add("AccessDate", log.AccessDate);
        //                dInsert.Add("State", log.State);
        //                dInsert.Add("TableName", log.TableName);
        //                dInsert.Add("OldValue", log.OldValue);
        //                dInsert.Add("NewValue", log.NewValue);
        //                SaveInsert(Conn, Tran, "xLog", dInsert);
        //            }
        //            Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            Rollback();
        //        }
        //    }
        //}
        //public int SaveInsert(SqlConnection Conn, SqlTransaction Tran, string TableName, Dictionary<string, object> dParams)
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
        //    SqlCommand cmd = new SqlCommand(string.Format(qFormat, TableName, qFields, qParams), Conn, Tran);
        //    cmd.Parameters.AddRange(parameters.ToArray());
        //    return (int)(decimal)cmd.ExecuteScalar();
        //}
        //public void SaveUpdate(SqlConnection Conn, SqlTransaction Tran, string TableName, Dictionary<string, object> dParamKeys, Dictionary<string, object> dParamValues)
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

        //    SqlCommand cmd = new SqlCommand(string.Format(qFormat, TableName, qAssigns, qConditions), Conn, Tran);
        //    cmd.Parameters.AddRange(parameters.ToArray());
        //    cmd.ExecuteNonQuery();
        //}
        //public void SaveDelete(SqlConnection Conn, SqlTransaction Tran, string TableName, Dictionary<string, object> dParamKeys)
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

        //    SqlCommand cmd = new SqlCommand(string.Format(qFormat, TableName, qConditions), Conn, Tran);
        //    cmd.Parameters.AddRange(parameters.ToArray());
        //    cmd.ExecuteNonQuery();
        //}
        //public void BeginTransaction()
        //{
        //    Conn.Open();
        //    Tran = Conn.BeginTransaction();
        //}
        //public void Commit()
        //{
        //    Tran.Commit();
        //    Conn.Close();
        //}
        //public void Rollback()
        //{
        //    Tran.Rollback();
        //    Conn.Close();
        //}
        #endregion

        #region Code 3
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
        //public override Task<int> SaveChangesAsync()
        //{
        //    Task<int> task = Task.Run<int>(() =>
        //    {
        //        List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
        //            .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
        //            .ToList());
        //        if (entries != null && entries.Count > 0)
        //        {
        //            Exception exception = AutoLog(entries);
        //            if (exception != null) throw exception;
        //        }
        //        return Convert.ToInt32(true);
        //    });
        //    return task;
        //}
        //private Exception AutoLog(List<DbEntityEntry> changeTrack)
        //{
        //    var dateQuery = Database.SqlQuery<DateTime>("SELECT GETDATE()");
        //    DateTime CurrentDate = dateQuery.AsEnumerable().First();
        //    if (CurrentAccount != null && CurrentPersonnel != null)
        //    {
        //        List<ColumnKey> lstPrimaryKeys = new List<ColumnKey>(GetPrimaryKeys());
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
        //                    var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsOld = new Dictionary<string, object>();

        //                    foreach (string prop in qColumnsNotKey)
        //                    {
        //                        ParamsNew.Add(prop, entry.CurrentValues[prop]);
        //                    }

        //                    foreach (var key in qColumnsKey)
        //                    {
        //                        if (!key.IS_IDENTITY)
        //                            ParamsNew.Add(key.COLUMN_NAME, entry.CurrentValues[key.COLUMN_NAME]);

        //                        int? KeyID = SaveInsert(log.TableName, ParamsNew);
        //                        if (KeyID.HasValue && KeyID == 0) return new Exception($"Insert {log.TableName} not success");

        //                        if (KeyID.HasValue && key.IS_IDENTITY)
        //                        {
        //                            entry.CurrentValues[key.COLUMN_NAME] = KeyID.Value;
        //                            ParamsNew.Add(key.COLUMN_NAME, KeyID.Value);
        //                        }
        //                    }

        //                    log.OldValue = ParamsOld.SerializeJSON();
        //                    log.NewValue = ParamsNew.SerializeJSON();
        //                    lstLogs.Add(log);
        //                }
        //                else if (entry.State == EntityState.Modified)
        //                {
        //                    var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsOld = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsUpdate = new Dictionary<string, object>();

        //                    foreach (ColumnKey prop in qColumnsKey)
        //                    {
        //                        ParamsKey.Add(prop.COLUMN_NAME, entry.OriginalValues[prop.COLUMN_NAME]);
        //                    }
        //                    foreach (string prop in qColumnsNotKey)
        //                    {
        //                        object OldValue = entry.OriginalValues[prop];
        //                        object NewValue = entry.CurrentValues[prop];

        //                        ParamsOld.Add(prop, OldValue);
        //                        ParamsNew.Add(prop, NewValue);

        //                        if (OldValue == null && NewValue == null) { }
        //                        else if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue))
        //                            ParamsUpdate.Add(prop, NewValue);
        //                        else if (OldValue != null && NewValue == null)
        //                            ParamsUpdate.Add(prop, NewValue);
        //                        else if (OldValue == null && NewValue != null)
        //                            ParamsUpdate.Add(prop, NewValue);
        //                    }

        //                    SaveUpdate(log.TableName, ParamsKey, ParamsUpdate);
        //                    ParamsKey.ToList().ForEach(x =>
        //                    {
        //                        ParamsOld.Add(x.Key, x.Value);
        //                        ParamsNew.Add(x.Key, x.Value);
        //                    });

        //                    log.OldValue = ParamsOld.SerializeJSON();
        //                    log.NewValue = ParamsNew.SerializeJSON();
        //                    lstLogs.Add(log);
        //                }
        //                else if (entry.State == EntityState.Deleted)
        //                {
        //                    var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
        //                    var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.OriginalValues.PropertyNames.Select(x => x).ToList(), log.TableName));

        //                    Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
        //                    Dictionary<string, object> ParamsOld = new Dictionary<string, object>();

        //                    foreach (ColumnKey prop in qColumnsKey)
        //                    {
        //                        ParamsKey.Add(prop.COLUMN_NAME, entry.OriginalValues[prop.COLUMN_NAME]);
        //                    }
        //                    foreach (string prop in qColumnsNotKey)
        //                    {
        //                        ParamsOld.Add(prop, entry.OriginalValues[prop]);
        //                    }

        //                    SaveDelete(log.TableName, ParamsKey);
        //                    ParamsKey.ToList().ForEach(x => { ParamsOld.Add(x.Key, x.Value); });

        //                    log.OldValue = ParamsOld.SerializeJSON();
        //                    log.NewValue = ParamsNew.SerializeJSON();
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
        //public List<ColumnKey> GetPrimaryKeys()
        //{
        //    string qSelectPrimaryKey =
        //          "select distinct Tab.TABLE_NAME, Col.COLUMN_NAME, p.IS_IDENTITY " +
        //          "from INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab " +
        //          "left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col on Col.Table_Name = Tab.Table_Name " +
        //          "left join ( " +
        //          "	select c.name cName, c.is_identity IS_IDENTITY, t.name tName " +
        //          "	from sys.tables t " +
        //          "	left join sys.columns c on c.object_id=t.object_id) p on p.cName=Col.COLUMN_NAME and p.tName=Tab.TABLE_NAME " +
        //          "WHERE Col.Constraint_Name = Tab.Constraint_Name AND Constraint_Type = 'PRIMARY KEY'";

        //    List<ColumnKey> lstPrimaryKeys = Database.SqlQuery<ColumnKey>(qSelectPrimaryKey).ToList();
        //    return lstPrimaryKeys ?? new List<ColumnKey>();
        //}
        //public List<ColumnKey> GetColumnKeys(List<ColumnKey> lstPrimaryKeys, string TableName)
        //{
        //    var qColumnsKey = lstPrimaryKeys.Where(x => x.TABLE_NAME.Equals(TableName)).ToList();
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
        //    string qFormat = "SELECT * FROM {0} WHERE {1}";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    string qConditionFormat = "{0} BETWEEN {1} AND {2} {3}";
        //    string qConditions = "";

        //    int i = 0;
        //    int length = dParamKeysFrom.Count - 1;
        //    dParamKeysFrom.ToList().ForEach(x =>
        //    {
        //        qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}From", $"@{x.Key}To", $"{ (i++ < length ? " AND " : "")}");
        //        parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}From", Value = x.Value ?? DBNull.Value });
        //        parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}To", Value = dParamKeysTo[x.Key] ?? DBNull.Value });
        //    });

        //    return Database.SqlQuery(type, string.Format(qFormat, TableName, qConditions), parameters.ToArray());
        //}
        #endregion

        #region Code 4
        public override int SaveChanges()
        {
            List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
            .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
            .ToList());
            if (entries != null && entries.Count > 0)
            {
                Exception exception = AutoLog(entries);
                if (exception != null) throw exception;
            }
            return Convert.ToInt32(true);
        }
        private Exception AutoLog(List<DbEntityEntry> changeTrack)
        {
            var dateQuery = Database.SqlQuery<DateTime>("SELECT GETDATE()");
            DateTime CurrentDate = dateQuery.AsEnumerable().First();
            if (CurrentAccount != null && CurrentPersonnel != null)
            {
                List<ColumnKey> lstPrimaryKeys = new List<ColumnKey>(Module.ListPrimaryKeys);

                List<xLog> lstLogs = new List<xLog>();
                foreach (var entry in changeTrack)
                {
                    if (entry.Entity != null)
                    {
                        xLog log = new xLog()
                        {
                            IDPersonnel = CurrentPersonnel.KeyID,
                            AccessDate = CurrentDate,
                            TableName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name,
                            State = entry.State.ToString()
                        };

                        if (entry.State == EntityState.Added)
                        {
                            var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
                            var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

                            Dictionary<string, object> ParamsNew = entry.Entity.ObjectToDictionary();

                            foreach (var key in qColumnsKey)
                            {
                                if (key.IS_IDENTITY)
                                    ParamsNew.Remove(key.COLUMN_NAME);
                            }

                            foreach (var key in qColumnsKey)
                            {
                                if (key.IS_IDENTITY)
                                {
                                    int? KeyID = SaveInsert(log.TableName, ParamsNew);
                                    if (KeyID.HasValue)
                                    {
                                        if (KeyID == 0)
                                            return new Exception($"Insert {log.TableName} not success");
                                        else
                                            entry.CurrentValues[key.COLUMN_NAME] = KeyID.Value;
                                    }
                                }
                            }

                            log.OldValue = new Dictionary<string, object>().SerializeJSON();
                            log.NewValue = entry.Entity.SerializeJSON();
                            lstLogs.Add(log);
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
                            var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.CurrentValues.PropertyNames.Select(x => x).ToList(), log.TableName));

                            Dictionary<string, object> ParamsKey = new Dictionary<string, object>();
                            Dictionary<string, object> ParamsNew = new Dictionary<string, object>();
                            Dictionary<string, object> ParamsOld = new Dictionary<string, object>();
                            Dictionary<string, object> ParamsUpdate = new Dictionary<string, object>();

                            foreach (string prop in entry.OriginalValues.PropertyNames)
                            {
                                ParamsOld.Add(prop, entry.OriginalValues[prop]);
                            }

                            foreach (string prop in entry.CurrentValues.PropertyNames)
                            {
                                ParamsNew.Add(prop, entry.CurrentValues[prop]);
                            }

                            foreach (ColumnKey key in qColumnsKey)
                            {
                                ParamsKey.Add(key.COLUMN_NAME, entry.OriginalValues[key.COLUMN_NAME]);
                            }

                            foreach (string prop in qColumnsNotKey)
                            {
                                object OldValue = ParamsOld[prop];
                                object NewValue = ParamsNew[prop];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { ParamsUpdate.Add(prop, NewValue); }
                                else if (OldValue != null && NewValue == null) { ParamsUpdate.Add(prop, NewValue); }
                                else if (OldValue == null && NewValue != null) { ParamsUpdate.Add(prop, NewValue); }
                                else { }
                            }

                            SaveUpdate(log.TableName, ParamsKey, ParamsUpdate);

                            log.OldValue = ParamsOld.SerializeJSON();
                            log.NewValue = ParamsNew.SerializeJSON();
                            lstLogs.Add(log);
                        }
                        else if (entry.State == EntityState.Deleted)
                        {
                            var qColumnsKey = new List<ColumnKey>(GetColumnKeys(lstPrimaryKeys, log.TableName));
                            var qColumnsNotKey = new List<string>(GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), entry.OriginalValues.PropertyNames.Select(x => x).ToList(), log.TableName));

                            Dictionary<string, object> ParamsKey = new Dictionary<string, object>();

                            foreach (ColumnKey prop in qColumnsKey)
                            {
                                ParamsKey.Add(prop.COLUMN_NAME, entry.OriginalValues[prop.COLUMN_NAME]);
                            }

                            SaveDelete(log.TableName, ParamsKey);

                            log.OldValue = entry.Entity.SerializeJSON();
                            log.NewValue = new Dictionary<string, object>().SerializeJSON();
                            lstLogs.Add(log);
                        }
                        entry.State = EntityState.Unchanged;
                    }
                }

                #region Save Log
                foreach (var log in lstLogs)
                {
                    Dictionary<string, object> dInsert = new Dictionary<string, object>();
                    dInsert.Add("IDPersonnel", log.IDPersonnel);
                    dInsert.Add("AccessDate", log.AccessDate);
                    dInsert.Add("State", log.State);
                    dInsert.Add("TableName", log.TableName);
                    dInsert.Add("OldValue", log.OldValue);
                    dInsert.Add("NewValue", log.NewValue);
                    int? KeyID = SaveInsert(typeof(xLog).Name, dInsert);
                    if (KeyID.HasValue && KeyID == 0) return new Exception($"Insert {typeof(xLog).Name} not success");
                }
                #endregion

                return null;
            }
            else { return new Exception("CurrentAccount is null or CurrentPersonnel is null"); }
        }
        public List<ColumnKey> GetColumnKeys(List<ColumnKey> lstPrimaryKeys, string TableName)
        {
            var qColumnsKey = lstPrimaryKeys.Where(x => x.TABLE_NAME.Equals(TableName)).ToList();
            return qColumnsKey ?? new List<ColumnKey>();
        }
        public List<string> GetColumnNotKeys(List<string> lstColumnKeys, List<string> lstColumns, string TableName)
        {
            var qColumnsNotKey = lstColumns.Except(lstColumnKeys).ToList();
            return qColumnsNotKey ?? new List<string>();
        }
        public int? SaveInsert(string TableName, Dictionary<string, object> dParams)
        {
            string qFormat = $"INSERT INTO {{0}} ({{1}}) VALUES ({{2}}) SELECT SCOPE_IDENTITY()";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string qFields = "";
            string qParams = "";

            int i = 0;
            int length = dParams.Count - 1;
            dParams.ToList().ForEach(x =>
            {
                qFields += $"{x.Key}{(i < length ? ", " : "")}";
                qParams += $"@{x.Key}{(i < length ? ", " : "")}";
                i++;
                parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
            });

            decimal? res = Database.SqlQuery<decimal?>(string.Format(qFormat, TableName, qFields, qParams), parameters.ToArray()).FirstOrDefault();

            if (res.HasValue) { return Convert.ToInt32(res.Value); }
            else { return null; }
        }
        public void SaveUpdate(string TableName, Dictionary<string, object> dParamKeys, Dictionary<string, object> dParamValues)
        {
            string qFormat = $"UPDATE {{0}} SET {{1}} WHERE {{2}}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string qConditions = "";
            string qAssigns = "";

            int i = 0;
            int length = dParamKeys.Count - 1;
            dParamKeys.ToList().ForEach(x =>
            {
                qConditions += $"{x.Key}=@{x.Key} {(i++ < length ? " AND " : "")}";
                parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
            });

            i = 0;
            length = dParamValues.Count - 1;
            dParamValues.ToList().ForEach(x =>
            {
                qAssigns += $"{x.Key}=@{x.Key}{(i++ < length ? ", " : "")}";
                parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
            });

            Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qAssigns, qConditions), parameters.ToArray());
        }
        public void SaveDelete(string TableName, Dictionary<string, object> dParamKeys)
        {
            string qFormat = $"DELETE FROM {{0}} WHERE {{1}}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string qConditions = "";

            int i = 0;
            int length = dParamKeys.Count - 1;
            dParamKeys.ToList().ForEach(x =>
            {
                qConditions += $"{x.Key}=@{x.Key} {(i++ < length ? " AND " : "")}";
                parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
            });

            Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qConditions), parameters.ToArray());
        }
        public DbRawSqlQuery SearchRange(string TableName, Type type, Dictionary<string, object> dParamKeysFrom, Dictionary<string, object> dParamKeysTo)
        {
            string query = "";
            string qSelectFormat = $"SELECT TOP {Module.RowsInPage} * FROM {{0}} ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count > 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} BETWEEN {1} AND {2} {3}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysFrom.Count - 1;
                dParamKeysFrom.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}From", $"@{x.Key}To", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}From", Value = x.Value ?? DBNull.Value });
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}To", Value = dParamKeysTo[x.Key] ?? DBNull.Value });
                });

                query = string.Format(qSelectFormat, TableName, qConditions);
            }
            else if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count == 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} >= {1} {2}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysFrom.Count - 1;
                dParamKeysFrom.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
                });

                query = string.Format(qSelectFormat, TableName, qConditions);
            }
            else if (dParamKeysFrom.Count == 0 && dParamKeysTo.Count > 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} <= {1} {2}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysTo.Count - 1;
                dParamKeysTo.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
                });

                query = string.Format(qSelectFormat, TableName, qConditions);
            }
            else
            {
                query = string.Format(qSelectFormat, TableName);
            }

            return Database.SqlQuery(type, query, parameters.ToArray());
        }
        public Int32 GetTotalRow(string TableName, Dictionary<string, object> dParamKeysFrom, Dictionary<string, object> dParamKeysTo)
        {
            string query = "";
            string qCountFormat = "SELECT COUNT(*) FROM ({0}) TEMP";
            string qSelectFormat = $"SELECT TOP {Module.RowsInPage} * FROM {{0}} ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count > 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} BETWEEN {1} AND {2} {3}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysFrom.Count - 1;
                dParamKeysFrom.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}From", $"@{x.Key}To", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}From", Value = x.Value ?? DBNull.Value });
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}To", Value = dParamKeysTo[x.Key] ?? DBNull.Value });
                });

                query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
            }
            else if (dParamKeysFrom.Count > 0 && dParamKeysTo.Count == 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} >= {1} {2}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysFrom.Count - 1;
                dParamKeysFrom.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
                });

                query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
            }
            else if (dParamKeysFrom.Count == 0 && dParamKeysTo.Count > 0)
            {
                qSelectFormat += "WHERE {1}";
                string qConditionFormat = "{0} <= {1} {2}";
                string qConditions = "";

                int i = 0;
                int length = dParamKeysTo.Count - 1;
                dParamKeysTo.ToList().ForEach(x =>
                {
                    qConditions += string.Format(qConditionFormat, x.Key, $"@{x.Key}", $"{ (i++ < length ? " AND " : "")}");
                    parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
                });

                query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName, qConditions));
            }
            else
            {
                query = string.Format(qCountFormat, string.Format(qSelectFormat, TableName));
            }

            return Database.SqlQuery<Int32>(query, parameters.ToArray()).First();
        }
        #endregion
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
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public bool IS_IDENTITY { get; set; }
    }
}
