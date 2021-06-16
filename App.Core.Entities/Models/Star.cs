using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Star:IHasIdentity
    {
        public int Id { get; set; }

        public int StarNumber { get; set; }

        #region MyRegion

        public virtual List<Hotel> Hotels { get; set; }


        #endregion
    }
}