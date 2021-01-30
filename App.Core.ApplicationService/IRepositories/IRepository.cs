using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.IRepositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetSingel(int id);

        IQueryable<T> GetQuery();

        void Insert(T item);

        T Update(T item);

        Task Delete(int id);

        Task Save();




    }
}
