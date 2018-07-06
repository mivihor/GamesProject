using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesProject.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "GamesProject"; 
        public const string AUDIENCE = "https://localhost:44362"; 
        const string KEY = "b10b10f3e2@MySuperKey";   
        public const int LIFETIME = 15; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
