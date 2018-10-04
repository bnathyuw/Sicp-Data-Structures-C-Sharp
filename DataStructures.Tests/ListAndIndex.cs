namespace DataStructures.Tests
{
    public class ListAndIndex
    {
        public ListAndIndex(List<object> list, int index)
        {
            List = list;
            Index = index;
        }

        public List<object> List { get; }
        public int Index { get; }

        public override string ToString() => $"{nameof(List)}: {List}, {nameof(Index)}: {Index}";
    }
}