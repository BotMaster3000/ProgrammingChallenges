using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Interfaces;

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
    }
}