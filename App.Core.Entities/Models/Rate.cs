using System.Collections.Generic;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Rate:IHasIdentity
    {
        public int Id { get; set; }

        public int RateNumber { get; set; }

        #region MyRegion

        public List<Hotel> Hotels { get; set; }


        #endregion
    }
}