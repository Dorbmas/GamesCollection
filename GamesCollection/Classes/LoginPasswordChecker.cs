using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCollection.Classes
{
    public class LoginPasswordChecker
    {
        public static bool ValidateUserLength (string login, string password)
        {
            if (login.Length < 5 || password.Length <5)
                return false;

            return true;
        }

        public static bool ValidateUserLoginPassword (string login, string password)
        {
            if (login == null || password == null)
            {
                return false;
            }
            else if (login != "kirillov1" && password != "123456")
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUserIsLower (string login, string password)
        {
            if (!login.Any(Char.IsLower))
                return false;

            return true;
        }

        public static bool ValidateUserIsUpper(string login, string password)
        {
            if (!login.Any(Char.IsUpper))
                return false;

            return true;
        }

        public static bool ValidateGamesAddEdit (float rating)
        {
            if (rating == null)
            {
                return false;
            }
            else if (rating < 0 || rating > 10)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateBack(bool click)
        {
            if (click != true) 
                return false;

            return true;
        }
    }
}
