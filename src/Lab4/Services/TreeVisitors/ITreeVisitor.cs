using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreeVisitors;

public interface ITreeVisitor
{
    string Result { get; }
    void VisitDirectory(IDirectoryProvider directoryProvider, int currentDepth, int maxDepth, string indentForDirectory, string indentForFile);
    void VisitFile(string file, string indentForFile);
}