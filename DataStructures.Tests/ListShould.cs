using System;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class ListShould
    {
        [Property]
        public void ExposeFirstItem(NonEmptyArray<object> items) =>
            List.Of(items.Get).ListRef(0).Should().Be(items.Get[0]);
        
        [Property]
        public void ExposeLastItem(NonEmptyArray<object> items)
        {
            var lastItemIndex = items.Get.Length - 1;
            List.Of(items.Get).ListRef(lastItemIndex).Should().Be(items.Get[lastItemIndex]);
        }

        [Property]
        public void ExposeLength(object[] items) =>
            List.Of(items).Length().Should().Be(items.Length);

        [Property]
        public void Append(object[] items1, object[] items2) => 
            List.Of(items1).Append(List.Of(items2)).Length().Should().Be(items1.Length + items2.Length);

        [Property]
        public void MapLength(int[] items, Func<int, int> proc) => 
            List.Of(items).Map(proc).Length().Should().Be(items.Length);

        [Property]
        public void MapCar(NonEmptyArray<int> items, Func<int, int> proc) =>
            List.Of(items.Get).Map(proc).ListRef(0).Should().Be(proc(items.Get[0]));
    }
}