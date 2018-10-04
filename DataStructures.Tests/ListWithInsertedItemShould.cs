using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    [Properties(Arbitrary = new []{typeof(GenerateArbitrary)})]
    public class ListWithInsertedItemShould
    {
        [Property]
        public void ReturnItemInsertedAtIndex(ListAndIndex listAndIndex, object item) =>
            listAndIndex.List.InsertAt(listAndIndex.Index, item).ListRef(listAndIndex.Index)
                .Should().Be(item);

        [Property]
        public void IncreaseInSizeWhenItemIsInserted(ListAndIndex listAndIndex, object item) =>
            listAndIndex.List.InsertAt(listAndIndex.Index, item).Length
                .Should().Be(listAndIndex.List.Length + 1);
        
        [Property]
        public void ShiftOriginalFirstItemWhenItemIsInsertedAtHead(NonEmptyList<object> list, object item) =>
            list.InsertAt(0, item).ListRef(1)
                .Should().Be(list.ListRef(0));
    }
}