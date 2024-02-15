using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class Logger : ILogger
{
    public bool LogStatus { get; set; }

    public void Log(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Console.WriteLine(
            $"{DateTime.Now} - Message : {message.Body}, Level : {message.LevelOfImportance}\n");
    }
}