using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Service
{
    public interface IForm<T>
    {
        void LoadData(T KeyID);
        void LoadDataForm();
        void SetControlValue();
        void InsertEntry();
        void UpdateEntry();
        void DeleteEntry();
        void RefreshEntry();
        bool ValidationForm();
        Task<bool> SaveData();
    }
    public interface IFormList<T>
    {
        void LoadData(T KeyID);
        void InsertEntry();
        void UpdateEntry();
        void DeleteEntry();
        void RefreshEntry();
    }
    public interface IFormAccess
    {
        void LoadDataForm();
        void SetControlValue();
        bool ValidationForm();
        Task<bool> SaveData();
        void ResetData();
    }
}
