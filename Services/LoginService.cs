using LR6.Interfaces;
using LR6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace LR6.Services
{
    public class LoginService:ILoginService
    {
        private UserRepository _userRepository;
        private PasswordService _passwordService;
        private IConfiguration _config;

        public LoginService(UserRepository userRepository, IConfiguration config, PasswordService passwordService)
        {
            _userRepository = userRepository;
            _config = config;
            _passwordService = passwordService;
        }

        public string Login(LoginModel login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                var token = Generate(user);
                Console.WriteLine("Code:" + token);

                return token;
            }

            return "User not found";
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.GivenName,user.Name+" "+user.Surname),
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginModel login)
        {
            var currentUser = UserRepository.userList.FirstOrDefault(o => o.Email == login.Email);
            var userIndex=UserRepository.userList.IndexOf(currentUser);
            var passwordCheck = _passwordService.Verify(currentUser.Password,login.Password);

            currentUser.LastLogin = DateOnly.FromDateTime(DateTime.Now);
            
            _userRepository.PutUser(currentUser, userIndex + 1);

            if (currentUser != null && !passwordCheck)
            {
                currentUser.LoginAttempts += 1;
            }

            if (currentUser != null && passwordCheck)
            {
                return currentUser;
            }
            
            return null;
        }

        public async Task<User[]> RegisterUser(RegistrationModel newUser)
        {
            var userExists= UserRepository.userList.FirstOrDefault(o => o.Email == newUser.Email);
            if (userExists != null) throw new Exception("This email is already in use, try another");

            var passwordHash = _passwordService.Hash(newUser.Password);

            var user = new User();
            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Password = passwordHash;
            user.Surname = newUser.Surname;
            user.BirthDate = newUser.BirthDate;
            user.LoginAttempts = 0;
            user.LastLogin = DateOnly.FromDateTime(DateTime.Now);
            await _userRepository.AddUser(user);
            return await _userRepository.GetAllUsers();
        }
    }
}
