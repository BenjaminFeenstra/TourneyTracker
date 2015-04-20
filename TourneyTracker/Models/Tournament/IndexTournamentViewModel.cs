using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourneyTracker.Models.Tournament
{
    public class IndexTournamentViewModel
    {
        public List<TournamentViewModel> Tournaments { get; set; }

        public IndexTournamentViewModel()
        {
            this.Tournaments = new List<TournamentViewModel>();
        }

    }
}