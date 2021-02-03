using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.ReviewDto;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.Userto
{
    public class UserOutputDto
    {
    
        public string FullName { get; set; }

        public string Email { get; set; }
        .
        public string Password { get; set; }

        public List<ReviewDTO> Reviews { get; set; }
        public List<ReviewAnswerDTO> ReviewAnswers { get; set; }

    }
}