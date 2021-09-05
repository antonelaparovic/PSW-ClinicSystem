using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]        // for register and login
    public class AllowAnonymousAttribute : Attribute
    { }
}
