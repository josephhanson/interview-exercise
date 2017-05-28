using System;
using InterviewExercise.Client;
using InterviewExercise.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InterviewExercise.Tests {
    [TestClass]
    public class InterviewExerciseExceptionsTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldNotAllowANullUserInConstructor() {
            User u = null;
            var example = new InterviewExerciseLibrary<User>(u);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldNotAllowANullListInConstructor() {
            List<User> list = null;
            var example = new InterviewExerciseLibrary<User>(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldNotAllowAddingANullUserToTheList() {
            User user = null;
            var example = new InterviewExerciseLibrary<User>();
            example.Add(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldNotAllowUpdatingANullUser() {
            var user1 = new User() { Id = 1, Name = "John" };
            var user2 = new User() { Id = 2, Name = "Jane" };
            var list = new List<User> { user1, user2 };
            var example = new InterviewExerciseLibrary<User>(list);

            User user = null;
            example.Update(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldNotAllowDeletingANullUser() {
            var user1 = new User() { Id = 1, Name = "John" };
            var user2 = new User() { Id = 2, Name = "Jane" };
            var list = new List<User> {user1, user2};
            var example = new InterviewExerciseLibrary<User>(list);

            User user = null;
            example.Delete(user);
        }
    }
}
