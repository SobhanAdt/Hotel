using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Hotel:IHasIdentity
    {
        public int Id { get; set; }
    }
}