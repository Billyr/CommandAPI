using System.Collections.Generic;
using CommandAPI.Models;
using System.Linq;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {

        private readonly CommandContext _context;

        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }



        public void CreateCommnad(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommnad(Command cmd)
        {
            throw new System.NotImplementedException();
        }


        public IEnumerable<Command> GetAllCommands()
        {
            return _context.commandItems.ToList();
        }


        public Command GetCommandById(int id)
        {
            return _context.commandItems.FirstOrDefault(p => p.Id == id);
        }



        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommnad(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}