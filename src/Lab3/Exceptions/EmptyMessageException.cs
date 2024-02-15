using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class EmptyMessageException : Exception
{
    public EmptyMessageException(string message)
        : base(message)
    {
    }

    public EmptyMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyMessageException()
    {
    }
}