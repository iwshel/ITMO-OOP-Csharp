using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class DisplayAddressee : IAddressee
{
    private Message? NewMessage { get; set; }
    private DisplayDriver Driver { get; } = new DisplayDriver();

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        NewMessage = message;
    }

    public void ShowText()
    {
        Driver.Clear();
        Driver.ShowText(NewMessage);
    }

    public void SetNewColor(byte r, byte g, byte b)
    {
        Driver.SetNewColor(r, g,  b);
    }
}