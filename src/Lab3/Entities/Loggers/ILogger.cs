using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public interface ILogger
{
    bool LogStatus { get; set; }
    void Log(Message message);
}