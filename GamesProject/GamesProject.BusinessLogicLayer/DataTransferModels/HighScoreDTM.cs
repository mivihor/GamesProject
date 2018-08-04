using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.DataTransferModels
{
    public class HighScoreDTM
    {
        public int IdDTM { get; set; }
        public string UserLogindDTM { get; set; }
        public int ScoreDTM { get; set; }
        public int WinDTM { get; set; }
    }
}
