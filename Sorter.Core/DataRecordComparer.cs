namespace Sorter.Core
{
    public class DataRecordComparer : IComparer<DataRecord>
    {
        public int Compare(DataRecord? x, DataRecord? y)
        {
            if (x == null && y != null)
            {
                return -1;
            }

            if (y == null && x != null)
            {
                return 1;
            }

            if (x == null || y == null)
            {
                return 0;
            }
            if (x.Number == y.Number) {
                return x.CompareTo(y);
            }
            return (x.Number < y.Number ? -1 : 1);
                    }
    }
}
