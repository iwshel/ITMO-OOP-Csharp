using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class UserAddressee : IAddressee
{
    private readonly IList<ReadableMessage> _receivedMessages = new List<ReadableMessage>();

    public IList<ReadableMessage> GetAllMessages => new List<ReadableMessage>(_receivedMessages);

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        var readableMessage = new ReadableMessage(message.Title, message.Body, message.LevelOfImportance);
        _receivedMessages.Add(readableMessage);
    }

    public void ReadMessage(int index)
    {
        _receivedMessages[index].SetReaded();
    }
}