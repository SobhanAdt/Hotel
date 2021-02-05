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

namespace HotelWebApi.Extensions
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
            service.AddTransient<ICityService, CityService>();
            service.AddTransient<IHotelService, HotelService>();
            service.AddTransient<IRoomService, RoomService>();
            service.AddTransient<IStarService, StarService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IReviewService, ReviewService>();
            service.AddTransient<IReviewAnswerService, ReviewAnswerService>();
            service.AddTransient<IUserLoginService, UserLoginService>();

        }

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddTransient<IRepository<City>, EfRepository<City>>();
            service.AddTransient<IRepository<Hotel>, EfRepository<Hotel>>();
            service.AddTransient<IRepository<Star>, EfRepository<Star>>();
            service.AddTransient<IRepository<Review>, EfRepository<Review>>();
            service.AddTransient<IRepository<ReviewAnswer>, EfRepository<ReviewAnswer>>();
            service.AddTransient<IRepository<Room>, EfRepository<Room>>();
            service.AddTransient<IRepository<User>, EfRepository<User>>();
            service.AddTransient<IRepository<UserLogin>, EfRepository<UserLogin>>();
        }
    }
}
