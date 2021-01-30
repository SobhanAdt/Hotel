using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class User:IHasIdentity
    {
        public int Id { get; set; }
    }
}