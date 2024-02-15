using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileAlreadyExistsException : Exception
{
    public FileAlreadyExistsException(string message)
        : base(message)
    {
    }

    public FileAlreadyExistsException()
    {
    }

    public FileAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}