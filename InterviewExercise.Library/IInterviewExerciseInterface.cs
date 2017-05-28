using System;
using System.Collections.Generic;

namespace InterviewExercise.Library {
    public interface IInterviewExerciseInterface<T> where T : IComparable<T> {
        void Add(T item);
        T Find(Func<T, bool> selector);
        void Update(T item);
        void Delete(T item);
        IList<T> Dump();
        IList<T> Dump(IComparer<T> comparer);
    }
}