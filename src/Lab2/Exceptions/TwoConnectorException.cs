using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class TwoConnectorException : Exception
{
    public TwoConnectorException(string message)
        : base(message)
    {
    }

    public TwoConnectorException()
    {
    }

    public TwoConnectorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}