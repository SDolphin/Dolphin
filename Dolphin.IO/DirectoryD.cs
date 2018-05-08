using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Dolphin.IO
{
    public static class DirectoryD
    {

        public static bool CleanDirectory(string path)
        {
            try
            {
                cldir(path);
            }
            catch (Exception ex) { return false; }

            return true;

        }

        private static void cldir(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    CleanDirectory(di.FullName);
                    di.Delete();
                }
            }
        }
    }
}
