using System;
using System.IO;
using System.Net;

namespace optechx.DownloadFile
{
    class Program
    {
        static string FileUri = string.Empty;
        static string FileDLPath = string.Empty;

        static void Main(string[] args)
        {
            //string AdobeFileUri = "https://ardownload2.adobe.com/pub/adobe/reader/win/AcrobatDC/2101120039/AcroRdrDC2101120039_MUI.exe";
            //string DLOutPath = "/Users/danijel-rpc/tmp/AcroRdrDC2101120039_MUI.exe";

            if (args.Length > 2 || args.Length < 2)
            {
                Console.WriteLine("Usage: odl <uri> <outpath>");
                Environment.Exit(exitCode: 0);
            }

            FileUri = args[0];
            FileDLPath = args[1];

            // delete file if exists already first
            DeleteFile(FilePath: FileDLPath);

            using (var client = new WebClient())
            {
                client.DownloadFile(FileUri, FileDLPath);
            }

            Console.WriteLine("Check path: {0}", FileDLPath);
        }

        // delete file if exists function
        static void DeleteFile(string FilePath)
        {
            FileInfo file = new FileInfo(FilePath);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
