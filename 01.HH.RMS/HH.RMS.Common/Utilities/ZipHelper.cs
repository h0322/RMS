using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Utilities
{
    public class ZipHelper
    {
        public static void addZipEntry(string pathStr, ZipOutputStream zipStream)
        {
            if (!Directory.Exists(pathStr))
            {
                Directory.CreateDirectory(pathStr);
            }
            DirectoryInfo di = new DirectoryInfo(pathStr);
            foreach (DirectoryInfo item in di.GetDirectories())
            {
                addZipEntry(item.FullName, zipStream);
            }
            foreach (FileInfo item in di.GetFiles())
            {
                FileStream fs = System.IO.File.OpenRead(item.FullName);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                string strEntryName = item.Name;
                ZipEntry entry = new ZipEntry(strEntryName);
                zipStream.PutNextEntry(entry);
                zipStream.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
        }
    }
}
