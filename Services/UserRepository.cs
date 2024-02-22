using LR6.Interfaces;
using LR6.Models;

namespace LR6.Services
{
    public class UserRepository:IUserRepository
    {
        public async Task<User[]> GetAllUsers() 
        {
            return userList.ToArray();
        }

        public async Task<User> GetUser(int id)
        {
            return userList[id - 1];
        }

        public async Task<User[]> PutUser(User user, int id)
        {
            userList[id-1]=user;
            return userList.ToArray();
        }

        public async Task<User[]> AddUser(User user)
        {
            userList.Add(user);
            return userList.ToArray();
        }

        public async Task<User[]> DeleteUser(int id)
        {
            userList.RemoveAt(id-1);
            return userList.ToArray();
        }

        private static User[] data = {
            new User { Name="Jake",Age=21,Email="notemail1@notmail.notdomain" },
            new User { Name = "Alex", Age = 22, Email = "notemail2@notmail.notdomain" },
            new User { Name = "Max", Age = 23, Email = "notemail3@notmail.notdomain" },
            new User { Name = "Sue", Age = 24, Email = "notemail4@notmail.notdomain" },
            new User { Name = "Tim", Age = 25, Email = "notemail5@notmail.notdomain" },
            new User { Name = "Elizabeth", Age = 26, Email = "notemail6@notmail.notdomain" },
            new User { Name = "Jane", Age = 27, Email = "notemail7@notmail.notdomain" },
            new User { Name = "Arthur", Age = 28, Email = "notemail8@notmail.notdomain" },
            new User { Name = "Frank", Age = 29, Email = "notemail9@notmail.notdomain" },
            new User { Name = "Mike", Age = 30, Email = "notemail10@notmail.notdomain" },
        };
        public List<User> userList = new List<User>(data);
    }
}
