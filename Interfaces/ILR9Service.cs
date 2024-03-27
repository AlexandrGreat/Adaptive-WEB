using LR6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Interfaces
{
    public interface ILR9Service
    {
        public Task<int> GetInt();
        public Task<string> GetString();
        public Task<FileStreamResult> GetExcel();
    }
}
