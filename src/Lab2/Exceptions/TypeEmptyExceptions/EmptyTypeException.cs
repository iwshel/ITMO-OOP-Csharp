using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

public class EmptyTypeException : Exception
{
    public EmptyTypeException(string message)
        : base(message)
    {
    }

    public EmptyTypeException()
    {
    }

    public EmptyTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}