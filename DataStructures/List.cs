namespace DataStructures
{
    public static class List
    {
        public static List<T> Of<T>(params T[] items) => ConsRec(null, items.Length - 1, items);

        private static List<T> ConsRec<T>(List<T> currentCons, int index, T[] items)
        {
            if (index < 0) return currentCons;

            return ConsRec(new List<T>(Cons.Of(items[index], currentCons)), index - 1, items);
        }
    }
    
    public class List<T>
    {
        private readonly Cons<T, List<T>> _cons;

        internal List(Cons<T, List<T>> cons) => _cons = cons;

        public T Car => _cons.Car;
        public List<T> Cdr => _cons.Cdr;

        public T ListRef(int index)
        {
            if(index == 0)
                return Car;

            return Cdr.ListRef(index - 1);
        }
    }
}