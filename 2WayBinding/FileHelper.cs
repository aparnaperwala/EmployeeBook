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
        public static async Task WriteTextFileAsync(string filename, string content)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var textfile = await localFolder.CreateFileAsync
                //(filename, CreationCollisionOption.ReplaceExisting);
                (filename, CreationCollisionOption.OpenIfExists);
            //var textStream=await textfile.OpenAsync(FileAccessMode.ReadWrite);
            //var textStream = await textfile.OpenAsync(FileAccessMode.ReadWrite);
            await FileIO.AppendTextAsync(textfile, content + Environment.NewLine);


            //var textWriter = new DataWriter(textStream);
            //textWriter.WriteString(content);
            //await textWriter.StoreAsync();
        }

     
            public static async Task WriteAfterDeleteAsync(string filename, string content)
        { 
        
            var localFolder = ApplicationData.Current.LocalFolder;
            var textfile = await localFolder.CreateFileAsync
                (filename, CreationCollisionOption.ReplaceExisting);
                //(filename, CreationCollisionOption.OpenIfExists);
            //var textStream=await textfile.OpenAsync(FileAccessMode.ReadWrite);
           
            await FileIO.AppendTextAsync(textfile, content + Environment.NewLine);
          
            //var textWriter = new DataWriter(textStream);
            //textWriter.WriteString(content);
            //await textWriter.StoreAsync();
        }
       
        
        public static async Task<string> ReadTextFileAsync(string filename)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var textFile = await localFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }
        

            }
  }
    

