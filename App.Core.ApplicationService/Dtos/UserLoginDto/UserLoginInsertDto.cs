using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.UserLoginDto
{
    class UserLoginInsertDto
    {
        public string Token { get; set; }

        public DateTime ExpDate { get; set; }

        public int UserId { get; set; }
    }
}
