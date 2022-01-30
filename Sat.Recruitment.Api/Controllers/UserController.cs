using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.BusinessLogic.BusinessLogic;
using Sat.Recruitment.Core.Constans;
using Sat.Recruitment.Core.Common;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UserController : ControllerBase
    {

        private List<User> _users = new List<User>();
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public Result CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = UserLogic.RunGeneralUserBusinessLogic(user);

                try
                {
                    bool status = _userRepository.Create(newUser);

                    if (status)
                    {
                        Debug.WriteLine(UserMessages.USER_CREATED);

                        return new Result()
                        {
                            IsSuccess = true,
                            Message = UserMessages.USER_CREATED,
                        };
                    }
                    else
                    {
                        Debug.WriteLine(UserMessages.USER_DUPLICATED);

                        return new Result()
                        {
                            IsSuccess = false,
                            Message = UserMessages.USER_DUPLICATED,
                            
                        };
                    }
                }
                catch
                {
                    Debug.WriteLine(UserMessages.USER_ERROR);
                    return new Result()
                    {
                        IsSuccess = false,
                        Message = UserMessages.USER_ERROR
                    };
                }
            }

            return new Result()
            {
                IsSuccess = false,
                Message = UserMessages.USER_INVALID_FIELDS
            };
        }

    }
}
