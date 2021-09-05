using System;
using Xunit;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.Services;
using Moq;
using AutoMapper;
using PSW_ClinicSystem.DTO;
using System.Collections.Generic;
using System.Linq;
using PSW_ClinicSystem.IServices;
using PSW_ClinicSystem.Data;
using System.Threading.Tasks;



namespace PSW_ClinicSystem.Tests
{
    public class UserServiceTest
    {
        private readonly IUserService userService;
        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
        private IMapper _mapper;



        public UserServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            userService = new UserService(userRepository.Object, _mapper);
        }

        [Fact]
        public void GetAllUsersTest_ReturnsAreEqual()
        {
            List<User> userList = new List<User>()
            {
                new User { Id = 1, name = "test", Password = "test" }
            };

            userRepository.Setup(repo => repo.GetAll()).Returns(userList);

            IEnumerable<UserResponseDTO> users = userService.GetUsers();   // u servisu ih mapira

            Assert.Equal(userList.Count, users.ToList().Count);
        }

        [Fact]
        public void AuthenticateTest_ReturnsTrue()
        {
            List<User> userList = new List<User>()
            {
                new User { Id = 1, name = "test", Password = "test" },
                new User { Id = 2, name = "admin", Password = "admin" },
                new User { Id = 3, name = "mmm", Password = "mmm" },

            };

            userRepository.Setup(repo => repo.GetAll()).Returns(userList);

            Task<User> users = userService.Authenticate("admin", "admin");   // u servisu ih mapira
            
            Assert.Equal(userList.ElementAt(1), users.Result);

        }

        //[Fact]
        //public void AuthenticateTest_ReturnsFalse()
        //{
        //    List<User> userList = new List<User>()
        //    {
        //        new User { Id = 1, name = "test", Password = "test" },
        //        new User { Id = 2, name = "admin", Password = "admin" },
        //        new User { Id = 3, name = "mmm", Password = "mmm" },

        //    };

        //    userRepository.Setup(repo => repo.GetAll()).Returns(userList);

        //    Task<User> users = userService.Authenticate("admin", "test");   // u servisu ih mapira

        //    Assert.IsType(Task<User>.);

        //}

    }
}
