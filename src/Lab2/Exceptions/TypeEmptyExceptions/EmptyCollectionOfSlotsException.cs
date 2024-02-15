using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeEmptyExceptions;

public class EmptyCollectionOfSlotsException : Exception
{
    public EmptyCollectionOfSlotsException(string message)
        : base(message)
    {
    }

    public EmptyCollectionOfSlotsException()
    {
    }

    public EmptyCollectionOfSlotsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}