using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{

    public class aModel : zModel
    {
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

        public async override Task<int> SaveChangesAsync()
        {
            List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
              .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
              .ToList());
            var lstObjs = await AutoLogAsync(entries);
            var res = await base.SaveChangesAsync();
            SaveLog(lstObjs);
            return res;
        }
        private async Task<List<ObjectBinding>> AutoLogAsync(List<DbEntityEntry> lstEntries)
        {
            return await Task.Factory.StartNew(() =>
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
             });
        }

        private async void SaveLog(List<ObjectBinding> lstObjs)
        {
            try
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
                    await db.SaveChangesAsync();
                }
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

    public static class ObjectCopier
    {
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
}
