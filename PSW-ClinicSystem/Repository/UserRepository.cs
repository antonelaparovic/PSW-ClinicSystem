using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        protected DbContext Context;
        public IPatientRepository patientRepository;
        public IDoctorRepository doctorRepository;
        public IAdminRepository adminRepository;
        public IMapper mapper;

        public DataDbContext DataDbContext
        {
            get { return Context as DataDbContext; }
        }
        public UserRepository(DataDbContext context, IDoctorRepository doctorRepo, IPatientRepository patientRepo, IAdminRepository adminRepo, IMapper maper)  // DbContextOptions ??
        {
            Context = context;
            doctorRepository = doctorRepo;
            patientRepository = patientRepo;
            adminRepository = adminRepo;
            mapper = maper;
        }

        public IEnumerable<User> GetAll()
        {
            //var patients =  Context.Set<Patient>().ToList();
            //var doctors = Context.Set<Doctor>().ToList();
            //var admins = Context.Set<Admin>().ToList();
            //var usersP = mapper.Map<IEnumerable<User>>(patients);
            //var usersD = mapper.Map<IEnumerable<User>>(doctors);
            //var usersA = mapper.Map<IEnumerable<User>>(admins);

            //return (usersP).Concat(usersD).Concat(usersA);

            List<User> userList = new List<User>()
            {
                new User { Id = 1, name = "test", Password = "test" }
            };
            return userList;
        }
    }
}
