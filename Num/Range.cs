using System.Collections;
using System.Collections.Generic;

namespace Num;

/// <summary>
    /// Represents an exception thrown when an invalid sequence is generated.
    /// Specifically, this exception is thrown when three consecutive numbers are less than or equal to 0.5.
    /// </summary>

public class BadSequenceException : Exception
    {
       /// <summary>
        /// Initializes a new instance of the <see cref="BadSequenceException"/> class.
        /// </summary>  
        public BadSequenceException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadSequenceException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// 

        public BadSequenceException(string message) : base(message) { }

         /// <summary>
        /// Initializes a new instance of the <see cref="BadSequenceException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BadSequenceException(string message, Exception innerException) : base(message, innerException) { }

    }

/// <summary>
    /// Provides an enumerable sequence of floating-point numbers in the range [0.0, 1.0).
    /// When three consecutive numbers are less than or equal to 0.5, a <see cref="BadSequenceException"/> is thrown.
    /// </summary>
    /// 

     public class FloatNumberIterator : IEnumerable<double>
    {
        private readonly IEnumerator<double> _customSequence;
        private readonly Random _random;
        private readonly bool _useCustomSequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatNumberIterator"/> class.
        /// If a custom sequence is provided, it will be used for enumeration; otherwise, random numbers are generated.
        /// </summary>
        /// <param name="customSequence">An optional sequence of double values for testing purposes.</param>

        public FloatNumberIterator(IEnumerable<double> customSequence = null)
        {
            if (customSequence != null)
            {
                _customSequence = customSequence.GetEnumerator();
                _useCustomSequence = true;
            }
            else
            {
                _random = new Random();
                _useCustomSequence = false;
            }
        }


         /// <summary>
        /// Returns an enumerator that iterates through a sequence of double values.
        /// </summary>
        /// <returns>An enumerator for the floating-point numbers.</returns>
        /// <exception cref="BadSequenceException">
        /// Thrown when three consecutive numbers generated are less than or equal to 0.5.
        /// </exception>

        
        public IEnumerator<double> GetEnumerator()
        {
            int consecutiveLow = 0;
            while (true)
            {
                double number;
                if (_useCustomSequence)
                {
                    if (!_customSequence.MoveNext())
                        yield break; // End of the provided sequence.
                    number = _customSequence.Current;
                }
                else
                {
                    number = _random.NextDouble();
                }

                if (number <= 0.5)
                    consecutiveLow++;
                else
                    consecutiveLow = 0;

                if (consecutiveLow == 3)
                    throw new BadSequenceException("Three consecutive numbers are <= 0.5.");

                yield return number;
            }
        }

         /// <summary>
        /// Returns a non-generic enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object for the collection.</returns>

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    /// <summary>
    /// Represents a value in the range [0.0, 1.0] and categorizes it into one of four quarters.
    /// Two <see cref="Range"/> objects are considered equal if they fall into the same quarter:
    /// [0.0, 0.25), [0.25, 0.5), [0.5, 0.75), or [0.75, 1.0].
    /// </summary>

    public class Range
    {
      
        public double Value { get; }

     
        public Range(double value)
        {
            if (value < 0.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0.0 and 1.0.");
            Value = value;
        }

         private int QuarterIndex => (Value < 0.25) ? 0 : (Value < 0.5) ? 1 : (Value < 0.75) ? 2 : 3;

// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Range"/> instance.
        /// Two ranges are considered equal if they fall into the same quarter.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// true if the specified object is a <see cref="Range"/> and falls into the same quarter as the current instance; otherwise, false.
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj is Range other)
                return this.QuarterIndex == other.QuarterIndex;
            return false;
        }

/// <summary>
        /// Determines whether two <see cref="Range"/> instances are equal,
        /// i.e., whether they fall into the same quarter.
        /// </summary>
        /// <param name="a">The first <see cref="Range"/> instance.</param>
        /// <param name="b">The second <see cref="Range"/> instance.</param>
        /// <returns>true if both instances are in the same quarter; otherwise, false.</returns>

        public override int GetHashCode() => QuarterIndex.GetHashCode();

        public static bool operator ==(Range a, Range b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            return a.QuarterIndex == b.QuarterIndex;
        }

        public static bool operator !=(Range a, Range b) => !(a == b);
        

         public static bool operator <(Range a, Range b)
        {
            if (a is null || b is null)
                throw new ArgumentNullException();
            return a.QuarterIndex < b.QuarterIndex;
        }

        public static bool operator >(Range a, Range b)
        {
            if (a is null || b is null)
                throw new ArgumentNullException();
            return a.QuarterIndex > b.QuarterIndex;
        }

        public static bool operator <=(Range a, Range b) => a == b || a < b;

        public static bool operator >=(Range a, Range b) => a == b || a > b;
    }
    