using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.DataTransferModels
{
    public class HighScoreDTM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
