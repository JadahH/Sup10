using System;
using Xunit;

namespace Num.Tests;

public class RangeTests
{

    /// <summary>
        /// Verifies that the iterator throws a <see cref="BadException"/> when three consecutive numbers 
        /// less than or equal to 0.5 are encountered in the sequence.
        /// </summary>
        /// 
        
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
        
        [Fact]
        public void Operator()
        {
            // Arrange: Create Range objects in increasing quarter order.
            var r1 = new Range(0.1); 
            var r2 = new Range(0.3); 
            var r3 = new Range(0.6); 
            var r4 = new Range(0.9); 

            // Act & Assert:
            Assert.True(r1 < r2);
            Assert.True(r2 < r3);
            Assert.True(r3 < r4);
            Assert.True(r4 > r1);
            Assert.True(r2 <= r2);
            Assert.True(r3 >= r3);
            Assert.True(r1 != r2);
        }
    



}