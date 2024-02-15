using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativeLengthException : Exception
{
    public NegativeLengthException(string message)
        : base(message)
    {
    }

    public NegativeLengthException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeLengthException()
    {
    }
}