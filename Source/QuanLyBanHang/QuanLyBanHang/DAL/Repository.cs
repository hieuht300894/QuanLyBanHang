using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public aModel Context { get; set; }

        public Repository(aModel context) { Context = context; }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public T GetTByID(int KeyID)
        {
            return Context.Set<T>().Find(KeyID);
        }

        public void Insert(T TEntry)
        {
            Context.Entry(TEntry.Clone()).State = EntityState.Added;
        }

        public void Update(T TEntry)
        {
            Context.Entry(TEntry.Clone()).State = EntityState.Modified;
        }

        public void Delete(T TEntry)
        {
            Context.Entry(TEntry.Clone()).State = EntityState.Deleted;
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            Context.Database.CurrentTransaction.Rollback();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }

    public class RepositoryCollection : IRepositoryCollection
    {
        private aModel context;

        public RepositoryCollection()
        {
            context = new aModel();
        }

        public Repository<T> GetRepo<T>() where T : class, new()
        {
            return new Repository<T>(context);
        }
    }
}
