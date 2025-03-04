using System;
using System.Collections.Generic;
using Xunit;
using System.IO;

namespace Num.Tests;

public class Range2Tests
{

        /// <summary>
        /// Verifies that the console application correctly displays quarters grouped by range.
        /// </summary>

      [Fact]
        public void GroupedQuarters()
        {
            var testSequence = new List<double> { 0.1, 0.3, 0.6, 0.9 };
            var iterator = new FloatNumberIterator(testSequence);
            var enumerator = iterator.GetEnumerator();
            List<Range> quarters = new List<Range>();

            while (enumerator.MoveNext())
            {
                quarters.Add(new Range(enumerator.Current));
            }

            var groupedQuarters = quarters.GroupBy(q => q.GetHashCode())
                                      .OrderBy(g => g.Key);

            Assert.Equal(4, groupedQuarters.Count());
        }


        /// <summary>
        /// Verifies that the console application throws a <see cref="BadSequenceException"/>
        /// when three consecutive numbers less than or equal to 0.5 are encountered.
        /// </summary>



      [Fact]
        public void ThrowsBadException()
        {
            var testSequence = new List<double> { 0.3, 0.4, 0.2 }; // Three consecutive ≤ 0.5
            var iterator = new FloatNumberIterator(testSequence);
            var enumerator = iterator.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.True(enumerator.MoveNext());
            Assert.Throws<BadSequenceException>(() => enumerator.MoveNext());
        }

        /// <summary>
        /// Verifies that <see cref="Range"/> instances are correctly categorized based on their quarters.
        /// </summary>

        [Fact]
        public void QuarterOrganization()
        {
            var r1 = new Range(0.1); // Quarter 0
            var r2 = new Range(0.3); // Quarter 1
            var r3 = new Range(0.6); // Quarter 2
            var r4 = new Range(0.9); // Quarter 3

            Assert.NotEqual(r1, r2);
            Assert.NotEqual(r2, r3);
            Assert.NotEqual(r3, r4);
        }

}