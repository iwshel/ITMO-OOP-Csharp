using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

public class WorkingDirectory
{
    public IDirectoryProvider? Directory { get; private set; }
    public IFileProvider? File { get; private set; }

    public void SetNewDirectory(IDirectoryProvider? directory)
    {
        Directory = directory;
    }

    public void SetNewFilePath(string path)
    {
        File?.ChangePath(path);
    }

    public void SetNewFile(IFileProvider fileProvider)
    {
        File = fileProvider;
    }

    public string GetPath()
    {
        if (Directory is not null)
        {
            return Directory.PathName;
        }

        return string.Empty;
    }
}