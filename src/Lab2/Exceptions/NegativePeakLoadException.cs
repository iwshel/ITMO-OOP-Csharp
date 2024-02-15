using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativePeakLoadException : Exception
{
    public NegativePeakLoadException(string message)
        : base(message)
    {
    }

    public NegativePeakLoadException()
    {
    }

    public NegativePeakLoadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}