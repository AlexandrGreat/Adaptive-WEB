using Microsoft.AspNetCore.Mvc;
using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Authorization;

namespace LR6.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public Task<User[]> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Task<User> GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        [HttpPost]
        public Task<User[]> AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        [HttpPut("{id}")]
        public Task<User[]> PutUser(User user, int id)
        {
            return _userRepository.PutUser(user, id);
        }

        [HttpDelete("{id}")]
        public Task<User[]> DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}