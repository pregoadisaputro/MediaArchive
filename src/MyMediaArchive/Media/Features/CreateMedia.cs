using MyMediaArchive.Data.Entity;
using MyMediaArchive.Media.Service;
using MyMediaArchive.Media.Shared;

namespace MyMediaArchive.Media.Features;

public sealed class CreateMedia
{
    private readonly string filePath = FilePath.filePath;
    private readonly List<MediaItem> mediaItems;

    public CreateMedia()
    {
        mediaItems = JsonService.LoadData<List<MediaItem>>(filePath) ?? [];
    }

    public void AddMedia(MediaItem item)
    {
        if (item == null)
        {
            return;
        }

        mediaItems.Add(item);
        Save();
    }

    private void Save()
    {
        JsonService.SaveData(mediaItems, filePath);
    }
}
