using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public string Name { get; }
    private IAddressee Addressee { get; }

    public void SendMessage(Message message)
    {
        Addressee.ReceiveMessage(message);
    }
}