using FluentAssertions;
using FsCheck.Xunit;

namespace DataStructures.Tests
{
    public class ConsShould
    {
        [Property]
        public void ExposeCar(object address, object decrement) => 
            Cons.Of(address, decrement).Car.Should().Be(address);

        [Property]
        public void ExposeCdr(object address, object decrement) => 
            Cons.Of(address, decrement).Cdr.Should().Be(decrement);
    }
}