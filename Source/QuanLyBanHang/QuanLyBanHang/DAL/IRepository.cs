using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public interface IRepository<T> where T : class, new()
    {
        aModel Context { get; set; }
        //IEnumerable<T> GetAll();
        //T GetTByID(int KeyID);
        //void Insert(T TEntry);
        //void Update(T TEntry);
        //void Delete(T TEntry);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public interface IRepositoryCollection
    {
        Repository<T> GetRepo<T>() where T : class, new();
    }
}
