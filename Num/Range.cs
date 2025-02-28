using System.Collections;
using System.Collections.Generic;

namespace Num;


public class BadSequenceException : Exception
    {
        public BadSequenceException() { }
        public BadSequenceException(string message) : base(message) { }
        public BadSequenceException(string message, Exception innerException) : base(message, innerException) { }

    }


     public class FloatNumberIterator : IEnumerable<double>
    {
        private readonly IEnumerator<double> _customSequence;
        private readonly Random _random;
        private readonly bool _useCustomSequence;

       
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

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

        public override bool Equals(object obj)
        {
            if (obj is Range other)
                return this.QuarterIndex == other.QuarterIndex;
            return false;
        }

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
    