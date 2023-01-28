namespace Sorter.Core
{
    public class DataRecord: IComparable<DataRecord>
    {
        public int Number { get; set; }
        public string Text { get; set; }

        public DataRecord(int number ,string text)
        {
            Number = number;
            Text = text;
        }

        public int CompareTo(DataRecord? other)
        {
            return Text.CompareTo(other.Text);
        }

        public override string ToString()
        {
            return $"{Number}. {Text}";
        }
    }
}