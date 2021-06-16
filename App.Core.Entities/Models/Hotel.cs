using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int StarId { get; set; }


        #region Navigation

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("StarId")]
        public virtual Star Star { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<Room> Rooms { get; set; }

        public virtual List<UserRate> UserRates { get; set; }

        #endregion
    }
}