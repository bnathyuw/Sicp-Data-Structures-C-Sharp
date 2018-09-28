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

        [Property]
        public void HaveLength(object[] items) =>
            List.Of(items).Length().Should().Be(items.Length);

        [Property]
        public void Append(object[] items1, object[] items2) => 
            List.Of(items1).Append(List.Of(items2)).Length().Should().Be(items1.Length + items2.Length);

        [Property]
        public void MapLength(int[] items, Func<int, int> proc) => 
            List.Of(items).Map(proc).Length().Should().Be(items.Length);

        [Property]
        public void MapCar(NonEmptyArray<int> items, Func<int, int> proc) =>
            List.Of(items.Get).Map(proc).Car.Should().Be(proc(items.Get[0]));
    }
}