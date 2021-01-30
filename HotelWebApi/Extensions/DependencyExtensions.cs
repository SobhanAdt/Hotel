using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using App.Infrastucture.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelWebApi.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection service)
        {
            AddRepositories(service);
            AddService(service);
        }

        public static void AddService(IServiceCollection service)
        {
            service.AddTransient<ICityService, CityService>();
        }

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddTransient<IRepository<City>, EfRepository<City>>();
        }
    }
}
