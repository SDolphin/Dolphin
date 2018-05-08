using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;

namespace Dolphin.IO
{
    public class DolphinIOException : Exception
    {
        public DolphinIOException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }


    /// <summary>
    /// Статичный класс с всевозможными расширениями
    /// </summary>
    public static class FileExtensions
    {
        public static string[] Images = { "*.jpg", "*.png" };
        public static string[] BrowserHistory = { "History" };
    }


    /// <summary>
    /// класс который осуществялет поиск файлов по расширения, имеет инкрементируемые функции
    /// </summary>
    public static class Search
    {

        public static bool SilentMod = false;

        /// <summary>
        /// Рекурсиный yield инкрементированный просмотр каталогов по одному паттерну
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> FindFilesYield(DirectoryInfo dir, string pattern, bool recursive)
        {
            FileInfo[] files = null;
            try
            {
                files = dir.GetFiles(pattern);
            }
            catch (UnauthorizedAccessException ex)
            {
                if (SilentMod == true)
                {

                }
                else
                {
                    throw new DolphinIOException("Нет прав доступа", ex);
                }
            }

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    yield return file;
                }
            }

            if (recursive)
            {

                DirectoryInfo[] subdirs = null;
                try
                {
                    subdirs = dir.GetDirectories();
                }
                catch (UnauthorizedAccessException ex)
                {
                    if (SilentMod == true)
                    {

                    }
                    else
                    {
                        throw new DolphinIOException("Нет прав доступа", ex);
                    }
                }

                if (subdirs != null)
                {
                    foreach (DirectoryInfo subdir in subdirs)
                    {

                        foreach (FileInfo s in FindFilesYield(subdir, pattern, recursive))
                        {
                            yield return s;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Рекурсиный yield инкрементированный просмотр каталогов по массиву паттернов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> FindFilesYield(DirectoryInfo dir, string[] pattern, bool recursive)
        {
            FileInfo[] files = null;
            try
            {
                files = pattern.SelectMany(i => dir.GetFiles(i)).ToArray();
            }
            catch (UnauthorizedAccessException ex)
            {
                if (SilentMod == true)
                {

                }
                else
                {
                    throw new DolphinIOException("Нет прав доступа", ex);
                }
            }

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    yield return file;
                }
            }

            if (recursive)
            {

                DirectoryInfo[] subdirs = null;
                try
                {
                    subdirs = dir.GetDirectories();
                }
                catch (UnauthorizedAccessException ex)
                {
                    if (SilentMod == true)
                    {

                    }
                    else
                    {
                        throw new DolphinIOException("Нет прав доступа", ex);
                    }
                }

                if (subdirs != null)
                {
                    foreach (DirectoryInfo subdir in subdirs)
                    {

                        foreach (FileInfo s in FindFilesYield(subdir, pattern, recursive))
                        {
                            yield return s;
                        }
                    }
                }
            }
        }


      

        /// <summary>
        /// Поик файлов по массиву патернов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <returns>список найденных файлов</returns>
        public static List<FileInfo> FindFiles(DirectoryInfo dir, string[] pattern, bool recursive)
        {
            List<FileInfo> curList = new List<FileInfo>();

            FindFiles(dir, pattern, recursive, curList);

            return curList;
        }

        /// <summary>
        /// Поик файлов по паттерну
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <returns>список найденных файлов</returns>
        public static List<FileInfo> FindFiles(DirectoryInfo dir, string pattern, bool recursive)
        {

            string[] patterns = new string[1];
            patterns[0] = pattern;
            List<FileInfo> curList = new List<FileInfo>();

            FindFiles(dir, patterns, recursive, curList);

            return curList;
        }

        /// <summary>
        /// Вспомогательный метод для List<FileInfo> FindFiles(...)
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <param name="recursive"></param>
        /// <param name="curList"></param>
        private static void FindFiles(DirectoryInfo dir, string[] pattern, bool recursive, List<FileInfo> curList)
        {
            FileInfo[] files = null;
            try
            {
                files = pattern.SelectMany(i => dir.GetFiles(i)).ToArray();
            }
            catch (UnauthorizedAccessException ex)
            {
                if (SilentMod == true)
                {

                }
                else
                {
                    throw new DolphinIOException("Нет прав доступа", ex);
                }
            }

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    curList.Add(file);
                }
            }

            if (recursive)
            {

                DirectoryInfo[] subdirs = null;
                try
                {
                    subdirs = dir.GetDirectories();
                }
                catch (UnauthorizedAccessException ex)
                {
                    if (SilentMod == true)
                    {

                    }
                    else
                    {
                        throw new DolphinIOException("Нет прав доступа", ex);
                    }
                }

                if (subdirs != null)
                {
                    foreach (DirectoryInfo subdir in subdirs)
                    {
                        FindFiles(subdir, pattern, recursive, curList);
                    }
                }
            }
        }
    }

}
