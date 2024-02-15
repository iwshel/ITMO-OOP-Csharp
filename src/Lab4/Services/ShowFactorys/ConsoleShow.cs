using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ShowFactorys;

public class ConsoleShow : IShow
{
    public void Show(string text)
    {
        Console.WriteLine(text);
    }

    public void ShowBinary(byte[] content)
    {
        Console.WriteLine(content);
    }
}