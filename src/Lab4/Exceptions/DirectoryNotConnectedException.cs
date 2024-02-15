using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DirectoryNotConnectedException : Exception
{
    public DirectoryNotConnectedException(string message)
        : base(message)
    {
    }

    public DirectoryNotConnectedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DirectoryNotConnectedException()
    {
    }
}