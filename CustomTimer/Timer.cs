using System;

namespace CustomTimer
{
    public class Timer
    {
        private static DateTime init;
        private static DateTime end;

        public static void Start()
        {
            init = DateTime.UtcNow;
        }

        public static void End()
        {
            end = DateTime.UtcNow;
        }

        public static TimeSpan Duration()
        {
            return end - init;
        }


    }
}
