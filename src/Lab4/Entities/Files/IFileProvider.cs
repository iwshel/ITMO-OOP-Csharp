using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public interface IFileProvider : IFileSystemObject
{
    long Size { get; }
    void ChangePath(string path);
    string Read();
    byte[] ReadBinary();
    void Delete();
    CreateResult Move(string destinationPath);
    CreateResult Copy(string destinationPath);
    void Rename(string name);
}