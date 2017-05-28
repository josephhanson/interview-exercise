using System;
using System.Collections.Generic;

namespace InterviewExercise.Library {
    public interface IInterviewExerciseInterface<T> where T : IComparable<T> {
        void Add(T item);
        IReadOnlyList<T> Find(Func<T, bool> selector);
        void Update(T item);
        void Delete(T item);
        IReadOnlyList<T> Dump();
        IReadOnlyList<T> Dump(IComparer<T> comparer);
    }
}