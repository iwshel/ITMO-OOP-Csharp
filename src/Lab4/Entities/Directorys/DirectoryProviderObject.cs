using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

public class DirectoryProviderObject : IDirectoryProvider
{
    public DirectoryProviderObject(string pathName)
    {
        PathName = pathName;
        CreatedAt = DateTime.Now;
    }

    public DirectoryProviderObject(string pathName, DateTime createdAt)
    {
        PathName = pathName;
        CreatedAt = createdAt;
    }

    public string PathName { get; }
    public DateTime CreatedAt { get; }
    public DateTime LastModifiedAt { get; private set; }

    public bool Exist(string path)
    {
        return Path.Exists(path);
    }

    public IEnumerable<IFileSystemObject> GetContents()
    {
        var contents = new List<IFileSystemObject>();
        foreach (string path in Directory.GetFileSystemEntries(PathName))
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                DateTime dt = Directory.GetCreationTime(path);

                contents.Add(new DirectoryProviderObject(path, dt));
            }
            else
            {
                DateTime dt = File.GetCreationTime(path);

                contents.Add(new FileProviderObject(path, dt));
            }
        }

        return contents;
    }

    public CreateResult CreateFile(string name)
    {
        string filePath = Path.Combine(PathName, name);

        if (!File.Exists(filePath))
        {
            File.Create(Path.Combine(PathName, name)).Close();
            LastModifiedAt = DateTime.Now;
            return new CreateResult.CreateSuccess();
        }

        return new CreateResult.CreateFail();
    }

    public CreateResult CreateDirectory(string name)
    {
        string directoryPath = Path.Combine(PathName, name);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(Path.Combine(PathName, name));
            LastModifiedAt = DateTime.Now;
            return new CreateResult.CreateSuccess();
        }

        return new CreateResult.CreateFail();
    }

    public void Delete()
    {
        Directory.Delete(PathName, true);
    }
}