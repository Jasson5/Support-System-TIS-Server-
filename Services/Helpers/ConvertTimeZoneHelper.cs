using System;
using System.Runtime.InteropServices;

namespace Services.Helpers
{
    public static class ConvertTimeZoneHelper
    {
        public static DateTime ConvertSaWesternStandardTime(DateTime dateTime)
        {
            TimeZoneInfo saWesternStandardTime = null;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                saWesternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                saWesternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("America/La_Paz");
            }

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, saWesternStandardTime);
        }
    }
}
