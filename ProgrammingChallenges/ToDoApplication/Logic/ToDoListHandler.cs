using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;

namespace ToDoApplication.Logic
{
    public class ToDoListHandler : IToDoListHandler
    {
        public List<IEntryModel> EntryModels { get; set; }

        public void AddEntry()
        {
            throw new NotImplementedException();
        }

        public void DisplayEntries()
        {
            throw new NotImplementedException();
        }

        public void DisplayOldEntries()
        {
            throw new NotImplementedException();
        }

        public void LoadEntries()
        {
            throw new NotImplementedException();
        }

        public void SaveEntries()
        {
            throw new NotImplementedException();
        }

        public void RemoveEntry()
        {
            throw new NotImplementedException();
        }
    }
}
