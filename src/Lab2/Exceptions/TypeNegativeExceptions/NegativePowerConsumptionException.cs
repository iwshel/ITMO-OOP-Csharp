using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativePowerConsumptionException : Exception
{
    public NegativePowerConsumptionException(string message)
        : base(message)
    {
    }

    public NegativePowerConsumptionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativePowerConsumptionException()
    {
    }
}