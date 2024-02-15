using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.TreeHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseTests
{
    private readonly WorkingDirectory _workingDirectory = new();
    private readonly BaseHandler _baseHandler = new();

    public ParseTests()
    {
        var connecttemp = new ConnectCommandHandler();
        var disconnect = new DisconnectCommandHandler();
        var treetemp = new TreeHandler();
        var treelist = new TreeListHandler();
        var treegoto = new TreeGotoHandler();
        treelist.SetNextTreeHandler(treegoto);
        treetemp.SetNextTreeHandler(treelist);
        var filetemp = new FileHandler();
        var copy = new FileCopyHandler();
        var delete = new FileDeleteHandler();
        var move = new FileMoveHandler();
        var rename = new FileRenameHandler();
        var show = new FileShowHandler();
        rename.SetNextFileHandler(show);
        move.SetNextFileHandler(rename);
        delete.SetNextFileHandler(move);
        copy.SetNextFileHandler(delete);
        filetemp.SetNextFileHandler(copy);
        treetemp.SetNextHandler(filetemp);
        connecttemp.SetNextHandler(disconnect);
        disconnect.SetNextHandler(treetemp);
        _baseHandler.SetNextHandler(connecttemp);
    }

    [Fact]
    public void TestConnectToLocal()
    {
        // arrange
        IList<string> command = new List<string>() { "connect", "/home/iwshel", "-m", "local" };

        // act
        _baseHandler.Handle(command, _workingDirectory);

        // assert
        Assert.Equal("/home/iwshel", _workingDirectory.Directory?.PathName);
        Assert.Equal(new FileProviderObject(), _workingDirectory.File);
    }

    [Fact]
    public void TestDisconnect()
    {
        // arrange and act
        IList<string> command = new List<string>() { "connect", "/home/iwshel", "-m", "local" };
        _baseHandler.Handle(command, _workingDirectory);
        command = new List<string>() { "disconnect" };

        // act
        _baseHandler.Handle(command, _workingDirectory);

        // assert
        Assert.Null(_workingDirectory.Directory);
    }

    [Fact]
    public void TestNotExistentCommand()
    {
        // arrange
        IList<string> command = new List<string>() { "hi" };

        // act and assert
        Assert.Throws<UnexpectedCommandException>(() => _baseHandler.Handle(command, _workingDirectory));
    }

    [Fact]
    public void TestGoto()
    {
        // arrange and act
        IList<string> command = new List<string>() { "connect", "/home/iwshel", "-m", "local" };
        _baseHandler.Handle(command, _workingDirectory);

        // arrange and act
        command = new List<string>() { "tree", "goto", "/home/iwshel/lol" };
        _baseHandler.Handle(command, _workingDirectory);

        // assert
        Assert.Equal("/home/iwshel/lol", _workingDirectory.Directory?.PathName);
        Assert.Equal(new FileProviderObject(), _workingDirectory.File);
    }

    [Fact]
    public void TestWrongFlag()
    {
        // arrange and act
        IList<string> command = new List<string>() { "connect", "/home/iwshel", "-k", "local" };

        // assert
        Assert.Throws<UnknownFlagException>(() => _baseHandler.Handle(command, _workingDirectory));
    }
}