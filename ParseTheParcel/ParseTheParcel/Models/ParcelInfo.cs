namespace ParseTheParcel.Models
{
    public class ParcelInfo
    {
        public decimal Length { get; private set; }
        public decimal Breadth { get; private set; }
        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }

        public ParcelInfo(decimal length, decimal breadth, decimal height, decimal weight)
        {
            this.Length = length;
            this.Breadth = breadth;
            this.Height = height;
            this.Weight = weight;
        }
    }
}