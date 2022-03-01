using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class UsersRepository : RepositoryBase, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {
        }

        public bool CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                var user = GetUser(userId);

                if(user != null)
                {
                    context.Users.Remove(user);

                    EndTransaction(true);

                    return true;
                }

                EndTransaction(false);

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User? GetUser(string userId)
        {
            return context.Users.Find(userId); 
        }

        public bool UpdateUser(User user)
        {
            try
            {
                context.Update(user);

                EndTransaction(true);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
