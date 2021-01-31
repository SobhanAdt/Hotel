using System.Reflection.Metadata;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class ReviewAnswer : IHasIdentity
    {
        public int Id { get; set; }

        public string CommnetAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }

        #region Relation

        public User User { get; set; }


        public Review Review { get; set; }

        #endregion
    }
}