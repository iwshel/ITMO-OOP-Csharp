using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotRootedPathException : Exception
{
    public NotRootedPathException(string message)
        : base(message)
    {
    }

    public NotRootedPathException()
    {
    }

    public NotRootedPathException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}