﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourneyTracker.Controllers
{
    public class TournamentController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTournament()
        {
            return View();
        }

        public ActionResult AddParticipantsDialog()
        {
            return View();
        }

    }
}