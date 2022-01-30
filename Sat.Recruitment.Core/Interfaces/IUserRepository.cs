using Sat.Recruitment.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        bool Create(User user);
    }
}
