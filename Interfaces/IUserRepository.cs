using LR6.Models;

namespace LR6.Interfaces
{
    public interface IUserRepository
    {
        public Task<User[]> GetAllUsers();
        public Task<User> GetUser(int id);
        public Task<User[]> PutUser(User user, int id);
        public Task<User[]> DeleteUser(int id);
        public Task<User[]> AddUser(User user);
    }
}
