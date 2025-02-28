namespace Num.Tests;

public class RangeTests
{
    [Fact]
    public void ThrowsException()
    {
        var testSequence = new List<double> { 0.3, 0.4, 0.2, 0.8 };
         var iterator = new FloatNumb(testSequence);
         var enumerator = iterator.GetEnumerator();

         Assert.True(enumerator.MoveNext());
         Assert.Equal(0.3, enumerator.Current);

         Assert.True(enumerator.MoveNext());
            Assert.Equal(0.4, enumerator.Current);

             Assert.Throws<BadException>(() => enumerator.MoveNext());
    }

            [Fact]
        public void NoException()
        {
            // Arrange: A sequence with intermittent numbers > 0.5.
            var testSequence = new List<double> { 0.4, 0.6, 0.3, 0.7, 0.2, 0.8 };
            var generator = new FloatNumb(testSequence);
            var enumerator = generator.GetEnumerator();

            // Act & Assert:
            Assert.True(enumerator.MoveNext());
            Assert.Equal(0.4, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(0.6, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(0.3, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(0.7, enumerator.Current);
        }
    





}