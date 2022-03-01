using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;
using EletroStockAPI.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _usersRepository.GetAllUsers();

            return Ok(new
            {
                Users = users,
                Message = "Teste realizado com sucesso!"
            });
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateModel user)
        {
            var newUser = EntityHelper.CreateUser(user);

            var result = _usersRepository.CreateUser(newUser);

            return Ok(new
            {
                Success = result,
                Message = "Usúario criado com sucesso!"
            });
        }

        [HttpPut]
        public IActionResult EditUser(UserModel user)
        {

            var result = _usersRepository.UpdateUser(user.ConvertToUser());

            return Ok(new { 
                Message = result
            });
        }
        
        [Route("{id}")]
        [HttpPut]
        public IActionResult ChangeStatus(string id, [FromQuery] bool active)
        {
            var user = _usersRepository.GetUser(id);

            if (active)
            {
                user.Status = Status.Active;
            }
            else
            {
                user.Status = Status.Inactive;
            }

            _usersRepository.UpdateUser(user);

            return Ok(new
            {
                Message = "Usuario alterado com sucesso!"
            });
        }
    }
}
