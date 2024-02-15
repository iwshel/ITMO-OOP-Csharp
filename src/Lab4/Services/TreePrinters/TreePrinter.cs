using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TreeVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreePrinters;

public class TreePrinter : ITreePrinter
{
    public TreePrinter(ITreeVisitor visitor, IDirectoryProvider directoryProvider)
    {
        Visitor = visitor;
        DirectoryProvider = directoryProvider;
    }

    public IDirectoryProvider DirectoryProvider { get; }
    public ITreeVisitor Visitor { get; }

    public string PrintTree(int maxDepth, string indentForDirectory, string indentForFile)
    {
        Visitor.VisitDirectory(
            DirectoryProvider,
            0,
            maxDepth,
            indentForDirectory,
            indentForFile);

        return Visitor.Result;
    }

    public string PrintTree(string indentForDirectory, string indentForFile)
    {
        Visitor.VisitDirectory(
            DirectoryProvider,
            0,
            1,
            indentForDirectory,
            indentForFile);

        return Visitor.Result;
    }
}