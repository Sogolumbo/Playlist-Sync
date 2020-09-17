using System;

namespace PlaylistSyncGUI
{
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength, bool withPoints)
        {
            if (withPoints)
            {
                if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
                {
                    return value;
                }
                else
                {
                    string points = "...".Substring(0, Math.Min(maxLength / 4, 3));
                    return value.Substring(0, maxLength - points.Length) + points;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(value)) return value;
                return value.Substring(0, Math.Min(value.Length, maxLength));
            }
        }
    }
}
