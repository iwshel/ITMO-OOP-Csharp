using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class ReadableMessage : Message
{
    public ReadableMessage(string title, string body, int levelOfImportance)
        : base(title, body, levelOfImportance)
    {
        IsRead = false;
    }

    public bool IsRead { get; private set; }

    public void SetReaded()
    {
        if (!IsRead)
        {
            IsRead = true;
        }
        else
        {
            throw new AlreadyReadedMessageException();
        }
    }
}