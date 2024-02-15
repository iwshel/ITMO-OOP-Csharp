using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;

public class WhatsAppAdapter : IMessenger
{
    private readonly IWhatsApp _whatsApp;

    public WhatsAppAdapter(IWhatsApp whatsApp)
    {
        _whatsApp = whatsApp;
    }

    private IList<Message> NewMessage { get; } = new List<Message>();

    public void ShowMessage()
    {
        foreach (Message message in NewMessage)
        {
            Show(message.Body);
        }
    }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        NewMessage.Add(message);
    }

    private void Show(string message)
    {
        _whatsApp.Post(string.Empty, string.Empty, message);
    }
}