using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Star:IHasIdentity
    {
        public int Id { get; set; }

        public int StarNumber { get; set; }

        #region MyRegion

        public List<Hotel> Hotels { get; set; }


        #endregion
    }
}