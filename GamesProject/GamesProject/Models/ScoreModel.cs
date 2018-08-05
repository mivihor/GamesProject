using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Models
{
    public class ScoreModel
    {
        [Required]
        public string userLogin { get; set; }
    }
}
