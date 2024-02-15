using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class UnexpectedCommandException : Exception
{
    public UnexpectedCommandException(string message)
        : base(message)
    {
    }

    public UnexpectedCommandException()
    {
    }

    public UnexpectedCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}