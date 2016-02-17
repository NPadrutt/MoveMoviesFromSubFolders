using System.IO;
using System.Linq;

namespace MoveMoviesFromSubFolders
{
    class Program
    {
        const string DIRECTORY_NAME = @"C:\Users\ninop\Downloads";
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DIRECTORY_NAME);

            if (!dirInfo.Exists) return;

            var MyMusicFiles = Directory.GetFiles(DIRECTORY_NAME, "*.mkv", SearchOption.AllDirectories).ToList();

            foreach (string file in MyMusicFiles)
            {
                FileInfo mFile = new FileInfo(file);
                new FileInfo(file).MoveTo(Path.Combine(DIRECTORY_NAME, mFile.Name));
            }
        }
    }
}
