using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class ListFromArrayShould
    {
        [Property]
        public void HaveSameFirstItemAsInputArray(NonEmptyArray<object> items) =>
            List.Of(items.Get).ListRef(0)
                .Should().Be(items.Get[0]);

        [Property]
        public void HaveSameLastItemAsInputArray(NonEmptyArray<object> items) =>
            List.Of(items.Get).ListRef(items.Get.Length - 1)
                .Should().Be(items.Get[items.Get.Length - 1]);

        [Property]
        public void HaveSameLengthAsInputArray(object[] items) =>
            List.Of(items).Length
                .Should().Be(items.Length);
    }
}