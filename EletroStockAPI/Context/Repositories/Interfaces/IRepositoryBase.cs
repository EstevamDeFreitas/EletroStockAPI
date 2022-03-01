namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface IRepositoryBase : IDisposable
    {
        public void EndTransaction(bool success);

        public void Dispose(bool disposing);

        public void Dispose();
    }
}
