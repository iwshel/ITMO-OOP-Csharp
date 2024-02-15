using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotEnoughArgumentsException : Exception
{
    public NotEnoughArgumentsException(string message)
        : base(message)
    {
    }

    public NotEnoughArgumentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NotEnoughArgumentsException()
    {
    }
}