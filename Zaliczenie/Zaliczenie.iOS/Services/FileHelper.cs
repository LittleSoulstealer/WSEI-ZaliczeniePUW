using System;
using System.IO;
using Xamarin.Forms;
using Zaliczenie.iOS.Services;
using Zaliczenie.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace Zaliczenie.iOS.Services
{
    class FileHelper:IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

    }
}