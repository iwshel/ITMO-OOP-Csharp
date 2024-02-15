using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

public class FileProviderObject : IFileProvider, IEquatable<FileProviderObject>
{
    public FileProviderObject()
    {
        PathName = string.Empty;
    }

    public FileProviderObject(string pathName)
    {
        PathName = pathName;
        CreatedAt = DateTime.Now;
    }

    public FileProviderObject(string pathName, DateTime createdAt)
    {
        PathName = pathName;
        CreatedAt = createdAt;
    }

    public string PathName { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime LastModifiedAt { get; private set; }

    public long Size
    {
        get
        {
            var fileInfo = new FileInfo(PathName);
            return fileInfo.Length;
        }
    }

    public void ChangePath(string path)
    {
        if (Path.Exists(path))
        {
            PathName = path;
        }
    }

    public string Read()
    {
        return File.ReadAllText(PathName);
    }

    public byte[] ReadBinary()
    {
        return File.ReadAllBytes(PathName);
    }

    public void Delete()
    {
        File.Delete(PathName);
    }

    public CreateResult Move(string destinationPath)
    {
        int lastSlashIndex = PathName.LastIndexOf('/');
        string trimmedPath = PathName[(lastSlashIndex + 1)..];

        if (!File.Exists(Path.Combine(destinationPath, trimmedPath)))
        {
            File.Move(PathName, Path.Combine(destinationPath, trimmedPath));
            return new CreateResult.CreateSuccess();
        }

        return new CreateResult.CreateFail();
    }

    public CreateResult Copy(string destinationPath)
    {
        int lastSlashIndex = PathName.LastIndexOf('/');
        string trimmedPath = PathName[(lastSlashIndex + 1)..];

        if (!File.Exists(Path.Combine(destinationPath, trimmedPath)))
        {
            File.Copy(PathName, Path.Combine(destinationPath, trimmedPath));
            return new CreateResult.CreateSuccess();
        }

        return new CreateResult.CreateFail();
    }

    public void Rename(string name)
    {
        string temp = Path.GetExtension(PathName);
        int lastSlashIndex = PathName.LastIndexOf('/');
        string trimmedPath = PathName[..lastSlashIndex];
        File.Move(PathName, Path.Combine(trimmedPath, name + temp));
    }

    public bool Equals(FileProviderObject? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return PathName == other.PathName;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileProviderObject)obj);
    }

    public override int GetHashCode()
    {
        return PathName.GetHashCode(StringComparison.Ordinal);
    }
}