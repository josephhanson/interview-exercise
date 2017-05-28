using System;

namespace InterviewExercise.Client {
    public class User : IComparable<User> {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(User other) {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            return Id.CompareTo(other.Id);
        }
    }
}