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
    
    public class RangeTests
    {
        [Fact]
        public void EqualQuarter()
        {
            // Arrange
            var r1 = new Range(0.1);   // Falls in [0.0, 0.25)
            var r2 = new Range(0.2);   // Falls in [0.0, 0.25)
            var r3 = new Range(0.3);   // Falls in [0.25, 0.5)
            
            // Act & Assert
            Assert.True(r1 == r2);
            Assert.False(r1 == r3);
        }
        




}