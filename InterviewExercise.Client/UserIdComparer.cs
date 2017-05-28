using System.Collections.Generic;

namespace InterviewExercise.Client {
    public class UserIdComparer : IComparer<User> {
        public int Compare(User x, User y) {
            if (x.Id == y.Id) return 0;
            if (x.Id > y.Id) return 1;
            return -1;
        }
    }
}