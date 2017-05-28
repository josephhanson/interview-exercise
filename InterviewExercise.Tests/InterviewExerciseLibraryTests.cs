using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using InterviewExercise.Client;
using InterviewExercise.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewExercise.Tests {
    [TestClass]
    public class InterviewExerciseLibraryTests {
        private User _user1;
        private User _user2;
        private User _user3;
        private User _user4;

        [TestInitialize]
        public void Initialize() {
            _user1 = new User() { Id = 1, Name = "John" };
            _user2 = new User() { Id = 2, Name = "Jane" };
            _user3 = new User() { Id = 3, Name = "Mike" };
            _user4 = new User() { Id = 4, Name = "Bob" };
        }

        [TestMethod]
        public void ItShouldReturnAnEmptyCollection() {
            var example = new InterviewExerciseLibrary<User>();
            var results = example.Dump();

            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ItShouldReturnACollectionWithOneItemWhenInstantiatedWithAnObject() {
            var example = new InterviewExerciseLibrary<User>(_user1);
            var results = example.Dump();

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void ItShouldReturnANonEmptyCollectionWhenInstantiatedWithAList() {
            var list = new List<User> { _user1, _user2, _user3, _user4 };
            var example = new InterviewExerciseLibrary<User>(list);
            var results = example.Dump();

            Assert.AreEqual(4, results.Count);
        }

        [TestMethod]
        public void ItShouldAddASingleEntry() {
            var example = new InterviewExerciseLibrary<User>();
            example.Add(_user1);

            var results = example.Dump();

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void ItShouldAddTwoEntries() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            var results = example.Dump();

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void ItShouldFindAnEntryById() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            var results = example.Find(x => x.Id == 1);

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results[0].Id);
        }

        [TestMethod]
        public void ItShouldNotFindAnEntryById() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            var results = example.Find(x => x.Id == 10);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ItShouldFindAnEntryByName() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            var results = example.Find(x => x.Name == "John");

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual("John", results[0].Name);
        }

        [TestMethod]
        public void ItShouldNotFindAnEntryByName() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            var results = example.Find(x => x.Name == "Mike");

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ItShouldUpdateAnEntryByReference() {
            _user2.Name = "Janey";
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            example.Update(_user1);
            var results = example.Find(x => x.Id == 2);

            Assert.IsNotNull(results);
            Assert.AreEqual("Janey", results[0].Name);
        }

        [TestMethod]
        public void ItShouldUpdateAnEntryByValue() {
            var updateUser = new User() { Id = 2, Name = "Janey" };
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            example.Update(updateUser);
            var results = example.Find(x => x.Id == 2);

            Assert.IsNotNull(results);
            Assert.AreEqual("Janey", results[0].Name);
        }

        [TestMethod]
        public void ItShouldDeleteAnEntryByReference() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            example.Delete(_user1);
            var results = example.Find(x => x.Id == 1);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ItShouldDeleteAnEntryByValue() {
            var list = new List<User>() { _user1, _user2 };
            var example = new InterviewExerciseLibrary<User>(list);
            var user1 = new User { Id = 1, Name = "John"};

            example.Delete(user1);
            var results = example.Find(x => x.Id == 1);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ItShouldReturnACollectionSortedById() {
            var list = new List<User>() { _user2, _user1, _user4, _user3 };
            var example = new InterviewExerciseLibrary<User>(list);

            IComparer<User> comparer = new UserIdComparer();
            var results = example.Dump(comparer);

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual(2, results[1].Id);
            Assert.AreEqual(3, results[2].Id);
            Assert.AreEqual(4, results[3].Id);
        }

        [TestMethod]
        public void ItShouldReturnACollectionSortedByName() {
            var list = new List<User>() { _user3, _user1, _user2, _user4 };
            var example = new InterviewExerciseLibrary<User>(list);

            IComparer<User> comparer = new UserNameComparer();
            var results = example.Dump(comparer);

            Assert.IsNotNull(results);
            Assert.AreEqual(4, results[0].Id);
            Assert.AreEqual(2, results[1].Id);
            Assert.AreEqual(1, results[2].Id);
            Assert.AreEqual(3, results[3].Id);
        }
    }
}
