using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Logic.Tests
{
    [TestClass]
    public class ToDoListHandlerTests
    {
        [TestMethod]
        public void AddEntryTest_ValidEntry()
        {
            string entryName = "testEntry";
            DateTime currentDateTime = DateTime.Now;

            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry(entryName, DateTime.Now);

            Interfaces.IEntryModel currentEntryModel = handler.EntryModelList[0];

            const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            Assert.AreEqual(entryName, currentEntryModel.EventName);
            Assert.AreEqual(currentDateTime.ToString(dateTimeFormat), currentEntryModel.DueDate.ToString(dateTimeFormat));
        }

        [TestMethod]
        public void AddEntryTest_InvalidEventNames()
        {
            ToDoListHandler handler = new ToDoListHandler();
            List<string> errorList = new List<string>();
            try
            {
                handler.AddEntry("", DateTime.Now);
                errorList.Add("Accepted empty string as Entry");
            }
            catch { }
            try
            {
                handler.AddEntry(null, DateTime.Now);
                errorList.Add("Accepted null as Entry");
            }
            catch { }
            try
            {
                handler.AddEntry(" ", DateTime.Now);
                errorList.Add("Accepted whitespace as Entry");
            }

            catch { }

            if (errorList.Count > 0)
            {
                Assert.Fail($"{errorList.Count} Errors: {String.Join(";", errorList)}");
            }
        }
    }
}