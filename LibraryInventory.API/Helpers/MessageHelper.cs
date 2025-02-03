using System.Runtime.CompilerServices;

namespace LibraryInventory.API.Extensions
{
    public static class MessageHelper<T>
    {
        public static string ObjectNull()
        {
            return $"{typeof(T)} object is null";
        }
        public static string NotFound(string Id, [CallerMemberName] string memberName = "")
        {
            return $"{memberName}: {typeof(T)}Id ({Id}) was not found";
        }
        public static string MismatchIds( string Id, string? resourceId, [CallerMemberName] string memberName = "")
        {
            if (resourceId == null)
            {
                return $"{memberName}: {typeof(T)}Id in resource object is null";
            }

            return $"{memberName}: query param ({Id}) does not match {typeof(T)}Id in resource object ({resourceId})";
        }
        public static string Success([CallerMemberName] string memberName = "")
        {
            return $"{memberName}: Success";
        }
    }
}
