using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directorys;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers.TreeHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandProcessor
{
    public void Main()
    {
        var workingDirectory = new WorkingDirectory();
        var baseHandler = new BaseHandler();
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
        baseHandler.SetNextHandler(connecttemp);

        while (true)
        {
            string? temp = Console.ReadLine();
            if (temp is null) continue;
            IList<string> command = temp.Split(' ').ToList();
            baseHandler.Handle(command, workingDirectory);
        }
    }
}