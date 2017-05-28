using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InterviewExercise.Library {
    public class InterviewExerciseLibrary<T> : IInterviewExerciseInterface<T> where T : IComparable<T> {
        private readonly IList<T> _list;

        public InterviewExerciseLibrary() {
            _list = new List<T>();
        }

        public InterviewExerciseLibrary(T element) : this() {
            _list.Add(element);
        }

        public InterviewExerciseLibrary(IList<T> list) {
            _list = list;
        }

        public void Add(T item) {
            _list.Add(item);
        }

        public IReadOnlyList<T> Find(Func<T, bool> selector) {
            return new ReadOnlyCollection<T>(_list.Where(selector).ToList());
        }

        public void Update(T item) {
            for (int i = 0; i < _list.Count; i++) {
                if (_list[i].CompareTo(item) == 0) {
                    _list[i] = item;
                }
            }
        }

        public void Delete(T item) {
            for (int i = 0; i < _list.Count; i++) {
                if (_list[i].CompareTo(item) == 0) {
                    _list.RemoveAt(i);
                }
            }
        }

        public IReadOnlyList<T> Dump() {
            return new ReadOnlyCollection<T>(_list);
        }

        public IReadOnlyList<T> Dump(IComparer<T> comparer) {
            ((List<T>)_list).Sort(comparer);

            return new ReadOnlyCollection<T>(_list);
        }
    }
}