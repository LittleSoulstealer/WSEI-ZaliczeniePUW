using System;
using System.Collections.Generic;
using System.Text;

namespace Zaliczenie.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
