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

        public static xPersonnel CurPer
        {
            get { return _curPer; }
            set { _curPer = value; }
        }

        private class MyConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<aModel>
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

                if (db.eAgencies.Count() <= 0)
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
                        db.eAgencies.Add(_eAgency);

                        db.SaveChanges();
                    }
                    catch { }
                }
            }
        }
    }
}
