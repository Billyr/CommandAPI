using System;
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
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            _context.commandItems.Add(cmd);
           
        }


        public void DeleteCommnad(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            _context.commandItems.Remove(cmd);
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommnad(Command cmd)
        {
        
        }
    }
}