﻿using System;
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
        IEntryModel[] GetEntries(DateTime fromDate, DateTime toDate);
        IEntryModel[] GetEntries(string eventName);
        void AddEntry(string name, DateTime dateTime);
        void RemoveEntry(string name, DateTime dateTime);

        string FileName { get; }
    }
}
