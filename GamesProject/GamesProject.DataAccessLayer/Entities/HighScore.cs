using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.DataAccessLayer.Entities
{
    public class HighScore
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public double Score { get; set; }
        public int Win { get; set; }
    }
}
