using MyMediaArchive.Data.Entity;
using MyMediaArchive.Data.Enum;
using MyMediaArchive.Media.Components;
using MyMediaArchive.Media.Service;
using Spectre.Console;

namespace MyMediaArchive.Media.View.Service;

public sealed class MenuQueryService
{
    private readonly MediaService _mediaService;

    public MenuQueryService(MediaService mediaService) => _mediaService = mediaService;

    public IReadOnlyList<MediaItem> SeeAllMedia()
    {
        var mediaItem = _mediaService
            .GetAll()
            .OrderByDescending(i => i.CreatedAt)
            .ToList()
            .AsReadOnly();

        RenderTable.Table(mediaItem, "All Media");

        return mediaItem;
    }

    public IReadOnlyList<MediaItem> SeeMediaByType()
    {
        AnsiConsole.Clear();

        var type = AnsiConsole.Ask<string>("Enter the Type:");

        if (!Enum.TryParse<MediaType>(type, true, out var value))
        {
            return [];
        }

        var mediaItem = _mediaService
            .GetAll()
            .Where(i => i.Type == value)
            .OrderBy(i => i.Type)
            .ToList()
            .AsReadOnly();

        RenderTable.Table(mediaItem, $"Media by {type}");

        return mediaItem;
    }

    public IReadOnlyList<MediaItem> SeeMediaByStatus()
    {
        AnsiConsole.Clear();

        var status = AnsiConsole.Ask<string>("Enter the Status:");

        if (!Enum.TryParse<MediStatus>(status, true, out var value))
            return [];

        var mediaItem = _mediaService
            .GetAll()
            .Where(i => i.Status == value)
            .OrderBy(i => i.Status)
            .ToList()
            .AsReadOnly();

        RenderTable.Table(mediaItem, $"Media by {status}");

        return mediaItem;
    }
}
