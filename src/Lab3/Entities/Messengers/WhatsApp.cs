using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class WhatsApp : IWhatsApp
{
    public void Post(string login, string password, string message)
    {
        Console.WriteLine($"[WhatsApp] : {message} \n");
    }
}