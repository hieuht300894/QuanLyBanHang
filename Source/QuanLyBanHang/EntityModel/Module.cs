using EntityModel.DataModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using EntityModel.DataModel.HeThong;

namespace EntityModel
{
    public class Module
    {
        public static string dbConnectString = "";

        private static xPersonnel _curPer = null;
        private static xAccount _curAcc = null;
        private static List<ColumnKey> lstSchemaKeys = new List<ColumnKey>();

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
        private static void GetPrimaryKeys(aModel db)
        {
            string qSelectKey =
                "SELECT DISTINCT" +
                "    PK_TableName = PK.TABLE_NAME, " +
                "    PK_ColumnName = CU.COLUMN_NAME, " +
                "    PK_Indentity = CAST(p.IS_IDENTITY as bit), " +
                "    FK_TableName = '', " +
                "    FK_ColumnName = '', " +
                "    FK_Indentity = CAST(0 as bit) " +
                "FROM " +
                "    INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK " +
                "    LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CU ON CU.Table_Name = PK.Table_Name " +
                "    LEFT JOIN( " +
                "        SELECT c.name COLUMN_NAME, t.name TABLE_NAME, c.is_identity IS_IDENTITY " +
                "        FROM " +
                "            sys.tables t " +
                "            left join sys.columns c on c.object_id= t.object_id) p ON p.COLUMN_NAME = CU.COLUMN_NAME and p.TABLE_NAME = PK.TABLE_NAME " +
                "WHERE " +
                "    CU.Constraint_Name = PK.Constraint_Name AND Constraint_Type = 'PRIMARY KEY' " +
                "UNION " +
               "SELECT DISTINCT " +
               "    PK_TableName = PK.TABLE_NAME, " +
               "    PK_ColumnName = PT.COLUMN_NAME, " +
               "    PK_Indentity = CAST(0 as bit), " +
               "    FK_TableName = FK.TABLE_NAME, " +
               "    FK_ColumnName = CU.COLUMN_NAME, " +
               "    FK_Indentity = CAST(0 as bit) " +
               "FROM " +
               "    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C " +
               "    LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME " +
               "    LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME " +
               "    LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME " +
               "    LEFT JOIN( " +
               "        SELECT DISTINCT " +
               "            i1.TABLE_NAME, " +
               "            i2.COLUMN_NAME " +
               "        FROM " +
               "            INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 " +
               "            LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME " +
               "        WHERE " +
               "            i1.CONSTRAINT_TYPE = 'PRIMARY KEY') PT ON PT.TABLE_NAME = PK.TABLE_NAME";

            lstSchemaKeys = new List<ColumnKey>(db.Database.SqlQuery<ColumnKey>(qSelectKey).ToList());
        }

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
    }
}
