using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DisplayDriver
{
    private Color Color { get; set; } = new Color(0, 0, 0);

    public Message? ShowText(Message? message)
    {
        if (message is not null)
        {
            Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(message.Body));
        }

        return null;
    }

    public void SetNewColor(byte r, byte g, byte b)
    {
        Color = new Color(r, g, b);
    }

    public void Clear()
    {
        Console.Clear();
    }
}