using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

public class EmptyVersionException : Exception
{
    public EmptyVersionException(string message)
        : base(message)
    {
    }

    public EmptyVersionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyVersionException()
    {
    }
}