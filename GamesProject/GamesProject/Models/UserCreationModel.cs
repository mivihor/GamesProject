using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Models
{
    public class UserCreationModel
    {
        [Required]
        public string NameUCM { get; set; }
        [Required]
        public string SurnameUCM { get; set; }
        [Required]
        public string LoginUCM { get; set; }
        [Required]
        public string PasswordUCM { get; set; }
    }
}
