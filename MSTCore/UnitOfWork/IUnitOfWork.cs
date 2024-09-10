using System;
using System.Threading.Tasks;

namespace MSTCore.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}
