using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;
using ToDoApplication.Models;

namespace ToDoApplication.Logic
{
    public class ToDoListHandler : IToDoListHandler
    {
        public List<IEntryModel> EntryModelList { get; set; } = new List<IEntryModel>();

        public void AddEntry(string name, DateTime dateTime)
        {
            if (IsValidEventName(name))
            {
                EntryModel currentEntryModel = new EntryModel()
                {
                    EventName = name,
                    DueDate = dateTime,
                };

                EntryModelList.Add(currentEntryModel);
            }
            else
            {
                throw new ArgumentException($"Input Invalid: '{name}'");
            }
        }

        private bool IsValidEventName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public void RemoveEntry(string name, DateTime dateTime)
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

    }
}
