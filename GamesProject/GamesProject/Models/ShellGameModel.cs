using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Models
{
    public class ShellGameModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public int Bid { get; set; }
        [Required]
        public int userResult { get; set; }
    }
}
