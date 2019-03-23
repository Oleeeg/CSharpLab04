using System;
using System.IO;

namespace CSharpLab04
{
    static class StationManager
    {
        internal static readonly string WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSharpLab04");
        public static Person CurrentPerson { get; set; }
    }
}
