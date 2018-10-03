using System;

namespace DataStructures.Tests
{
    public static class NonEmptyList
    {
        public static NonEmptyList<T> Of<T>(T[] objects) => List.Of(objects);
    }

    public class NonEmptyList<T>
    {
        private readonly List<T> _list;

        private NonEmptyList(List<T> list) => _list = list;

        public List<T> Append(List<T> list2) => _list.Append(list2);

        public T ListRef(int index) => _list.ListRef(index);

        public int Length => _list.Length;

        public List<TOut> Map<TOut>(Func<T, TOut> proc) => _list.Map(proc);

        public List<T> InsertAt(int index, T item) => _list.InsertAt(index, item);
        
        public static implicit operator List<T>(NonEmptyList<T> nonEmptyList) => nonEmptyList._list;

        public static implicit operator NonEmptyList<T>(List<T> list) => new NonEmptyList<T>(list);
    }
}