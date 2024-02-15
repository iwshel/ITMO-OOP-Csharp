using Itmo.ObjectOrientedProgramming.Lab4.Services.TreeVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreePrinters;

public interface ITreePrinter
{
    ITreeVisitor Visitor { get; }
    string PrintTree(int maxDepth, string indentForDirectory, string indentForFile);
    string PrintTree(string indentForDirectory, string indentForFile);
}
