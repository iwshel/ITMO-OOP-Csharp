using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class AlreadyReadedMessageException : Exception
{
    public AlreadyReadedMessageException(string message)
        : base(message)
    {
    }

    public AlreadyReadedMessageException()
    {
    }

    public AlreadyReadedMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}