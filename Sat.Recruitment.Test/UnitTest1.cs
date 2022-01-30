using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Core.Constans;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly IUserRepository _userRepository;

        public UnitTest1(IUserRepository userRepository) => _userRepository = userRepository;


        [Fact]
        public void Test1()
        {
             
            var userController = new UserController(_userRepository);

            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);


            Assert.True(result.IsSuccess);
            Assert.Equal(UserMessages.USER_CREATED, result.Message);
        }

        [Fact]
        public void Test2()
        {
            var userController = new UserController(_userRepository);

            var user = new User
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);


            Assert.False(result.IsSuccess);
            Assert.Equal(UserMessages.USER_DUPLICATED, result.Message);
        }
    }
}
