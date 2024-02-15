using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotIntDephException : Exception
{
    public NotIntDephException(string message)
        : base(message)
    {
    }

    public NotIntDephException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NotIntDephException()
    {
    }
}