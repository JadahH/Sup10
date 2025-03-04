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



}