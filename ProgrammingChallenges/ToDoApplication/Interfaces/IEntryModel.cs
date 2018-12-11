using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Interfaces
{
    public interface IEntryModel
    {
        DateTime DueDate { get; set; }
        string EventName { get; set; }
    }
}
