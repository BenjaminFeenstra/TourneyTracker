using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourneyTracker.Models.Tournament
{
    public class TournamentViewModel
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int NumberParticipants { get; set; }

    }
}