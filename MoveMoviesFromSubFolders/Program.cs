using System;
using System.IO;
using System.Linq;
using Syroot.Windows.IO;

namespace MoveMoviesFromSubFolders
{
    class Program
    {
        private const string FOLDER_PATH = @"\\192.168.1.202\Media\Downloads";
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
                new FileInfo(file).MoveTo(Path.Combine(FOLDER_PATH, mFile.Name));
                filesMoved++;
            }

            Console.WriteLine($"Files moved: {filesMoved}");
            Console.ReadLine();
        }
    }
}
