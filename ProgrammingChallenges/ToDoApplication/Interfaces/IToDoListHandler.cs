using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Interfaces
{
    public interface IToDoListHandler
    {
        List<IEntryModel> EntryModelList { get; set; }

        void LoadEntries();
        void SaveEntries();
        void DisplayEntries(DateTime fromDate, DateTime toDate);
        void AddEntry(string name, DateTime dateTime);
        void RemoveEntry(string name, DateTime dateTime);
    }
}
