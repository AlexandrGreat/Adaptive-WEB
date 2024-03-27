using LR6.Models;
using Serilog;
using System.Reflection;

namespace LR6.Services
{
    public class SerilogDemoService
    {
        public async Task<string> Get()
        {
            string[] statuses = { "success", "OMG", "IdidIT" };
            Log.Debug("{Type} Message written at {Time} {@status}!","Debug",DateTime.Now,statuses);
            Log.Information("{Type} Message written at {Time} {status}!", "Information", DateTime.Now, "success");
            Log.Warning("Warning Message");
            Log.Error("Error Message");
            Log.Fatal("Fatal Message");
            return "DONE!";
        }
    }
}
