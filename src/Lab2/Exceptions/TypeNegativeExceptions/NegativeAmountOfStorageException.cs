using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeAmountOfStorageException : Exception
{
    public NegativeAmountOfStorageException(string message)
        : base(message)
    {
    }

    public NegativeAmountOfStorageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeAmountOfStorageException()
    {
    }
}