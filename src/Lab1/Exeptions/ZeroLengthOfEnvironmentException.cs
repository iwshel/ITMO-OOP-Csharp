using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exeptions;

public class ZeroLengthOfEnvironmentException : Exception
{
    public ZeroLengthOfEnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ZeroLengthOfEnvironmentException() { }

    public ZeroLengthOfEnvironmentException(string message)
        : base(message)
    {
    }
}