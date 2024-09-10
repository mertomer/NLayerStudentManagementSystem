using MSTCore.UnitOfWorks;
using MSTRepository;
using MSTCore.UnitOfWorks;

namespace MSTRepository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _disposed = false; // Kaynak serbest bırakıldı mı kontrolü için flag

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        // IDisposable.Dispose metodu
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();  // DbContext'i serbest bırak
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  // Garbage Collector'u çağırmaması için finalize'ı baskılar
        }
    }
}
