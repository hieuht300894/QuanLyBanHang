using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EntityModel.DataModel
{

    public class aModel : zModel
    {
        static bool acLog = true;
        public override int SaveChanges()
        {
            List<DbEntityEntry> entries = null;
            try
            {
                entries = base.ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().Name.StartsWith("e") && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
                .ToList();
                if (entries != null && entries.Count > 0)
                    AutoLog(entries);
            }
            catch { }
            return base.SaveChanges();
        }

        public void AutoLog(List<DbEntityEntry> changeTrack)
        {
            var s = this.CurrentAccount;
            if (acLog && CurrentPersonnel != null)
            {
                List<xUserLog> AuditLogs = new List<xUserLog>();
                //var changeTrack = Context.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
                foreach (var entry in changeTrack)
                {
                    if (entry.Entity != null)
                    {
                        xUserLog nLog = null;
                        string entityName = string.Empty;
                        string state = string.Empty;
                        switch (entry.State)
                        {
                            case EntityState.Modified:
                                entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                                state = entry.State.ToString();
                                nLog = new xUserLog
                                {
                                    IDPersonnel = CurrentPersonnel.KeyID,
                                    AccessDate = DateTime.Now,
                                    TableName = entityName,
                                    State = state,
                                    NewValue = "",
                                };
                                foreach (string prop in entry.OriginalValues.PropertyNames)
                                {
                                    object currentValue = entry.CurrentValues[prop];
                                    object originalValue = entry.OriginalValues[prop];
                                    if (!currentValue.Equals(originalValue))
                                    {
                                        string nValue = Convert.ToString(currentValue).Trim();
                                        string oValue = Convert.ToString(originalValue).Trim();
                                        if (!string.IsNullOrEmpty((nValue + oValue)))
                                        {
                                            nLog.NewValue += string.Format("{0}: [{1}] -> [{2}]\r\n", prop, oValue, nValue);
                                        }
                                    }
                                }
                                nLog.NewValue = nLog.NewValue.Trim();
                                if (!string.IsNullOrEmpty(nLog.NewValue))
                                    AuditLogs.Add(nLog);
                                break;
                            case EntityState.Added:
                                entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                                state = entry.State.ToString();
                                nLog = new xUserLog
                                {
                                    IDPersonnel = CurrentPersonnel.KeyID,
                                    AccessDate = DateTime.Now,
                                    TableName = entityName,
                                    State = state,
                                    NewValue = "",
                                };
                                foreach (string prop in entry.CurrentValues.PropertyNames)
                                {
                                    string nValue = Convert.ToString(entry.CurrentValues[prop]).Trim();
                                    if (!string.IsNullOrEmpty(nValue))
                                        nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, nValue);

                                }
                                nLog.NewValue = nLog.NewValue.Trim();
                                if (!string.IsNullOrEmpty(nLog.NewValue))
                                    AuditLogs.Add(nLog);
                                break;
                            case EntityState.Deleted:
                                entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                                state = entry.State.ToString();
                                nLog = new xUserLog
                                {
                                    IDPersonnel = CurrentPersonnel.KeyID,
                                    AccessDate = DateTime.Now,
                                    TableName = entityName,
                                    State = state,
                                    NewValue = "",
                                };
                                foreach (string prop in entry.OriginalValues.PropertyNames)
                                {
                                    string oValue = Convert.ToString(entry.OriginalValues[prop]).Trim();
                                    if (!string.IsNullOrEmpty(oValue))
                                        nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, oValue);

                                }
                                nLog.NewValue = nLog.NewValue.Trim();
                                if (!string.IsNullOrEmpty(nLog.NewValue))
                                    AuditLogs.Add(nLog);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (AuditLogs != null && AuditLogs.Count > 0)
                {
                    try
                    {
                        acLog = false;
                        using (zModel db = new zModel())
                        {
                            db.xUserLog.AddRange(AuditLogs);
                            db.SaveChanges();
                        }
                    }
                    catch { }
                    finally { acLog = true; }
                }
            }
        }
    }
    public partial class zModel
    {
        private xPersonnel _CurrentPersonnel;
        private xAccount _CurrentAccount;
        public xPersonnel CurrentPersonnel
        {
            get { return this._CurrentPersonnel = this._CurrentPersonnel ?? Module.CurPer; }
        }
        public xAccount CurrentAccount
        {
            get { return this._CurrentAccount = this._CurrentAccount ?? Module.CurAcc; }
        }
    }
}
