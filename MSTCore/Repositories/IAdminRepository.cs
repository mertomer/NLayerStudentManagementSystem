using MSTCore.Entities;

namespace MSTRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetAdminByLoginAsync(string loginName, string password);
    }
}
