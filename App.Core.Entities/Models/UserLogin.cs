using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class UserLogin:IHasIdentity
    {
        public int Id { get; set; }
    }
}