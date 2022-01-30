using Sat.Recruitment.Core.Constans;
using Sat.Recruitment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.BusinessLogic.BusinessLogic
{
    public static class UserLogic
    {
        public static User RunGeneralUserBusinessLogic(User user)
        {
            try
            {
                if (user.UserType == UserType.NORMAL)
                {
                    if (user.Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = user.Money * percentage;
                        user.Money = user.Money + gif;
                    }
                    if (user.Money < 100)
                    {
                        if (user.Money > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = user.Money * percentage;
                            user.Money = user.Money + gif;
                        }
                    }
                }

                if (user.UserType == UserType.SUPER_USER)
                {
                    if (user.Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = user.Money * percentage;
                        user.Money = user.Money + gif;
                    }
                }

                if (user.UserType == UserType.PREMIUM)
                {
                    if (user.Money > 100)
                    {
                        var gif = user.Money * 2;
                        user.Money = user.Money + gif;
                    }
                }

                //Normalize Email
                user.Email = NormalizeEmail(user.Email);

                return user;

            }catch(Exception)
            {
                throw;
            }
           
        }

        public static string NormalizeEmail(string email)
        {
            try
            {
                //Normalize email
                var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                email = string.Join("@", new string[] { aux[0], aux[1] });

                return email;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public static bool IsDuplicated(User user, List<User> users)
        {
            bool isDuplicated = false;

            foreach (var _user in users)
            {
                if (_user.Email == user.Email || _user.Phone == user.Phone || _user.Address == user.Address)
                {
                    isDuplicated = true;
                }
            }

            return isDuplicated;
        }
    }
}
