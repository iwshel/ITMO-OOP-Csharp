using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.TypeNegativeExceptions;

public class NegativeTdpException : Exception
{
    public NegativeTdpException(string message)
        : base(message)
    {
    }

    public NegativeTdpException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NegativeTdpException()
    {
    }
}