using System;
using System.Collections.Generic;
using System.Text;

namespace Z_DataAccessLayer.Entities
{
    public class HighScore
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int score { get; set; }
    }
}
