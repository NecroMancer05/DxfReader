using DxfReader;
using System;

namespace ReadConsole
{
    class Program
    {
        public static string FilePath { get; set; } = @"C:\Users\Bekircan\Desktop\test2.dxf";
        public static string FilePathR12 { get; set; } = @"C:\Users\Bekircan\Desktop\AKYURT_TUM_VERI.dxf";
        public static string Atakoy { get; set; } = @"C:\Users\Bekircan\Desktop\AT\dxf\ATAKÖY.dxf";
        public static string OVAYURT { get; set; } = @"C:\Users\Bekircan\Desktop\AT\dxf\OVAYURT.dxf";


        public static string AtakoyNewLine { get; set; } = @"C:\Users\Bekircan\Desktop\AkyurtDxf\AKYURT_TUM-line.dxf";
        public static string AtakoyNewPoint { get; set; } = @"C:\Users\Bekircan\Desktop\AkyurtDxf\AKYURT_TUM-point.dxf";
        public static string AtakoyNewPolygon { get; set; } = @"C:\Users\Bekircan\Desktop\AkyurtDxf\AKYURT_TUM-polygon.dxf";

        public static string TomekTest { get; set; } = @"C:\Users\Bekircan\Desktop\AT\DereceTomek.dxf";

        public static string FullTest { get; set; } = @"C:\Users\Bekircan\Desktop\fullTest.dxf";

        static void Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var dxf = DxfContents.ReadDxf(Atakoy);
            sw.Stop();

            Console.WriteLine("Elapsed time: " + sw.Elapsed);
            Console.ReadKey();
        }
    }
}