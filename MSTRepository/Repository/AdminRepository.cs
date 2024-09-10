using Microsoft.EntityFrameworkCore;
using MSTCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MSTRepository.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Admin> GetAdminByLoginAsync(string loginName, string password)
        {
            return await _context.Admins
                .Where(a => a.LoginName == loginName && a.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
