using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.IRepositories;
using App.Infrastucture.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace App.Infrastucture.EF.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IHasIdentity
    {
        private HotelDbContext context;

        public EfRepository(HotelDbContext context)
        {
            this.context = context;
        }

        public Task<List<T>> GetAll()
        {
            return this.context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public Task<T> GetSingel(int id)
        {
            return this.context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(T item)
        {
            this.context.Add(item);
        }

        public async Task Delete(int id)
        {
            var model = await this.context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            this.context.Remove(model);
        }

        public Task Save()
        {
            return this.context.SaveChangesAsync();
        }

        public T Update(T item)
        {
            this.context.Update(item);
            return item;
        }
    }
}
