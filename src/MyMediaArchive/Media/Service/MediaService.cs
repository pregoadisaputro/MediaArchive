using MyMediaArchive.Data.Entity;
using MyMediaArchive.Media.Shared;

namespace MyMediaArchive.Media.Service;

public sealed class MediaService
{
    private readonly string _filePath = FilePath.filePath;
    private readonly List<MediaItem> mediaItems;

    public MediaService()
    {
        mediaItems = JsonService.LoadData<List<MediaItem>>(_filePath) ?? [];
    }

    public void CreateMedia(MediaItem item)
    {
        if (item == null)
            return;

        mediaItems.Add(item);
        Save();
    }

    public bool DeleteMedia(MediaItem item)
    {
        if (item == null)
            return false;

        mediaItems.Remove(item);
        Save();

        return true;
    }

    private void Save()
    {
        JsonService.SaveData(mediaItems, _filePath);
    }
}
