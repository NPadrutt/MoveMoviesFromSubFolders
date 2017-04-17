using System;
using System.IO;
using System.Linq;
using Syroot.Windows.IO;

namespace MoveMoviesFromSubFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(KnownFolders.Downloads.Path);

            if (!dirInfo.Exists) return;

            var myMovieFiles = Directory.GetFiles(KnownFolders.Downloads.Path, "*.mkv", SearchOption.AllDirectories).ToList();

            int filesMoved = 0;
            foreach (string file in myMovieFiles)
            {
                FileInfo mFile = new FileInfo(file);
                Console.WriteLine($"Move File: {mFile.Name}");
                new FileInfo(file).MoveTo(Path.Combine(KnownFolders.Downloads.Path, mFile.Name));
                filesMoved++;
            }

            Console.WriteLine($"Files moved: {filesMoved}");
            Console.ReadLine();
        }
    }
}
