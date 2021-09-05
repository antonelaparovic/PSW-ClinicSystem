using PSW_ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;

namespace PSW_ClinicSystem.IServices
{
    public interface IUserService
    {
        Task<User> Authenticate(string name, string password);
        IEnumerable<UserResponseDTO> GetUsers();

    }
}
