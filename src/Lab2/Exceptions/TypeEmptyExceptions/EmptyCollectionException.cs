using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

public class EmptyCollectionException : Exception
{
    public EmptyCollectionException(string message)
        : base(message)
    {
    }

    public EmptyCollectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyCollectionException()
    {
    }
}