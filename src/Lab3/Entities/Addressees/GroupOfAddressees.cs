using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class GroupOfAddressees : IAddressee
{
    public GroupOfAddressees(IList<IAddressee> allAddressees)
    {
        AllAddressees = allAddressees ?? throw new ArgumentNullException(nameof(allAddressees));
    }

    public string Name => "GroupOfAddressees";
    private IList<IAddressee> AllAddressees { get; }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee curAddressee in AllAddressees)
        {
            curAddressee.ReceiveMessage(message);
        }
    }
}