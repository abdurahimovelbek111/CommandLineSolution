using CommandLine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;

        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        // Command add
        public async Task CreateCommandAsync(Command command)
        {
            if (command==null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            await _context.Commands.AddAsync(command);
        }

        public void DeleteCommandAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Remove(command);           
        }

        public async Task<Command> GetAllCommandByIdAsync(int id)
        {
           return await _context.Commands.FirstOrDefaultAsync(command => command.Id == id);            
        }

        public async Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            return await _context.Commands.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>=0;
        }

        public async Task UpdateCommandAsync(Command command)
        {
            if(command==null)
                throw new ArgumentNullException(nameof(command));

        }
    }
}
