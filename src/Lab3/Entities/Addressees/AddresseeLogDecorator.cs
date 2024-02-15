using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeLogDecorator : IAddressee
{
    private readonly IAddressee _addressee;

    public AddresseeLogDecorator(IAddressee addressee)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    private ILogger Logger { get; set; } = new Logger();

    public void ReceiveMessage(Message message)
    {
        _addressee.ReceiveMessage(message);

        if (Logger.LogStatus)
        {
            Logger.Log(message);
        }
    }

    public void EnableLogger()
    {
        Logger.LogStatus = true;
    }

    public void DisableLogger()
    {
        Logger.LogStatus = false;
    }

    public void SetNewLogger(ILogger logger)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}