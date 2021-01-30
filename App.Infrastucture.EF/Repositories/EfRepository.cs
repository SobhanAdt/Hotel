using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.IRepositories;

namespace App.Infrastucture.EF.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IHasIdentity
    {
        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingel(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
