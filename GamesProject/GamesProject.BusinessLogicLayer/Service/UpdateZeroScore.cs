using DNTScheduler.Core.Contracts;
using GamesProject.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using System.Threading.Tasks;

namespace GamesProject.BusinessLogicLayer.Service
{
    public class UpdateZeroScore : IScheduledTask
    {
        private IShellHighScoreService _hsTableService;
        public UpdateZeroScore(IShellHighScoreService hsTableService)
        {
            _hsTableService = hsTableService;
        }

        public bool IsShuttingDown { get; set; }

        public async Task RunAsync()
        {
            if (this.IsShuttingDown)
            {
                return;
            }



            IEnumerable<HighScoreDTM> zeroScores = _hsTableService.getZeroScores();

            foreach (HighScoreDTM userSetup in zeroScores)
            {
                _hsTableService.UpdateUserScores(userSetup, 100);
            }

            await Task.Delay(TimeSpan.FromMinutes(3));
        }
    }
}
