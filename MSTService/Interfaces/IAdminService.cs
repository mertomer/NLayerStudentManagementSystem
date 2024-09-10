using MSTCore.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MSTService
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task<Admin> GetAdminByLogin(string loginName);  // Bu metodu ekledik
        Task AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
