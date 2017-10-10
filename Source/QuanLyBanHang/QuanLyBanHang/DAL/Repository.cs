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

        public void DeleteEntry(int KeyID)
        {
        }

        public IEnumerable<T> GetAll()
        {
            return new List<T>();
        }

        public T GetTByID(int KeyID)
        {
            return new T();
        }

        public void InsertEntry(T TEntry)
        {

        }

        public void UpdateEntry(T TEntry)
        {
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
