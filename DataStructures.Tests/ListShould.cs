using System;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class ListShould
    {
        [Property]
        public void ExposeCar(NonEmptyArray<object> items) =>
            List.Of(items.Get).Car.Should().Be(items.Get[0]);

        [Property]
        public void ListRef0(object item1) =>
            List.Of(item1).ListRef(0).Should().Be(item1);

        [Property]
        public void ListRef1(object item1, object item2) => 
            List.Of(item1, item2).ListRef(1).Should().Be(item2);

        [Property]
        public void ListRef2(object item1, object item2, object item3) =>
            List.Of(item1, item2, item3).ListRef(2).Should().Be(item3);
    }
}