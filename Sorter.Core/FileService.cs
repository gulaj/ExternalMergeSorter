namespace Sorter.Core
{
    public class FileService : IFileService
    {
        private const string TempPath = @"C:\temp\";
        public FileStream GetSourceFile(string fileName)
        {
            return File.OpenRead(Path.Combine(TempPath, fileName));
        }
        public FileStream GetTargetStream(string fileName)
        {
            return File.OpenWrite(Path.Combine(TempPath, $"sorted_{fileName}".ToLower()));
        }

        public void GenerateFile(double fileSieze, string fileName, IEnumerable<string> words)
        {
            using var tw = new StreamWriter(Path.Combine(TempPath, fileName.ToLower()));
            Random r = new();
            while (tw.BaseStream.Length < fileSieze * 1024 * 1024)
            {
                var num = r.Next(1, 2000);
                var count = words.Count();
                var numberOfWords = r.Next(1, 4);
                var word = words.Skip(r.Next(1, count - numberOfWords)).Take(numberOfWords);
                var sentence = string.Join(' ', word);
                tw.WriteLine($"{num}. {sentence}");
            }
        }
    }
}