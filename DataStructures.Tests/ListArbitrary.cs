using FsCheck;

namespace DataStructures.Tests
{
    public static class ListArbitrary
    {
        public static Arbitrary<List<object>> Instance =>
            Arb.Default.Array<object>().Generator.Select(List.Of).ToArbitrary();
    }
}