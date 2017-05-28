using System.Collections.Generic;

namespace InterviewExercise.Client {
    public class UserNameComparer : IComparer<User> {
        public int Compare(User x, User y) {
            return string.Compare(x.Name, y.Name);
        }
    }
}