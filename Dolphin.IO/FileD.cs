using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dolphin;

using System.IO;

namespace Dolphin.IO
{
    public static class FileD
    {

        public static void Copy(string from, string to, int maxReWrite)
        {
            if (to[to.Length - 1] != '\\')
            {
                to += '\\';
            }

            string fileName = Path.GetFileName(from);
            to += fileName;
            try
            {
                File.Copy(from, to);
            }
            catch (IOException ex) when (ex.HResult == -2147024816)
            {

                string path = Path.GetDirectoryName(to);
                string ext = Path.GetExtension(to);
                for (int i = 1; i < maxReWrite; i++)
                {
                    bool errFlag = false;
                    string new_to = $"{path}\\{RandomD.GenerateNewCode(10)}{ext}";
                    if (!File.Exists(new_to))
                    {
                        try
                        {
                            File.Copy(from, new_to);
                        }
                        catch (IOException exx) when (exx.HResult == -2147024816)
                        {
                            errFlag = true;
                        }

                        if (errFlag == false)
                            break;
                    }

                }




            }
        }


        public enum CopyProperties
        {
            ReWrite,
            DoNotCopy,
            NewName,
        }

        public static void Copy(string from, string to, CopyProperties copyProp, int iter = 100)
        {
            if (to[to.Length - 1] != '\\')
            {
                to += '\\';
            }

            string fileName = Path.GetFileName(from);
            to += fileName;
            try
            {
                File.Copy(from, to);
            }
            catch (IOException ex) when (ex.HResult == -2147024816)
            {

                if (copyProp == CopyProperties.ReWrite)
                {
                    File.Delete(to);
                    File.Copy(from, to);
                }
                else if (copyProp == CopyProperties.NewName)
                {
                    string path = Path.GetDirectoryName(to);
                    string ext = Path.GetExtension(to);
                    string name = Path.GetFileNameWithoutExtension(to);
                    bool errFlag = false;
                    for (int i = 1; i <= iter; i++)
                    {
                        string new_to = $"{path}\\{name}_({i}){ext}";
                        if (!File.Exists(new_to))
                        {
                            try
                            {
                                File.Copy(from, new_to);
                            }
                            catch (IOException exx) when (exx.HResult == -2147024816)
                            {
                                errFlag = true;
                            }

                            if (errFlag == false)
                                break;
                        }
                    }
                }

            }
        }

    }
}
