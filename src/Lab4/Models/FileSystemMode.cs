using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class FileSystemMode : IEquatable<FileSystemMode>
{
    public FileSystemMode(string mode)
    {
        Mode = mode;
    }

    private string Mode { get; }

    public bool Equals(FileSystemMode? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Mode == other.Mode;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileSystemMode)obj);
    }

    public override int GetHashCode()
    {
        return Mode.GetHashCode(StringComparison.Ordinal);
    }
}