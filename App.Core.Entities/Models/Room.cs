﻿using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class Room:IHasIdentity
    {
        public int Id { get; set; }
    }
}