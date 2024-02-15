using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;

public class TelegramAdapter : IMessenger
{
    private readonly ITelegram _telegram;

    public TelegramAdapter(ITelegram telegram)
    {
        _telegram = telegram;
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
        _telegram.SendMessage(string.Empty, 0, message);
    }
}