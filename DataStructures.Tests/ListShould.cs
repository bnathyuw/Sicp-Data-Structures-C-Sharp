using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class ListShould
    {
        [Property]
        public void OneItem(object item1) => 
            List.Of(item1).Car.Should().Be(item1);

        [Property]
        public void TwoItems(object item1, object item2) => 
            List.Of(item1, item2).Cdr.Car.Should().Be(item2);

        [Property]
        public void ThreeItems(object item1, object item2, object item3) => 
            List.Of(item1, item2, item3).Cdr.Cdr.Car.Should().Be(item3);
    }
}