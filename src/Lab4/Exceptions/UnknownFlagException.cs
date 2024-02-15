using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class UnknownFlagException : Exception
{
    public UnknownFlagException(string message)
        : base(message)
    {
    }

    public UnknownFlagException()
    {
    }

    public UnknownFlagException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}