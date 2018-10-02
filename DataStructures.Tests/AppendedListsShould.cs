using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class AppendedListsShould
    {
        [Property(Arbitrary = new[]{typeof(ListArbitrary)})]
        public void HaveLengthOfBothInputArraysCombined(List<object> list1, List<object> list2) => 
            list1.Append(list2).Length
                .Should().Be(list1.Length + list2.Length);
       
        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void HaveSameFirstItemAsFirstInputArray(List<object> list1, List<object> list2) => 
            list1.Append(list2).ListRef(0)
                .Should().Be(list1.ListRef(0));
        
        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void ContainLastItemOfFirstInputArray(List<object> list1, List<object> list2) => 
            list1.Append(list2).ListRef(list1.Length - 1)
                .Should().Be(list1.ListRef(list1.Length - 1));

        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void ContainFirstItemOfSecondInputArray(List<object> list1, List<object> list2) =>
            list1.Append(list2).ListRef(list1.Length)
                .Should().Be(list2.ListRef(0));

        [Property(Arbitrary = new[]{typeof(NonEmptyListArbitrary)})]
        public void HaveSameLastItemAsSecondInputArray(List<object> list1, List<object> list2) =>
            list1.Append(list2).ListRef(list1.Length + list2.Length - 1)
                .Should().Be(list2.ListRef(list2.Length - 1));
    }
}