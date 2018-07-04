using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.DataTransferModels
{
    public class UserDTM
    {
        public int IdDTM { get; set; }
        public string NameDTM { get; set; }
        public string SurnameDTM { get; set; }
        public string LoginDTM { get; set; }
        public string PasswordDTM { get; set; }
        public string RoleDTM { get; set; }
    }
}
