using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class User : IHasIdentity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        #region  Relation

        public List<UserLogin> UserLogins { get; set; }

        public List<Review> Reviews { get; set; }

        public List<ReviewAnswer> ReviewAnswers { get; set; }

        #endregion
    }
}