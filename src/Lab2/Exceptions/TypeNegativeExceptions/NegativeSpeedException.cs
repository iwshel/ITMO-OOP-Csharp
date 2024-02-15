using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeSpeedException : Exception
{
    public NegativeSpeedException(string message)
        : base(message)
    {
    }

    public NegativeSpeedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeSpeedException()
    {
    }
}