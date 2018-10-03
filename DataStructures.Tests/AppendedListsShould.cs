using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    [Properties(Arbitrary=new[]{typeof(GenerateArbitrary)})]
    public class AppendedListsShould
    {
        [Property]
        public void HaveLengthOfBothInputArraysCombined(List<object> list1, List<object> list2) => 
            list1.Append(list2).Length
                .Should().Be(list1.Length + list2.Length);
       
        [Property]
        public void HaveSameFirstItemAsFirstInputArray(NonEmptyList<object> list1, List<object> list2) => 
            list1.Append(list2).ListRef(0)
                .Should().Be(list1.ListRef(0));
        
        [Property]
        public void ContainLastItemOfFirstInputArray(NonEmptyList<object> list1, List<object> list2) => 
            list1.Append(list2).ListRef(list1.Length - 1)
                .Should().Be(list1.ListRef(list1.Length - 1));

        [Property]
        public void ContainFirstItemOfSecondInputArray(List<object> list1, NonEmptyList<object> list2) =>
            list1.Append(list2).ListRef(list1.Length)
                .Should().Be(list2.ListRef(0));

        [Property]
        public void HaveSameLastItemAsSecondInputArray(List<object> list1, NonEmptyList<object> list2) =>
            list1.Append(list2).ListRef(list1.Length + list2.Length - 1)
                .Should().Be(list2.ListRef(list2.Length - 1));
    }
}