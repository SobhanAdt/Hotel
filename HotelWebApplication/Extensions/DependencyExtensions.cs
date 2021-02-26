using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.ApplicationServices.Review;
using App.Core.ApplicationService.ApplicationServices.ReviewAnswer;
using App.Core.ApplicationService.ApplicationServices.Room;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.ApplicationServices.UserLogin;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using App.Infrastucture.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelWebApplication.Extensions
{
    /// <summary>
    /// Dependency Injection Service And Repositories
    /// </summary>
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection service)
        {
            AddRepositories(service);
            AddService(service);
        }

        public static void AddService(IServiceCollection service)
        {
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<IHotelService, HotelService>();
            service.AddScoped<IRoomService, RoomService>();
            service.AddScoped<IStarService, StarService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IReviewService, ReviewService>();
            service.AddScoped<IReviewAnswerService, ReviewAnswerService>();
            service.AddScoped<IUserLoginService, UserLoginService>();

        }

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IRepository<City>, EfRepository<City>>();
            service.AddScoped<IRepository<App.Core.Entities.Hotel>, EfRepository<App.Core.Entities.Hotel>>();
            service.AddScoped<IRepository<Star>, EfRepository<Star>>();
            service.AddScoped<IRepository<Review>, EfRepository<Review>>();
            service.AddScoped<IRepository<ReviewAnswer>, EfRepository<ReviewAnswer>>();
            service.AddScoped<IRepository<Room>, EfRepository<Room>>();
            service.AddScoped<IRepository<User>, EfRepository<User>>();
            service.AddScoped<IRepository<UserLogin>, EfRepository<UserLogin>>();
            service.AddScoped<IRepository<UserRate>, EfRepository<UserRate>>();
        }
    }
}
