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

        public static User[] data = {
            new User { Name="Jake", Surname="First", BirthDate=new DateOnly(2001,01,01),Email="notemail1@notmail.notdomain",Password="K/+66iFAVHh4G088oo5Vfw==;YxX3YlWBr5BMwZ69MsoLDlDRk7kNXEHUHFQuklRp1kk=" }, //1111
            new User { Name = "Alex", Surname="Second", BirthDate=new DateOnly(2002,02,02), Email = "notemail2@notmail.notdomain",Password="Tliry9Db43YZrovtpnT+fA==;CrdeA2aIbsjZRruiLxXeNSP0K6JhZ0wl9IzkK9epSlw=" }, //2222
            new User { Name = "Max", Surname="Third", BirthDate=new DateOnly(2003,03,03), Email = "notemail3@notmail.notdomain",Password="rblCYQHnDSHNwfVDUSn3mw==;fUV0eXp762XHSo5lRFYOF8actITXWovi+ZKXz3m3DWY=" }, //3333
            new User { Name = "Sue", Surname="Fourth", BirthDate=new DateOnly(2004,04,04), Email = "notemail4@notmail.notdomain",Password="yMepnrrGskZB3mKnv6auDg==;9PmwUHG/eDTZhZTw9ju64sIb83qDnKzwWWmaUdWFgZg=" }, //4444
            new User { Name = "Tim", Surname="Fifth", BirthDate=new DateOnly(2005,05,05), Email = "notemail5@notmail.notdomain",Password="jMX6c6VR7aS7p2OvE1dLxQ==;hMFBct6E7yKOS4KIiD5n+MF5HLYYRF7RsduRBHa2N+I=" }, //5555
            new User { Name = "Elizabeth", Surname="Sixth", BirthDate=new DateOnly(2006,06,06), Email = "notemail6@notmail.notdomain",Password="39cqA5RMz8+vulWxf/UdtQ==;YhR58qhrNcxC4tczCAiFnezyXSk5ycFUZ5O6fMmu8ns=" }, //6666
            new User { Name = "Jane", Surname="Seventh", BirthDate=new DateOnly(2007,07,07), Email = "notemail7@notmail.notdomain",Password="N95x7RXbbFrlKeIBXRx94w==;ipyilbuR3w29kmy2B1yfEYmwUX6R5cVqI9ZkxRUV9ko=" }, //7777
            new User { Name = "Arthur", Surname="Eighth", BirthDate=new DateOnly(2008,08,08), Email = "notemail8@notmail.notdomain",Password="FBAWmNfQeR/j0im5nSfLCQ==;G+Qzm3z55V6+UlBnybaP8YN9NyMtibKUlqTI+SPegTk=" }, //8888
            new User { Name = "Frank", Surname="Nineth", BirthDate=new DateOnly(2009,09,09), Email = "notemail9@notmail.notdomain",Password="b28btJMMYcKm2P0RKwtofQ==;f6C3KQiLbTDU7+FWU1V2h7u+vY62xRYEUUMdKh1zSVI=" }, //9999
            new User { Name = "Mike", Surname="Tenth", BirthDate=new DateOnly(2010,10,10), Email = "notemail10@notmail.notdomain",Password="KvacS7VNWLB277iSgW/SlQ==;/Cd+6gs58NNVLI1fB7tLlfWuWyYoMGzjKiM/auWXGEw=" }, //1000
        };
        public static List<User> userList = new List<User>(data);
    }
}
