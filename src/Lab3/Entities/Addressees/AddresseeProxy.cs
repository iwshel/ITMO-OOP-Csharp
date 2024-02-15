using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeProxy : IAddressee
{
    private int _filterLevel;

    public AddresseeProxy(IAddressee recipient)
    {
        Addressee = recipient ?? throw new ArgumentNullException(nameof(recipient));
    }

    private IAddressee Addressee { get; }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        if (message.LevelOfImportance < _filterLevel) return;

        Addressee.ReceiveMessage(message);
    }

    public void ChangeFilterLevel(int newLevel)
    {
        _filterLevel = newLevel is >= 0 and <= 2 ? newLevel : throw new WrongImportanceLevelException(nameof(newLevel));
    }
}