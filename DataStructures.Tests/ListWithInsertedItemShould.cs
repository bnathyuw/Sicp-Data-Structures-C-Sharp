using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    [Properties(Arbitrary = new []{typeof(GenerateArbitrary)})]
    public class ListWithInsertedItemShould
    {
        [Property]
        public void ReturnNewItemInsertedAt0(List<object> list, object item) => 
            list.InsertAt(0, item).ListRef(0)
                .Should().Be(item);

        [Property]
        public void ShiftOriginalFirstItemWhenItemIsInsertedAtHead(NonEmptyList<object> list, object item) =>
            list.InsertAt(0, item).ListRef(1)
                .Should().Be(list.ListRef(0));

        [Property]
        public void ReturnNewItemInsertedAtEnd(List<object> list, object item) =>
            list.InsertAt(list.Length, item).ListRef(list.Length)
                .Should().Be(item);
    }
}