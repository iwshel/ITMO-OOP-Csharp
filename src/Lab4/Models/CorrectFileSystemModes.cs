using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class CorrectFileSystemModes
{
    private readonly IList<FileSystemMode> _modes = new List<FileSystemMode>() { new FileSystemMode("local") };

    public bool IsCorrect(FileSystemMode mode)
    {
        return _modes.Contains(mode);
    }
}