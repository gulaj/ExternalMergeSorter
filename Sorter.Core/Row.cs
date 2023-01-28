namespace Sorter.Core
{
    internal readonly struct Row
    {
        public DataRecord Value { get; init; }
        public int StreamReader { get; init; }
    }
}
