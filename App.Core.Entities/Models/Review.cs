using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Review : IHasIdentity
    {
        public int Id { get; set; }

        public string Comment { get; set; }


        public int UserId { get; set; }

        public int HotelId { get; set; }

        #region Relation

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        public virtual List<ReviewAnswer> ReviewAnswers { get; set; }

        #endregion
    }
}