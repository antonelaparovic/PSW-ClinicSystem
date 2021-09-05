using System;
using System.Collections.Generic;
using System.Text;
using PSW_ClinicSystem.Repository;
using PSW_ClinicSystem.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;


namespace PSW_ClinicSystem.Tests.Repository
{
    public class UserRepositoryTest
    {
        private UserRepository userRepository;

        public UserRepositoryTest()
        {
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var dbOption = new DbContextOptionsBuilder<DataDbContext>()
            //    .UseMySql(config["ConnectionStrings:Default"])
            //    .Options;

            //userRepository = new UserRepository(dbOption);
        }

        //public void GetAll_UserExists_ReturnsValidObject()
        //{

        //    User user = userRepository.GetById(1);
        //    Assert.Equal(1, user.Id);
        //    Assert.Equal("admin", user.name);
        //}

        //public void GetById_UserDoesNotExist_ReturnsNull()
        //{

        //   // User user = userRepository.G(64844);
           // Assert.IsNull(user);


            // dodati getAll test
            // detaljno implementirati ostale servise i appartment logiku
            // .. proci kroz specifikaciju i zapisivati upite-zahteve
        }


    }
