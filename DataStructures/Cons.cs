namespace DataStructures
{
    public static class Cons
    {
        public static Cons<TA,TD> Of<TA,TD>(TA address, TD decrement) => new Cons<TA,TD>(address, decrement);
    }
    
    public class Cons<TA,TD>
    {
        internal Cons(TA address, TD decrement)
        {
            Car = address;
            Cdr = decrement;
        }

        public TA Car { get; }

        public TD Cdr { get; }

        public override string ToString() => $"({Car}:{Cdr})";
    }
}