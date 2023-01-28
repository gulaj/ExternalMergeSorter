namespace Sorter.Core
{
    public class ExternalMergeSortSplitOptions
    {
        public int FileChunkSize { get; init; } = 2 * 1024 * 1024;
        public char NewLineSeparator { get; init; } = '\n';
        public IProgress<double> ProgressHandler { get; init; } = null!;
    }

}