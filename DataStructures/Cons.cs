namespace DataStructures
{
    public static class Cons
    {
        public static Cons<TAddress,TDecrement> Of<TAddress,TDecrement>(TAddress address, TDecrement decrement) => new Cons<TAddress,TDecrement>(address, decrement);
    }
    
    public class Cons<TAddress,TDecrement>
    {
        internal Cons(TAddress address, TDecrement decrement)
        {
            Car = address;
            Cdr = decrement;
        }

        public TAddress Car { get; }

        public TDecrement Cdr { get; }
    }
}