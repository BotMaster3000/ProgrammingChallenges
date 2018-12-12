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

        public IEntryModel[] GetEntries(DateTime fromDate, DateTime toDate)
        {
            ThrowArgumentExceptionIfFromDateLaterThanToDate(fromDate, toDate);

            List<IEntryModel> returnEntryModels = new List<IEntryModel>();
            foreach (IEntryModel entryModel in EntryModelList)
            {
                if (EntryIsInRange(entryModel, fromDate, toDate))
                {
                    returnEntryModels.Add(entryModel);
                }
            }
            return returnEntryModels.ToArray();
        }

        private void ThrowArgumentExceptionIfFromDateLaterThanToDate(DateTime fromDate, DateTime toDate)
        {
            string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            if(DateTime.Compare(fromDate, toDate) > 0)
            {
                throw new ArgumentException($"Input Invalid: fromDate is later than toDate: {fromDate.ToString(dateTimeFormat)}|{toDate.ToString(dateTimeFormat)}");
            }
        }

        private bool EntryIsInRange(IEntryModel entryModel, DateTime fromDate, DateTime toDate)
        {
            return entryModel.DueDate.Year >= fromDate.Year
                    && entryModel.DueDate.Month >= fromDate.Month
                    && entryModel.DueDate.Day >= fromDate.Day
                    && entryModel.DueDate.Year <= toDate.Year
                    && entryModel.DueDate.Month <= toDate.Month
                    && entryModel.DueDate.Day <= toDate.Day;
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
