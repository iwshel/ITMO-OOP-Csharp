using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeFrequencyException : Exception
{
    public NegativeFrequencyException(string message)
        : base(message)
    {
    }

    public NegativeFrequencyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeFrequencyException()
    {
    }
}