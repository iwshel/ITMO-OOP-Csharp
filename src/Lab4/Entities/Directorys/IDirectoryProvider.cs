using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

public interface IDirectoryProvider : IFileSystemObject
{
    bool Exist(string path);
    IEnumerable<IFileSystemObject> GetContents();
    CreateResult CreateFile(string name);
    CreateResult CreateDirectory(string name);
    void Delete();
}