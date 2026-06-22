using MyMediaArchive.Data.Enum;

namespace MyMediaArchive.Media.Components;

public static class Color
{
    public static string ColorForType(MediaType type)
    {
        return type switch
        {
            MediaType.Movies => $"[#cdd6f4]🎬 {type}[/]",
            MediaType.Music => $"[#cdd6f4]🎵 {type}[/]",
            MediaType.Games => $"[#cdd6f4]🎮 {type}[/]",
            MediaType.Books => $"[#cdd6f4]📚 {type}[/]",
            MediaType.Anime => $"[#cdd6f4]📺 {type}",
            _ => type.ToString(),
        };
    }

    public static string ColorForStatus(MediStatus status)
    {
        return status switch
        {
            MediStatus.Completed => $"[green]{status}[/]",
            MediStatus.Playing => $"[skyblue1]{status}[/]",
            MediStatus.Watching => $"[teal]{status}[/]",
            MediStatus.Reading => $"[gold1]{status}[/]",
            MediStatus.Planned => $"[grey]{status}[/]",
            MediStatus.Dropped => $"[red]{status}[/]",
            _ => status.ToString(),
        };
    }
}
