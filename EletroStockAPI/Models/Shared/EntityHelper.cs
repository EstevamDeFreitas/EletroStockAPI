using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Models.Shared
{
    /// <summary>
    /// Represents a group of actions that can be used by an entity.
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// Creates a new guid for an entity id.
        /// </summary>
        /// <returns>Returns a guid string</returns>
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Converts a UserCreateModel in a new user with a generated guid and active status by default
        /// </summary>
        /// <returns>A new user</returns>
        public static User CreateUser(UserCreateModel user)
        {
            return new User
            {
                Id = GenerateGuid(),
                Status = Status.Active,
                UserType = user.UserType,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
