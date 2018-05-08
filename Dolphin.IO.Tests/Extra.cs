using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;

namespace Dolphin.IO.Tests
{

    public static class Extra
    {
        private static string _testDir = "ForTests";

        public static string TestDir
        {
            get => _testDir;
        }

        public static bool IsTestDirExists()
        {
            if (Directory.Exists(_testDir))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CreateSomeDirsAndFilesForTests()
        {   

            Directory.CreateDirectory($"{_testDir}");
            File.Create($"{_testDir}\\1").Dispose();
            File.Create($"{_testDir}\\2").Dispose();
            Directory.CreateDirectory($"{_testDir}\\dir1");
            File.Create($"{_testDir}\\dir1\\3").Dispose();
            File.Create($"{_testDir}\\dir1\\4").Dispose();
            File.Create($"{_testDir}\\dir1\\5").Dispose();
            Directory.CreateDirectory($"{_testDir}\\dir2");
            File.Create($"{_testDir}\\dir2\\6").Dispose();
        }
    }
}
