using System;
using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class MappedListShould
    {
        [Property(Arbitrary = new[]{typeof(ListArbitrary)})]
        public void HaveSameLengthAsInputList(List<object> list, Func<object, object> proc) => 
            list.Map(proc).Length
                .Should().Be(list.Length);

        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void MapFirstItemInInputList(List<object> list, Func<object, object> proc) =>
            list.Map(proc).ListRef(0)
                .Should().Be(proc(list.ListRef(0)));

        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void MapListItemInInputList(List<object> list, Func<object, object> proc) =>
            list.Map(proc).ListRef(list.Length - 1)
                .Should().Be(proc(list.ListRef(list.Length - 1)));
    }
}