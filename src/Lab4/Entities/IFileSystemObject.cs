using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFileSystemObject
{
    string PathName { get; }
    DateTime CreatedAt { get; }
    DateTime LastModifiedAt { get; }
}