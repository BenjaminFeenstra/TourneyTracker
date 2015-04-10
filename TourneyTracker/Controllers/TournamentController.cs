using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyTracker.Models.Tournament;

namespace TourneyTracker.Controllers
{
    public class TournamentController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateTournament
        public ActionResult CreateTournament()
        {
            CreateTournamentViewModel tournamentViewModel = new CreateTournamentViewModel();
            return View(tournamentViewModel);
        }

        public ActionResult AddParticipant(CreateTournamentViewModel tournamentViewModel, string participantName)
        {
            tournamentViewModel.Participants.Add(participantName);
            return PartialView("~/Views/Tournament/Partial/_ParticipantTable.cshtml", tournamentViewModel);
        }

        public ActionResult RemoveParticipant(CreateTournamentViewModel tournamentViewModel, string participantName)
        {
            //remove participant
            return PartialView("~/Views/Tournament/Partial/_ParticipantTable.cshtml", tournamentViewModel);
        }

        // POST: SubmitTournament
        public ActionResult SubmitTournament(CreateTournamentViewModel tournamentViewModel)
        {
            //save tournament and see the tournament page
            return View();
        }

    }
}