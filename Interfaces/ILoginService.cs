using LR6.Models;

namespace LR6.Interfaces
{
    public interface ILoginService
    {
        public string Login(LoginModel login);
        public Task<User[]> RegisterUser(RegistrationModel newUser);
    }
}
