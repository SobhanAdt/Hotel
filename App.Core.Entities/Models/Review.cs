using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Review:IHasIdentity
    {
        public int Id { get; set; }
    }
}