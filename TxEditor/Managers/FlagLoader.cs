namespace Unclassified.TxEditor.Managers
{
    using System;
    using System.IO;
    using System.Windows;

    public class FlagLoader
    {
        private readonly string flagsFolder;

        public FlagLoader(string flagsFolder)
        {
            if (!Directory.Exists(flagsFolder))
            {
                throw new DirectoryNotFoundException(flagsFolder);
            }

            this.flagsFolder = flagsFolder;
        }

        public void Upload(string cultureName, string flagImageSrc, bool replaceIfExist = false)
        {
            bool alreadyExistWithSameName = this.IsExist(cultureName);
            if (!alreadyExistWithSameName || replaceIfExist)
            {
                try
                {
                    File.Copy(flagImageSrc, Path.Combine(this.flagsFolder, cultureName + ".png"), true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show(e.Message);
                }
            }
        }

        public bool IsExist(string cultureName)
        {
            return File.Exists(Path.Combine(this.flagsFolder, cultureName + ".png"));
        }

        public string GetFullPathToImage(string cultureName)
        {
            return Path.Combine(this.flagsFolder, cultureName + ".png");
        }
    }
}