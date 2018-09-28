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

        public static List<T> Append<T>(this List<T> list1, List<T> list2) =>
            list1.Null
                ? list2
                : new List<T>(Cons.Of(list1.Car, list1.Cdr.Append(list2)));

        public static T ListRef<T>(this List<T> list, int index) =>
            index == 0
                ? list.Car
                : list.Cdr.ListRef(index - 1);

        public static int Length<T>(this List<T> list) => LengthIter(list, 0);

        private static int LengthIter<T>(List<T> list, int runningTotal) =>
            list.Null
                ? runningTotal
                : LengthIter(list.Cdr, runningTotal + 1);

        public static List<TOut> Map<TOut, T>(this List<T> list, Func<T, TOut> proc) =>
            list.Null
                ? new List<TOut>(null)
                : new List<TOut>(Cons.Of(proc(list.Car), list.Cdr.Map(proc)));
    }

    public class List<T>
    {
        private readonly Cons<T, List<T>> _cons;

        internal List(Cons<T, List<T>> cons) => _cons = cons;

        public T Car => _cons.Car;
        
        public List<T> Cdr => _cons.Cdr;
        
        public bool Null => _cons is null;
    }
}