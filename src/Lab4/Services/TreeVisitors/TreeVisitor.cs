using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreeVisitors;

public class TreeVisitor : ITreeVisitor
{
    public string Result { get; private set; } = string.Empty;

    public void VisitDirectory(
        IDirectoryProvider directoryProvider,
        int currentDepth,
        int maxDepth,
        string indentForDirectory,
        string indentForFile)
    {
        directoryProvider = directoryProvider ?? throw new ArgumentNullException(nameof(directoryProvider));

        if (Path.Exists(directoryProvider.PathName))
        {
            Result += $"{indentForDirectory} {directoryProvider.PathName} \n";

            if (currentDepth < maxDepth)
            {
                foreach (string file in Directory.GetFiles(directoryProvider.PathName))
                {
                    VisitFile(file, indentForFile);
                }

                foreach (string subdirectory in Directory.GetDirectories(directoryProvider.PathName))
                {
                    var temp = new DirectoryProviderObject(subdirectory);
                    VisitDirectory(
                        temp,
                        currentDepth + 1,
                        maxDepth,
                        " " + indentForDirectory,
                        "  " + indentForFile);
                }
            }
        }
    }

    public void VisitFile(string file, string indentForFile)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));

        Result += $"{indentForFile} {file} \n";
    }
}