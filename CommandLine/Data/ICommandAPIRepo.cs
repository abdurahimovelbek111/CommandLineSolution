using CommandLine.Models;

namespace CommandLine.Data
{
    public interface ICommandAPIRepo
    {
        // Commands in read
        Task<IEnumerable<Command>> GetAllCommandsAsync();
        // Commonds id 
        Task<Command> GetAllCommandByIdAsync(int id);
        // Commond Add
        Task CreateCommandAsync(Command command);
        //Commond Update
        Task UpdateCommandAsync(Command command);
        //Commond delete
        void DeleteCommandAsync(Command command);
        //SaveChanges
        public Task<bool> SaveChangesAsync();

    }
}
