namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class IndentSelecter
{
    public string GetEmoji(string emojiName)
    {
        return emojiName switch
        {
            "file" => "📄",
            "folder" => "📁",
            "arrow_right" => "➡️",
            "arrow_down" => "⬇️",
            _ => string.Empty,
        };
    }
}