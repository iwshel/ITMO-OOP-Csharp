using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;

public interface IMessenger
{
    void ReceiveMessage(Message message);
    void ShowMessage();
}