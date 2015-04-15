using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyTracker.Models.Tournament;

namespace TourneyTracker.Logic
{
    public class TournamentLogic
    {
        #region Get

        /// <summary>
        /// Gets a tournament type list (for dropdowns)
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetTournamentTypeList()
        {
            List<SelectListItem> tournamentTypeList = new List<SelectListItem>();
            var typeList = UnitOfWork.Tournament_typeRepository.All();
            foreach (var tournamentType in typeList)
            {
                SelectListItem item = new SelectListItem();
                item.Value = tournamentType.tournament_type_id.ToString();
                item.Text = tournamentType.tournament_type_name;
                tournamentTypeList.Add(item);
            }
            return tournamentTypeList;
        }

        #endregion

        #region Set

        /// <summary>
        /// Save your Tournament!
        /// </summary>
        /// <param name="tournamentViewModel"></param>
        public void SaveTournament(CreateTournamentViewModel tournamentViewModel)
        {
            tournament newTournament = new tournament
            {
                tournament_name = tournamentViewModel.TournamentName,
                tournament_type_id = tournamentViewModel.TournamentType,
                //TODO: user id
                tournament_host_id = 1,
                number_participants = tournamentViewModel.Participants.Count
            };
            UnitOfWork.TournamentRepository.InsertAndSave(newTournament);

            var allParticipants = UnitOfWork.ParticipantRepository.All();
            var participantList = new List<participant>();
            //save the new participants
            foreach (var participantName in tournamentViewModel.Participants)
            {
                var participantExist = allParticipants.Where(x => x.participant_name == participantName).FirstOrDefault();
                if (participantExist == null)
                {
                    var newParticipant = new participant
                    {
                        participant_name = participantName
                    };
                    UnitOfWork.ParticipantRepository.InsertAndSave(newParticipant);
                    participantExist = newParticipant;
                }
                participantList.Add(participantExist);
                var tournament_participant = new tournament_participant_rel
                {
                    tournament_id = newTournament.tournament_id,
                    participant_id = participantExist.participant_id

                };
                UnitOfWork.Tournament_participant_RelRepository.InsertAndSave(tournament_participant);
            }
            GenerateCompetition(participantList, newTournament);
        }

        /// <summary>
        /// Generate matches for Competition
        /// </summary>
        /// <param name="participantList"></param>
        /// <param name="newTournament"></param>
        public void GenerateCompetition(List<participant> participantList, tournament newTournament)
        {
            //i is 1 because the number of rounds is always participants count - 1
            for(int round = 1; round < participantList.Count;round++)
            {
                var lastParticipant = participantList.Last();
                bool ifOddNumber = false;

                var newMatch = new match
                {
                    tournament_id = newTournament.tournament_id,
                    participant_number_one = participantList[0].participant_id,
                    participant_number_two = participantList[1].participant_id,
                };
                UnitOfWork.MatchRepository.InsertAndSave(newMatch);
                if(participantList.Count % 2 != 0)
                {
                    ifOddNumber = true;
                    participantList.Remove(lastParticipant);
                }

                int difference = (participantList.Count - 1) - 2;
                for(int i = 2; i <= (participantList.Count/2); i++)
                {
                    newMatch = new match
                    {
                        tournament_id = newTournament.tournament_id,
                        participant_number_one = participantList[i].participant_id,
                        participant_number_two = participantList[i + difference].participant_id,
                    };
                    UnitOfWork.MatchRepository.InsertAndSave(newMatch);
                    difference = difference - 2;
                }

                if (!ifOddNumber)
                {
                    //the last participant in the list goes to position 1
                    participantList.Remove(lastParticipant);
                    participantList.Insert(1, lastParticipant);
                }
                else
                {
                    participantList.Insert(0, lastParticipant);
                }

            }
        }

        #endregion
    }
}