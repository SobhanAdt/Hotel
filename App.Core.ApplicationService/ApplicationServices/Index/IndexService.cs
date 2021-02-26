using System;
using System.Collections.Generic;
using System.Text;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using Hotel.Core.ApplicationService.Dtos.IndexDto;

namespace Hotel.Core.ApplicationService.ApplicationServices.Index
{
    public class IndexService:IIndexService
    {
        private IRepository<App.Core.Entities.Hotel> hotelRepository;

        private IRepository<City> cityRepository;

        private IRepository<Star> staRepository;

        public IndexService(IRepository<App.Core.Entities.Hotel> hotelRepository,
            IRepository<City> cityRepository, IRepository<Star> staRepository)
        {
            this.hotelRepository = hotelRepository;
            this.cityRepository = cityRepository;
            this.staRepository = staRepository;
        }

        //public List<IndexGetoutDto> Get()
        //{
        //    hotelRepository.
        //}
    }
}
