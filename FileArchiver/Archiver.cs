using System;
using System.IO;

namespace FileArchiver
{
    class Archiver
    {
        private FileInfo sourceFile;
        private DirectoryInfo targetDir;

        public Archiver(string sourceFile, string targetDir)
        {
            this.sourceFile = new FileInfo(sourceFile);
            if (!this.sourceFile.Exists)
            {
                throw new FileNotFoundException("Could not find " + sourceFile);
            }

            this.targetDir = new DirectoryInfo(targetDir);
            if (!this.targetDir.Exists)
            {
                this.targetDir.Create();
            }
        }

        public void Archive()
        {
            string targetFileName = Path.GetFileNameWithoutExtension(sourceFile.FullName) + 
                "." + DateTime.Now.ToString("yyyyMMdd") + 
                "." + DateTime.Now.ToString("HHmmss") + 
                sourceFile.Extension;

            sourceFile.CopyTo(targetDir.FullName + @"\" + targetFileName, true);
        }
    }
}