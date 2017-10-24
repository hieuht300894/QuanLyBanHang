using EntityModel.DataModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;

namespace EntityModel
{
    public class Module
    {
        public static string dbConnectString = "";

        private static xPersonnel _curPer = null;
        private static xAccount _curAcc = null;
        private static List<ColumnKey> lstPrimaryKeys = new List<ColumnKey>();
        private static long _rowInPage = 100;

        public static xPersonnel CurPer
        {
            get { return _curPer; }
            set { _curPer = value; }
        }
        public static xAccount CurAcc
        {
            get { return _curAcc; }
            set { _curAcc = value; }
        }
        public static List<ColumnKey> ListPrimaryKeys
        {
            get { return lstPrimaryKeys; }
        }
        public static long RowsInPage { get { return _rowInPage; } set { _rowInPage = value; } }

        private class MyConfiguration : DbMigrationsConfiguration<aModel>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationDataLossAllowed = true;
                this.AutomaticMigrationsEnabled = true;
            }
        }
        public static void InitDefaultData()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<aModel, MyConfiguration>());

            using (aModel db = new aModel())
            {
                db.Database.Initialize(false);

                GetPrimaryKeys(db);

                if (db.xAgency.Count() == 0)
                {
                    try
                    {
                        DateTime time = DateTime.MinValue;
                        var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                        time = dateQuery.AsEnumerable().First();

                        xAgency _eAgency = new xAgency();
                        _eAgency.Code = "AGE0001";
                        _eAgency.Name = "Agency 1";
                        _eAgency.Address = "Ho Chi Minh City";
                        _eAgency.Phone = "0123456789";
                        _eAgency.Email = "agency1@gmail.com";
                        _eAgency.Description = "";
                        _eAgency.IsEnable = true;
                        _eAgency.CreatedBy = 0;
                        _eAgency.CreatedDate = time;
                        db.xAgency.Add(_eAgency);

                        db.SaveChanges();
                    }
                    catch { }
                }
            }
        }
        private static void GetPrimaryKeys(aModel db)
        {
            string qSelectPrimaryKey =
                  "select distinct Tab.TABLE_NAME, Col.COLUMN_NAME, p.IS_IDENTITY " +
                  "from INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab " +
                  "left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col on Col.Table_Name = Tab.Table_Name " +
                  "left join ( " +
                  "	select c.name cName, c.is_identity IS_IDENTITY, t.name tName " +
                  "	from sys.tables t " +
                  "	left join sys.columns c on c.object_id=t.object_id) p on p.cName=Col.COLUMN_NAME and p.tName=Tab.TABLE_NAME " +
                  "WHERE Col.Constraint_Name = Tab.Constraint_Name AND Constraint_Type = 'PRIMARY KEY'";

            lstPrimaryKeys = db.Database.SqlQuery<ColumnKey>(qSelectPrimaryKey).ToList();
        }
    }
}
