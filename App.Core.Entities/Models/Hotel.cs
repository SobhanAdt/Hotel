using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Hotel : IHasIdentity
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public int HotelCode { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public int RateId { get; set; }


        #region MyRegion

        public City City { get; set; }

        public Rate Rate { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Room> Rooms { get; set; }

        #endregion
    }
}