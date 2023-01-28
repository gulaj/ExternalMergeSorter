namespace Sorter.Core
{
    public interface IFileService
    {
        FileStream GetSourceFile(string fileName);
        FileStream GetTargetStream(string fileName);
        void GenerateFile(double fileSieze, string fileName, IEnumerable<string> words);
    }
}