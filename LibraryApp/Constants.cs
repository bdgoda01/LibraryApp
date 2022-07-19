using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    static class Constants
    {
        public static bool runProgram = true;
        public static bool runMenu = true;

        private static int _shortPauseLength = 1500;
        private static int _mediumPauseLength = 3000;
        private static int _longPauseLength = 5000;

        public static void ShortPause()
        {
            Thread.Sleep(_shortPauseLength);
        }
        public static void MediumPause()
        {
            Thread.Sleep(_mediumPauseLength);
        }
        public static void LongPause()
        {
            Thread.Sleep(_longPauseLength);
        }
    }
}
