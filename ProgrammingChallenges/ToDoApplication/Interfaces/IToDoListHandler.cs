using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Interfaces
{
    public interface IToDoListHandler
    {
        List<IEntryModel> EntryModels { get; set; }

        void LoadEntries();
        void SaveEntries();
        void DisplayEntries();
        void DisplayOldEntries();
        void AddEntry();
        void RemoveEntry();
    }
}
