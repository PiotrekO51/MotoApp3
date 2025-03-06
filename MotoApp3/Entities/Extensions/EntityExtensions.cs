

using System.Text.Json;

namespace MotoApp3.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : class, IEntity, new()
    {
        var jason = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(jason);
    }
}
