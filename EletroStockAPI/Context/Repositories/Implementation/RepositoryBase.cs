using EletroStockAPI.Context.Repositories.Interfaces;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class RepositoryBase : IRepositoryBase
    {
        protected AppDbContext context;
        private bool isDisposed;

        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }

        public void EndTransaction(bool success)
        {
            if (success)
            {
                this.Save();
                return;
            }
        }
        private void Save()
        {
            context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
