using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message
{
    public Message(string title, string body, int levelOfImportance)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        body = body ?? throw new ArgumentNullException(nameof(body));
        Body = body.Length != 0 ? body : throw new EmptyMessageException(nameof(body));
        LevelOfImportance = levelOfImportance is >= 0 and <= 2
            ? levelOfImportance
            : throw new WrongImportanceLevelException(nameof(levelOfImportance));
    }

    public string Title { get; }
    public string Body { get; }
    public int LevelOfImportance { get; }
}