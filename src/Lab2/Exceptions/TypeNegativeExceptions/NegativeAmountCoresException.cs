using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeAmountCoresException : Exception
{
    public NegativeAmountCoresException(string message)
        : base(message)
    {
    }

    public NegativeAmountCoresException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeAmountCoresException()
    {
    }
}