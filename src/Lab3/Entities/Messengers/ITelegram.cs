namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface ITelegram
{
    void SendMessage(string apiKey, long userId, string message);
}