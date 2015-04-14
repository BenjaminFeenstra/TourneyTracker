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
    }
}