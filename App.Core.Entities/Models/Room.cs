using System.ComponentModel.DataAnnotations.Schema;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Room:IHasIdentity
    {
        public int Id { get; set; }

        public int RoomCode { get; set; }

        public int RoomAera { get; set; }

        public int RoomPrice { get; set; }

        public string Descripation { get; set; }

        public int HotelId { get; set; }


        #region Relation

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        #endregion
    }
}