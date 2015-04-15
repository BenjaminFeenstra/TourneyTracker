using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourneyTracker
{
    public static class UnitOfWork
    {
        private static TourneyTrackerDBEntities context = new TourneyTrackerDBEntities();

        private static GenericRepository<account> accountRepository;
        public static GenericRepository<account> AccountRepository
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new GenericRepository<account>(context);
                }
                return accountRepository;
            }
        }

        private static GenericRepository<tournament> tournamentRepository;
        public static GenericRepository<tournament> TournamentRepository
        {
            get
            {
                if (tournamentRepository == null)
                {
                    tournamentRepository = new GenericRepository<tournament>(context);
                }
                return tournamentRepository;
            }
        }

        private static GenericRepository<tournament_type> tournament_typeRepository;
        public static GenericRepository<tournament_type> Tournament_typeRepository
        {
            get
            {
                if (tournament_typeRepository == null)
                {
                    tournament_typeRepository = new GenericRepository<tournament_type>(context);
                }
                return tournament_typeRepository;
            }
        }

        private static GenericRepository<participant> participantRepository;
        public static GenericRepository<participant> ParticipantRepository
        {
            get
            {
                if (participantRepository == null)
                {
                    participantRepository = new GenericRepository<participant>(context);
                }
                return participantRepository;
            }
        }

        private static GenericRepository<tournament_participant_rel> tournament_participantRepository;
        public static GenericRepository<tournament_participant_rel> Tournament_participant_RelRepository
        {
            get
            {
                if (tournament_participantRepository == null)
                {
                    tournament_participantRepository = new GenericRepository<tournament_participant_rel>(context);
                }
                return tournament_participantRepository;
            }
        }
    }
}