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
            Arb.Default.NonEmptyArray<object>()
                .Generator
                .Select(x => x.Get)
                .Select(Tests.NonEmptyList.Of)
                .ToArbitrary();
    }
}