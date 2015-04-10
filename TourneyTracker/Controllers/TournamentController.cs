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
            Participant participant = new Participant();
            participant.Name = participantName;
            participant.Number = tournamentViewModel.Participants.Count + 1;
            tournamentViewModel.Participants.Add(participant);
            return PartialView("~/Views/Tournament/Partial/_ParticipantTable.cshtml", tournamentViewModel);
        }

        // POST: CreateTournament
        [HttpPost]
        public ActionResult CreateTournament(CreateTournamentViewModel tournamentViewModel)
        {
            return View();
        }

    }
}