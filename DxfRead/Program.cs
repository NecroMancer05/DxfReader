using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxfRead
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //var test = @"C:\Users\Bekircan\Desktop\test.dxf";
            var testR12 = @"C:\Users\Bekircan\Desktop\r12.dxf";
            var path25mb = @"C:\Users\Bekircan\Desktop\AT\dxf\ATAKÖY.dxf";
            var path50mb = @"C:\Users\Bekircan\Desktop\AT\dxf\OVAYURT.dxf";
            var path850mb = @"C:\Users\Bekircan\Desktop\AKYURT_TUM_VERI.dxf";

            //netDxfStandart.Read(test);
            netDxfStandart.Read(testR12);
            //netDxfStandart.Read(path25mb);
            //netDxfStandart.Read(path50mb);
            //netDxfStandart.Read(path850mb);

            //xMillia.Read(path25mb);
            //xMillia.Read(path50mb);
            //xMillia.Read(path850mb);

            Console.ReadKey();
        }
    }
}
