using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;

namespace ToDoApplication.Logic
{
    public class UserHandler
    {
        private readonly ToDoListHandler todoHandler = new ToDoListHandler();
        private const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public void HandleUser()
        {
            Console.Clear();
            Console.WriteLine("ToDoListApplication.");
            Console.WriteLine("Choose an option: ");
            string[] options = new string[]
            {
                "Show all ToDo's",
                "Show specific ToDo's",
                "Show today ToDo's",
                "Add ToDo",
                "Remove ToDo",
            };

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {options[i]}");
            }

            Console.WriteLine("Enter number of Action To Do (Enter /s to exit)");

            bool invalidCommand = false;

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        HandleShowAllToDos();
                        invalidCommand = false;
                        break;
                    case "2":
                        HandleShowSpecificToDos();
                        invalidCommand = false;
                        break;
                    case "3":
                        HandleShowTodayTodos();
                        invalidCommand = false;
                        break;
                    case "4":
                        HandleAddToDo();
                        invalidCommand = false;
                        break;
                    case "5":
                        HandleRemoveToDo();
                        invalidCommand = false;
                        break;
                    case "/s":
                        return;
                    default:
                        Console.WriteLine("Invalid Command entered");
                        invalidCommand = true;
                        break;
                }
            }
            while (invalidCommand);
        }

        private void HandleShowAllToDos()
        {
            Console.Clear();
            IEntryModel[] entryModels = todoHandler.GetEntries(DateTime.MinValue, DateTime.MaxValue);
            foreach (IEntryModel entryModel in entryModels)
            {
                Console.WriteLine($"{entryModel.EventName}, {entryModel.DueDate.ToString(DATETIME_FORMAT)}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void HandleShowSpecificToDos()
        {
            throw new NotImplementedException();
        }

        private void HandleShowTodayTodos()
        {
            throw new NotImplementedException();
        }

        private void HandleAddToDo()
        {
            Console.Clear();
            Console.WriteLine("Enter name of Event: ");

            string eventName = null;
            do
            {
                eventName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(eventName));

            Console.WriteLine($"Enter date for Event ({DATETIME_FORMAT})");

            DateTime eventDate = DateTime.Now;
            while (true)
            {
                try
                {
                    string dateTimeString = Console.ReadLine();
                    eventDate = DateTime.ParseExact(dateTimeString, DATETIME_FORMAT, null);

                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid DateTime-Format");
                }
            }

            todoHandler.AddEntry(eventName, eventDate);
        }

        private void HandleRemoveToDo()
        {
            Console.WriteLine("Enter name of Event to Delete");
            string eventName = null;
            do
            {
                eventName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(eventName));
        }
    }
}
