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
            ThrowArgumentExceptionIfNotValidEventName(name);

            EntryModel currentEntryModel = new EntryModel()
            {
                EventName = name,
                DueDate = dateTime,
            };

            EntryModelList.Add(currentEntryModel);
        }


        public void RemoveEntry(string name, DateTime dateTime)
        {
            ThrowArgumentExceptionIfNotValidEventName(name);

            for (int i = 0; i < EntryModelList.Count; i++)
            {
                if (EntryModelList[i].EventName == name && EntryModelList[i].DueDate == dateTime)
                {
                    EntryModelList.Remove(EntryModelList[i]);
                    break;
                }
            }
        }

        private void ThrowArgumentExceptionIfNotValidEventName(string name)
        {
            if (!IsValidEventName(name))
            {
                throw new ArgumentException($"Input Invalid: '{name}'. Expected non-null, non-emtpy, non-whitespace string");
            }
        }

        private bool IsValidEventName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public void DisplayEntries(DateTime fromDate, DateTime toDate)
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
