using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

    }
}
