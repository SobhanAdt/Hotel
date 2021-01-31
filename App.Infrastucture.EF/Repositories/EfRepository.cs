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

        public  List<T> GetAll()
        {
            try
            {
                return this.context.Set<T>().ToList();
            }
            catch
            {
                throw new Exception("Error Get All");
            }
        }

        public IQueryable<T> GetQuery()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public T GetSingel(int id)
        {
            try
            {
                return  this.context.Set<T>().FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw new Exception("Error Get Singel");
            }
        }

        public void Insert(T item)
        {
            try
            {
                this.context.Add(item);
            }
            catch
            {
                throw new Exception("Error Insert");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var model = await this.context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                this.context.Remove(model);
            }
            catch 
            {
                throw new  Exception("Error Delete");
            }
        }

        public Task Save()
        {
            try
            {
                return this.context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error Save");
            }
        }

        public T Update(T item)
        {
            try
            {
                this.context.Update(item);
                return item;
            }
            catch
            {
                throw new Exception("Error Update");
            }
        }
    }
}
