using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.DataTransferModels
{
    public class UserDTM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
