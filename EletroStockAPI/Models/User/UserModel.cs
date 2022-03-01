using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Status { get; set; }
        public char UserType { get; set; }

        /// <summary>
        /// Converts the user model to a User entity
        /// </summary>
        /// <returns>A new User entity</returns>
        public User ConvertToUser()
        {
            return new User
            {
                Id = Id,
                Status = Status,
                Email = Email,
                Password = Password,
                UserType = UserType
            };
        }
    }

    public class UserCreateModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public char UserType { get; set; }
    }
}
