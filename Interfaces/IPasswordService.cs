namespace LR6.Interfaces
{
    public interface IPasswordService
    {
        public string Hash(string password);
        public bool Verify(string passwordHash, string inputPassword);
    }
}
