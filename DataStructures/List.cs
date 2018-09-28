namespace DataStructures
{
    public class List
    {
        public static List Of(params object[] items) => new List(ConsRec(null, items.Length - 1, items));

        private readonly Cons _cons;

        private List(Cons cons) => _cons = cons;

        public object Car => _cons.Car;
        public List Cdr => new List((Cons) _cons.Cdr);

        private static Cons ConsRec(Cons currentCons, int index, object[] items)
        {
            if (index < 0) return currentCons;

            return ConsRec(Cons.Of(items[index], currentCons), index - 1, items);
        }
    }
}