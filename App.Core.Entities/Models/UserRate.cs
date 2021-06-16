using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        #endregion
    }
}