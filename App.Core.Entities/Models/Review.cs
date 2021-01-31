using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Review : IHasIdentity
    {
        public int Id { get; set; }

        public string Commnet { get; set; }


        public int UserId { get; set; }

        public int HotelId { get; set; }

        #region Relation

        public User User { get; set; }

        public Hotel Hotel { get; set; }

        public List<ReviewAnswer> ReviewAnswers { get; set; }

        #endregion
    }
}