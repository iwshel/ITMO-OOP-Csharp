using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotSupportedModeException : Exception
{
    public NotSupportedModeException(string message)
        : base(message)
    {
    }

    public NotSupportedModeException()
    {
    }

    public NotSupportedModeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}