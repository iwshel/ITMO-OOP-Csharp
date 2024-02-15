using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class EmptyCommandException : Exception
{
    public EmptyCommandException(string message)
        : base(message)
    {
    }

    public EmptyCommandException()
    {
    }

    public EmptyCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}