using System;
using System.IO;
using System.Linq;
using Syroot.Windows.IO;
using static System.Net.WebRequestMethods;

namespace MoveMoviesFromSubFolders
{
    class Program
    {
        private const string FOLDER_PATH = @"\\192.168.178.200\Multimedia\Downloads";
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FOLDER_PATH);

            if (!dirInfo.Exists) return;

            var myMovieFiles = Directory.GetFiles(FOLDER_PATH, "*.mkv", SearchOption.AllDirectories).ToList();

            int filesMoved = 0;
            foreach (string file in myMovieFiles)
            {
                FileInfo mFile = new FileInfo(file);
                Console.WriteLine($"Move File: {mFile.Name}");
                var filePath = Path.Combine(FOLDER_PATH, mFile.Name);
                try
                {
                    new FileInfo(file).MoveTo(filePath);
                    filesMoved++;
                }
                catch
                {
                    Console.WriteLine($"unable to move File {filePath}.");
                }
            }

            Console.WriteLine($"Files moved: {filesMoved}");
            Console.ReadLine();
        }
    }
}
