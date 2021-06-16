using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class User : IHasIdentity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        #region  Relation

        public virtual List<UserLogin> UserLogins { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<ReviewAnswer> ReviewAnswers { get; set; }

        public virtual List<UserRate> UserRates { get; set; }

        #endregion
    }
}