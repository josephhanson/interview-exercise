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
            if (element == null) throw new ArgumentNullException("element");

            _list.Add(element);
        }

        public InterviewExerciseLibrary(IList<T> list) {
            if (list == null) throw new ArgumentNullException("list");

            _list = list;
        }

        public void Add(T item) {
            NullCheck(item);

            _list.Add(item);
        }

        public IReadOnlyList<T> Find(Func<T, bool> selector) {
            var results = _list.Where(selector).ToList();

            return new ReadOnlyCollection<T>(results);
        }

        public void Update(T item) {
            NullCheck(item);

            for (int i = 0; i < _list.Count; i++) {
                if (_list[i].CompareTo(item) == 0) {
                    _list[i] = item;
                }
            }
        }

        public void Delete(T item) {
            NullCheck(item);

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

        private static void NullCheck(T item) {
            if (item == null) throw new ArgumentNullException("item");
        }
    }
}