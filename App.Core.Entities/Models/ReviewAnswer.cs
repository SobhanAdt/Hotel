using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class ReviewAnswer : IHasIdentity
    {
        public int Id { get; set; }

        public string CommentAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }

        #region Relation

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        #endregion
    }
}