namespace DataStructures
{
    public class Cons
    {
        public static Cons Of(object address, object decrement) => new Cons(address, decrement);

        private readonly object[] _foo;

        private Cons(object address, object decrement) => _foo = new[] {address, decrement};

        public object Car => _foo[0];
        public object Cdr => _foo[1];
    }
}