using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;
using Dolphin.IO;
using System.Collections.Generic;

namespace Dolphin.IO.Tests
{
    [TestClass]
    public class SerachTest
    {
        [TestMethod]
        public void OneBigSearchingTest()
        {
            PrepareTests();



            int correctCountDirsNotRec = Directory.GetFiles(Extra.TestDir).Length;
            int correctCountDirs = Directory.GetFiles(Extra.TestDir,"*",SearchOption.AllDirectories).Length;

            List<FileInfo> listOfFiles = new List<FileInfo>();
            listOfFiles = Search.FindFiles(new DirectoryInfo(Extra.TestDir), "*", true);

            Assert.AreEqual(correctCountDirs, listOfFiles.Count);

            listOfFiles = Search.FindFiles(new DirectoryInfo(Extra.TestDir), "*", false);

            Assert.AreEqual(correctCountDirsNotRec, listOfFiles.Count);


            int currCountDirs = 0;
            IEnumerable<FileInfo> fileInfos;
            fileInfos =  Search.FindFilesYield(new DirectoryInfo(Extra.TestDir), "*", true);

            foreach (FileInfo f in fileInfos)
            {
                currCountDirs++;
            }

            Assert.AreEqual(correctCountDirs, currCountDirs);

            currCountDirs = 0;
            fileInfos = Search.FindFilesYield(new DirectoryInfo(Extra.TestDir), "*", false);

            foreach (FileInfo f in fileInfos)
            {
                currCountDirs++;
            }
            Assert.AreEqual(correctCountDirsNotRec, currCountDirs);


            


            CleareTests();
        }


        private void PrepareTests()
        {
            if (Extra.IsTestDirExists())
            {
                Directory.Delete(Extra.TestDir, true);
            }

            Extra.CreateSomeDirsAndFilesForTests();

        }

        private void CleareTests()
        {
                Directory.Delete(Extra.TestDir, true);
        }

    }
}
