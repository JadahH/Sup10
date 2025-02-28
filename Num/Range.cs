namespace Num;


public class BadSequenceException : Exception
    {
        public BadSequenceException() { }
        public BadSequenceException(string message) : base(message) { }
        public BadSequenceException(string message, Exception innerException) : base(message, innerException) { }

    }
