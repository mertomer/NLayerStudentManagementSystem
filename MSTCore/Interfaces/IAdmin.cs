using MSTCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTCore.Interfaces
{
    public interface IAdmin
    {
        Task<Admin> GetAdminByLogin(string loginName);

    }
}
