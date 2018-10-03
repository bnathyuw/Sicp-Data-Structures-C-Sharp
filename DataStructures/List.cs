using System;

namespace DataStructures
{
    public static class List
    {
        public static List<T> Of<T>(params T[] items) =>
            items.Length == 0
                ? new List<T>(null)
                : new List<T>(Cons.Of(items[0], Of(items.Tail())));

        private static T[] Tail<T>(this T[] items)
        {
            var newItems = new T[items.Length - 1];
            Array.Copy(items, 1, newItems, 0, items.Length - 1);
            return newItems;
        }
    }

    public class List<T>
    {
        private readonly Cons<T, List<T>> _cons;
        
        public List(Cons<T, List<T>> cons) => _cons = cons;

        private bool Null => _cons is null;

        public List<T> Append(List<T> list2) =>
            Null
                ? list2
                : new List<T>(Cons.Of(_cons.Car, _cons.Cdr.Append(list2)));

        public T ListRef(int index) =>
            index == 0
                ? _cons.Car
                : _cons.Cdr.ListRef(index - 1);

        public int Length => 
            Null ? 0 : _cons.Cdr.Length + 1;

        public List<TOut> Map<TOut>(Func<T, TOut> proc) =>
            Null
                ? new List<TOut>(null)
                : new List<TOut>(Cons.Of(proc(_cons.Car), _cons.Cdr.Map(proc)));

        public List<T> InsertAt(int index, T item) =>
            index == 0
                ? new List<T>(Cons.Of(item, this))
                : new List<T>(Cons.Of(_cons.Car, _cons.Cdr.InsertAt(index - 1, item)));

        public override string ToString() => Null ? "" : $"{_cons}";
    }
}