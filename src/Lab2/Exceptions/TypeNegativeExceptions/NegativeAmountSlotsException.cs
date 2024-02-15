using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeAmountSlotsException : Exception
{
    public NegativeAmountSlotsException(string message)
        : base(message)
    {
    }

    public NegativeAmountSlotsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeAmountSlotsException()
    {
    }
}