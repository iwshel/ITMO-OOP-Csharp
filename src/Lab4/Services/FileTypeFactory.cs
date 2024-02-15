using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileTypeFactory
{
    public IFileProvider CreateFile(string mode)
    {
        switch (mode)
        {
            case "local":
                return new FileProviderObject();
            default:
                throw new NotSupportedModeException();
        }
    }
}