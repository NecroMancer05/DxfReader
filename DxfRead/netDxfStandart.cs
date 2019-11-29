using netDxf;
using System;
using System.IO;

namespace DxfRead
{
    public class netDxfStandart
    {
        public static void Read(string path)
        {
            bool a;
            Console.WriteLine("Dxf Version: " + DxfDocument.CheckDxfFileVersion(path, out a) + " Size: " + new FileInfo(path).Length / (1024 * 1024) + "mb");
            DxfDocument document = null;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                document = DxfDocument.Load(path);

                sw.Stop();
            }
            catch (Exception e)
            {
                sw.Stop();
                Console.WriteLine("Catch on: netDxf.Standart " + e.Message);
            }

            Console.WriteLine("Total time: " + sw.Elapsed);

            if (document == null)
                Console.WriteLine("Document is null!");
            else
                Console.WriteLine("Document is OK!");

            Console.WriteLine();
        }
    }
}
