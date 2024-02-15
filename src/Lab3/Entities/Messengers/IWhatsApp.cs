namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface IWhatsApp
{
    void Post(string login, string password, string message);
}