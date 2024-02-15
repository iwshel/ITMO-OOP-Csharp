namespace Presentation.Console.Exceptions;

public class WrongAdminPasswordException : Exception
{
    public WrongAdminPasswordException(string message)
        : base(message)
    {
    }

    public WrongAdminPasswordException()
    {
    }

    public WrongAdminPasswordException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}