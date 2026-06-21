using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyMediaArchive.Media.Service;

public static class JsonService
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };

    public static void SaveData<T>(T data, string filePath)
    {
        try
        {
            if (data == null || string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            var jsonString = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, jsonString);
        }
        catch (Exception ex)
        {
            throw new IOException($"cannot save the data: {ex}");
        }
    }

    public static T? LoadData<T>(string filePath)
        where T : new()
    {
        try
        {
            if (!File.Exists(filePath) || string.IsNullOrWhiteSpace(filePath))
            {
                return new T();
            }

            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString, _options) ?? new T();
        }
        catch (Exception ex)
        {
            throw new IOException($"cannot load the data: {ex}");
        }
    }
}
