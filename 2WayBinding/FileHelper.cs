using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace _2WayBinding
{
    public static class FileHelper
    {
        /// <summary>
        /// Write content to file
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <param name="content">Content to write to file</param>
        public static async void WriteTextFileAsync(string filename, string content)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var textfile=await localFolder.CreateFileAsync
                (filename, CreationCollisionOption.OpenIfExists);
            var textstream=await textfile.OpenAsync(FileAccessMode.ReadWrite);
            var textWriter = new DataWriter(textstream);
            textWriter.WriteString(content);
            await textWriter.StoreAsync();
        }

    }
}
