using AutoMapper;
using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;
using EletroStockAPI.Models.Shared;
using EletroStockAPI.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _usersRepository.GetAllUsers();

            var usersModel = _mapper.Map<List<UserModel>>(users);

            return Ok(new
            {
                Users = usersModel,
                Message = "Teste realizado com sucesso!"
            });
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateModel user)
        {
            var newUser = EntityHelper.CreateUser(user);

            var userValidity = _usersRepository.GetUserByEmail(user.Email);

            if(userValidity != null)
            {
                return BadRequest(new MessageBase<object> { Message = UserMessage.EmailAlreadyInUse });
            }

            var result = _usersRepository.CreateUser(newUser);

            return Ok(new MessageBase<User>
            {
                Result = newUser,
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
