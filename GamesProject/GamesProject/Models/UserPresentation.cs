using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Models
{
    public class UserPresentation
    {
        public int IdPresentation { get; set; }
        public string NamePresentation { get; set; }
        public string SurnamePresentation { get; set; }
        public string LoginPresentation { get; set; }
        public string PasswordPresentation { get; set; }
        public string RolePresentation { get; set; }
    }
}
