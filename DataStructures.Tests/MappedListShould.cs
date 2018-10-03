using System;
using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    [Properties(Arbitrary=new[]{typeof(GenerateArbitrary)})]
    public class MappedListShould
    {
        [Property]
        public void HaveSameLengthAsInputList(List<object> list, Func<object, object> proc) => 
            list.Map(proc).Length
                .Should().Be(list.Length);

        [Property]
        public void MapFirstItemInInputList(NonEmptyList<object> list, Func<object, object> proc) =>
            list.Map(proc).ListRef(0)
                .Should().Be(proc(list.ListRef(0)));

        [Property]
        public void MapListItemInInputList(NonEmptyList<object> list, Func<object, object> proc) =>
            list.Map(proc).ListRef(list.Length - 1)
                .Should().Be(proc(list.ListRef(list.Length - 1)));
    }
}