using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class UserRate:IHasIdentity
    {
        public int Id { get; set; }

        public float RateNumber { get; set; }

        public int UserId { get; set; }

        public int HotelId { get; set; }

        #region Navigation

        public User User { get; set; }

        public Hotel Hotel { get; set; }

        #endregion
    }
}