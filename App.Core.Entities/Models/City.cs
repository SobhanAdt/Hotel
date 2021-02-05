using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class City : IHasIdentity
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        #region Relation

        public List<Hotel> Hotels { get; set; }

        #endregion
    }
}
