using FsCheck;

namespace DataStructures.Tests
{
    public static class GenerateArbitrary
    {
        public static Arbitrary<List<object>> List =>
            Arb.Default.Array<object>()
                .Generator
                .Select(DataStructures.List.Of).ToArbitrary();

        public static Arbitrary<NonEmptyList<object>> NonEmptyList =>
            Arb.Generate<object[]>()
                .Where(x => 0 < x.Length)
                .Select(Tests.NonEmptyList.Of)
                .ToArbitrary();

        public static Arbitrary<ListAndIndex> ListAndIndex =>
        (   
            from list in Arb.Generate<object[]>().Select(DataStructures.List.Of)
            from index in Arb.Generate<int>().Where(index => 0 <= index && index <= list.Length)
            select new ListAndIndex(list, index)
        ).ToArbitrary();
    }
}