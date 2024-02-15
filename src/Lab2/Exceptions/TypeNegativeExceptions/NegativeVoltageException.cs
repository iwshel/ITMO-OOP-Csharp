using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeVoltageException : Exception
{
    public NegativeVoltageException(string message)
        : base(message)
    {
    }

    public NegativeVoltageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeVoltageException()
    {
    }
}