using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ICommandAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommnad(Command cmd);
        void UpdateCommnad(Command cmd);
        void DeleteCommnad(Command cmd);
    }
}
