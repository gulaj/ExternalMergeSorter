namespace Sorter.Core
{
    public class ExternalMergeSortSortOptions
    {
        public IComparer<DataRecord> Comparer { get; init; } = Comparer<DataRecord>.Default;
        public int InputBufferSize { get; init; } = 65536;
        public int OutputBufferSize { get; init; } = 65536;
        public IProgress<double> ProgressHandler { get; init; } = null!;
    }

}