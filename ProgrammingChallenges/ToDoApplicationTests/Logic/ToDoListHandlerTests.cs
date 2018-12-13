using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;
using System.IO;

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

            IEntryModel currentEntryModel = handler.EntryModelList[0];

            const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            Assert.AreEqual(entryName, currentEntryModel.EventName);
            Assert.AreEqual(currentDateTime.ToString(dateTimeFormat), currentEntryModel.DueDate.ToString(dateTimeFormat));
        }

        [TestMethod]
        public void AddEntryTest_NullAsEventName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry(null, DateTime.Now));
        }

        [TestMethod]
        public void AddEntryTest_EmtpyStringAsEventName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry("", DateTime.Now));
        }

        [TestMethod]
        public void AddEntryTest_WhitespaceAsEventName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry(" ", DateTime.Now));
        }

        [TestMethod]
        public void RemoveEntryTest_ValidEntry()
        {
            const string eventName = "Test";
            DateTime dateTime = DateTime.Now;
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry(eventName, dateTime);
            Assert.IsTrue(handler.EntryModelList.Count == 1);
            handler.RemoveEntry(eventName, dateTime);
            Assert.IsTrue(handler.EntryModelList.Count == 0);
        }

        [TestMethod]
        public void RemoveEntryTest_NoEntryInList_IgnoresRemove()
        {
            ToDoListHandler handler = new ToDoListHandler();
            handler.RemoveEntry("Test", DateTime.Now);
        }

        [TestMethod]
        public void RemoveEntryTest_EntryNotFound_IgnoresRemove()
        {
            const string eventName = "Test";
            const string secondEventName = "Test2";
            DateTime dateTime = DateTime.Now;
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry(secondEventName, dateTime);
            handler.RemoveEntry(eventName, dateTime);
        }

        [TestMethod]
        public void RemoveEntryTest_NullAsEntryName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry(null, DateTime.Now));
        }

        [TestMethod]
        public void RemoveEntryTest_EmtpyStringAsEntryName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry("", DateTime.Now));
        }

        [TestMethod]
        public void RemoveEntryTest_WhitespaceAsEventName_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.AddEntry(" ", DateTime.Now));
        }

        [TestMethod]
        public void GetEntriesTest_ValidParameters()
        {
            const string eventName = "Test";
            DateTime date = DateTime.Now;
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry(eventName, date);
            IEntryModel[] entryModels = handler.GetEntries(DateTime.Today, DateTime.Today);
            Assert.AreEqual(1, entryModels.Length);
            Assert.IsTrue(entryModels[0].EventName == eventName);
            Assert.IsTrue(entryModels[0].DueDate == date);
        }

        [TestMethod]
        public void GetEntriesTest_FromDateLaterThanToDate_ThrowsArgumentException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            Assert.ThrowsException<ArgumentException>(() => handler.GetEntries(DateTime.Today.AddDays(1), DateTime.Now));
        }

        [TestMethod]
        public void GetEntriesTest_MultipleEntries_OneEntryInRange()
        {
            const string eventName = "Test";
            const string eventName2 = "Test2";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(1);
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry(eventName, date1);
            handler.AddEntry(eventName2, date2);
            Assert.AreEqual(2, handler.EntryModelList.Count);
            IEntryModel[] returnEntryModels = handler.GetEntries(date1, date1);
            Assert.AreEqual(1, returnEntryModels.Length);
            Assert.AreEqual(eventName, returnEntryModels[0].EventName);
            Assert.AreEqual(date1, returnEntryModels[0].DueDate);
        }

        [TestMethod]
        public void SaveEntriesTest_SingleEntry_ShouldSave()
        {
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry("Test", DateTime.Now);
            handler.SaveEntries();
            Assert.IsTrue(File.Exists(handler.FileName));
            File.Delete(handler.FileName);
        }

        [TestMethod]
        public void SaveEntriesTest_NoEntry_ShouldSave()
        {
            ToDoListHandler handler = new ToDoListHandler();
            handler.SaveEntries();
            Assert.IsTrue(File.Exists(handler.FileName));
            File.Delete(handler.FileName);
        }

        [TestMethod]
        public void SaveEntriesTest_MultipleEntries_ShouldSave()
        {
            ToDoListHandler handler = new ToDoListHandler();
            handler.AddEntry("Test", DateTime.Now);
            handler.AddEntry("Bla", DateTime.Now.AddDays(-3));
            handler.AddEntry("Blub", DateTime.Now.AddDays(5));
            handler.SaveEntries();
            Assert.IsTrue(File.Exists(handler.FileName));
            File.Delete(handler.FileName);
        }

        [TestMethod]
        public void LoadEntriesTest_DatabaseExistingWithEntries_ShouldLoad()
        {
            Dictionary<string, DateTime> entryDict = new Dictionary<string, DateTime>()
            {
                { "Test", DateTime.Now },
                { "Bla", DateTime.Now.AddDays(3)},
            };

            ToDoListHandler handler = new ToDoListHandler();
            foreach (KeyValuePair<string, DateTime> entryNameAndDateTime in entryDict)
            {
                handler.AddEntry(entryNameAndDateTime.Key, entryNameAndDateTime.Value);
            }
            handler.SaveEntries();

            handler = new ToDoListHandler();
            handler.LoadEntries();
            Assert.AreEqual(2, handler.EntryModelList.Count);
            foreach (IEntryModel entry in handler.EntryModelList)
            {
                bool found = false;
                foreach (KeyValuePair<string, DateTime> entryNameAndDateTime in entryDict)
                {
                    if (entry.EventName == entryNameAndDateTime.Key && entry.DueDate.ToString(handler.DateTimeFormat) == entryNameAndDateTime.Value.ToString(handler.DateTimeFormat))
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    Assert.Fail("Entry not found in Database");
                }
            }

            File.Delete(handler.FileName);
        }

        [TestMethod]
        public void LoadEntriesTest_DatabaseExistingNoEntries_ShouldLoad()
        {
            ToDoListHandler handler = new ToDoListHandler();
            handler.SaveEntries();
            handler.LoadEntries();
            Assert.AreEqual(0, handler.EntryModelList.Count);

            File.Delete(handler.FileName);
        }

        [TestMethod]
        public void LoadEntriesTest_DatabaseNotExisting_ThrowsException()
        {
            ToDoListHandler handler = new ToDoListHandler();
            if (File.Exists(handler.FileName))
            {
                File.Delete(handler.FileName);
            }
            Assert.ThrowsException<FileNotFoundException>(() => handler.LoadEntries());

            File.Delete(handler.FileName);
        }
    }
}