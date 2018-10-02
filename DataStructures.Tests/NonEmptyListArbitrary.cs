using FsCheck;

namespace DataStructures.Tests
{
    public static class NonEmptyListArbitrary
    {
        public static Arbitrary<List<object>> Instance =>
            Arb.Default.NonEmptyArray<object>().Generator.Select(x => x.Get).Select(List.Of).ToArbitrary();
    }
}