using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using TourneyTracker.Models.Account;

namespace TourneyTracker.Logic
{
    public class AccountLogic
    {
        /// <summary>
        /// Create a user account with encrypted password
        /// </summary>
        /// <param name="model"></param>
        public void RegisterAccount(RegisterModel model)
        {
            var salt = Crypto.GenerateSalt();
            var stringToHash = model.Password + salt;
            var hash = Crypto.SHA256(stringToHash);

            UnitOfWork.AccountRepository.InsertAndSave(
                new account
                {
                    emailaddress = model.Email,
                    password_hash = hash,
                    password_salt = salt
                }
            );
        }

        /// <summary>
        /// Check wether an emailaddress is already in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EmailInUse(string email)
        {
            return UnitOfWork.AccountRepository.Find(a => a.emailaddress == email) != null;
        }

        /// <summary>
        /// Validate login by comparing submitted password with stored database, using crypt functions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ValidateLogin(LoginModel model)
        {
            var account = UnitOfWork.AccountRepository.Find(a => a.emailaddress == model.Email);
            if (account != null)
            {
                var passwordWithSalt = model.Password + account.password_salt;
                return Crypto.SHA256(passwordWithSalt) == account.password_hash;
            }
            return false;
        }

        /// <summary>
        /// Change the password for an account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void ChangePassword(string email, string password)
        {
            var account = UnitOfWork.AccountRepository.Find(a => a.emailaddress == email);
            if (account != null)
            {
                var salt = Crypto.GenerateSalt();
                var stringToHash = password + salt;
                var hash = Crypto.SHA256(stringToHash);

                account.password_salt = salt;
                account.password_hash = hash;

                UnitOfWork.AccountRepository.UpdateAndSave(account);
            }
        }
    }
}