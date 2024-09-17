using MSTCore.Entities;
using MSTRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTService
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<Admin> _adminRepository;

        public AdminService(IGenericRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAllAsync();
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _adminRepository.GetByIdAsync(id);
        }

        public async Task<Admin> GetAdminByLogin(string loginName)
        {
            return await _adminRepository.FirstOrDefaultAsync(a => a.LoginName == loginName);
        }

        public async Task AddAdmin(Admin admin)
        {
            await _adminRepository.AddAsync(admin);
            await _adminRepository.SaveAsync();
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminRepository.Update(admin);
            _adminRepository.SaveAsync();
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminRepository.Delete(admin);
            _adminRepository.SaveAsync();
        }
    }
}
