using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface IUsersRepository : IRepositoryBase
    {
        public User? GetUser(string userId);
        public List<User> GetAllUsers();
        public bool CreateUser(User user);
        public bool DeleteUser(string userId);
        public bool UpdateUser(User user);
    }
}
