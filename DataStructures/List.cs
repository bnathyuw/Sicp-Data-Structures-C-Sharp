using System;

namespace DataStructures
{
    public static class List
    {
        public static List<T> Of<T>(params T[] items) => ConsIter(new List<T>(null), items.Length - 1, items);

        private static List<T> ConsIter<T>(List<T> currentCons, int index, T[] items) =>
            index < 0
                ? currentCons
                : ConsIter(new List<T>(Cons.Of(items[index], currentCons)), index - 1, items);

    }

    public class List<T>
    {
        private readonly Cons<T, List<T>> _cons;

        internal List(Cons<T, List<T>> cons) => _cons = cons;

        private bool Null => _cons is null;

        public List<T> Append(List<T> list2) =>
            Null
                ? list2
                : new List<T>(Cons.Of(_cons.Car, _cons.Cdr.Append(list2)));

        public T ListRef(int index) =>
            index == 0
                ? _cons.Car
                : _cons.Cdr.ListRef(index - 1);

        public int Length() => LengthIter(this, 0);

        private static int LengthIter(List<T> list, int runningTotal) =>
            list.Null
                ? runningTotal
                : LengthIter(list._cons.Cdr, runningTotal + 1);

        public List<TOut> Map<TOut>(Func<T, TOut> proc) =>
            Null
                ? new List<TOut>(null)
                : new List<TOut>(Cons.Of(proc(_cons.Car), _cons.Cdr.Map(proc)));

    }
}