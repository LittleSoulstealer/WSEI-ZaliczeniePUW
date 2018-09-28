using Zaliczenie.Services;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;
using Zaliczenie.UWP.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace Zaliczenie.UWP.Services
{
    class FileHelper:IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

    }
}
