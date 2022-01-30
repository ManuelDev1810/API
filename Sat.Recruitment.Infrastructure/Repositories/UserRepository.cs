using Microsoft.Extensions.Configuration;
using Sat.Recruitment.BusinessLogic.BusinessLogic;
using Sat.Recruitment.Core.Constans;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool Create(User user)
        {
            try
            {
                bool isDuplicated = UserLogic.IsDuplicated(user, GetAll());
                if (!isDuplicated)
                {
                    //Create real user
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<User> GetAll()
        {
            try
            {
                var asas = AppDomain.CurrentDomain.BaseDirectory;

                using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + UserFile.USERS), FileMode.Open))
                {
                    StreamReader reader = new StreamReader(fileStream);
                    List<User> users = new List<User>();

                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLineAsync().Result;
                        var user = new User
                        {
                            Name = line.Split(',')[0].ToString(),
                            Email = line.Split(',')[1].ToString(),
                            Phone = line.Split(',')[2].ToString(),
                            Address = line.Split(',')[3].ToString(),
                            UserType = line.Split(',')[4].ToString(),
                            Money = decimal.Parse(line.Split(',')[5].ToString()),
                        };
                        users.Add(user);
                    }

                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
