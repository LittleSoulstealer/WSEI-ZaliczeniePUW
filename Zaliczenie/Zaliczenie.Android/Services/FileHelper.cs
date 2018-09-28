using System.IO;
using Zaliczenie.Droid.Services;
using Xamarin.Forms;
using Zaliczenie.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace Zaliczenie.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}