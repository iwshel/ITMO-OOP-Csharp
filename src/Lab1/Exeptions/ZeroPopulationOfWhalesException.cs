using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exeptions;

public class ZeroPopulationOfWhalesException : Exception
{
    public ZeroPopulationOfWhalesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ZeroPopulationOfWhalesException() { }

    public ZeroPopulationOfWhalesException(string message)
        : base(message)
    {
    }
}