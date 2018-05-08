using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dolphin.IO;

using System.Threading;

using System.IO;

namespace Dolphin.IO.Tests
{
    [TestClass]
    public class DirectoryDTest
    {
        [TestMethod]
        public void CreatingAndClearingDirs()
        {
            bool status = false;
            if (Extra.IsTestDirExists())
            {
                Assert.Fail("Error in creating test dirs, dirs already exists");
            }

            Extra.CreateSomeDirsAndFilesForTests();

            Thread.Sleep(1000);

            status = DirectoryD.CleanDirectory(Extra.TestDir);

            Assert.AreEqual(status, true);

            Directory.Delete(Extra.TestDir);

            if (Extra.IsTestDirExists())
            {
                Assert.Fail("Error in deleting test dirs");
            }

        }
    }
}
