using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class UserLogin : IHasIdentity
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpDate { get; set; }

        public int UserId { get; set; }


        #region Relation

        [ForeignKey("UserId")]
        public virtual  User User { get; set; }

        #endregion
    }
}