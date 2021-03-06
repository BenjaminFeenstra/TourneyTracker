﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourneyTracker.Models.Tournament
{
    public class CreateTournamentViewModel
    {
        public string TournamentName { get;set;}

        public int TournamentType { get; set; }
        public List<SelectListItem> TournamentTypes { get; set; }

        //not working atm
        public string TournamentTag { get; set; }

        public List<string> Participants { get; set; }

        public CreateTournamentViewModel()
        {
            this.TournamentTypes = new List<SelectListItem>();
            this.Participants = new List<string>();
        }
    }
}