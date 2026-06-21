using MyMediaArchive.Data.Entity;
using MyMediaArchive.Data.Enum;
using MyMediaArchive.Media.Components;
using MyMediaArchive.Media.Service;

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

    public IReadOnlyList<MediaItem> SeeMediaByType(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return [];

        var mediaItem = _mediaService
            .GetAll()
            .Where(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            .OrderBy(i => i.Title)
            .ToList()
            .AsReadOnly();

        RenderTable.Table(mediaItem, $"Media by {title}");

        return mediaItem;
    }

    public IReadOnlyList<MediaItem> SeeMediaByStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            return [];

        if (!Enum.TryParse<MediStatus>(status, true, out var updatedStatus))
            return [];

        var mediaItem = _mediaService
            .GetAll()
            .Where(i => i.Status == updatedStatus)
            .OrderBy(i => i.UpdatedAt)
            .ToList()
            .AsReadOnly();

        RenderTable.Table(mediaItem, $"Media by {status}");

        return mediaItem;
    }
}
