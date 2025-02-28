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