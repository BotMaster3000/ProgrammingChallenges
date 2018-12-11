using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;

namespace ToDoApplication.Models
{
    public class EntryModel : IEntryModel
    {
        public DateTime DueDate { get; set; }
        public string EventName { get; set; }
    }
}
