using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyTracker.Logic;
using TourneyTracker.Models.Tournament;

namespace TourneyTracker.Controllers
{
    public class TournamentController : Controller
    {
        TournamentLogic tournamentLogic = new TournamentLogic();
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateTournament
        public ActionResult CreateTournament()
        {
            CreateTournamentViewModel tournamentViewModel = new CreateTournamentViewModel();
            tournamentViewModel.TournamentTypes = tournamentLogic.GetTournamentTypeList();
            return View(tournamentViewModel);
        }

        public ActionResult AddParticipant(CreateTournamentViewModel tournamentViewModel, string participantName)
        {
            tournamentViewModel.Participants.Add(participantName);
            ModelState.Clear();
            return PartialView("~/Views/Tournament/Partial/_ParticipantTable.cshtml", tournamentViewModel);
        }

        public ActionResult RemoveParticipant(CreateTournamentViewModel tournamentViewModel, string participantName)
        {
            tournamentViewModel.Participants.Remove(participantName);
            ModelState.Clear();
            return PartialView("~/Views/Tournament/Partial/_ParticipantTable.cshtml", tournamentViewModel);
        }

        // POST: SubmitTournament
        public ActionResult SubmitTournament(CreateTournamentViewModel tournamentViewModel)
        {
            //save tournament and see the tournament page
            if (ModelState.IsValid)
            {
                //tournamentLogic.SaveTournament(tournamentViewModel);
            }
            return View();
        }

    }
}