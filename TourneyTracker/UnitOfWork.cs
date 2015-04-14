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
    }
}