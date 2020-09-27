using ParseTheParcel.Interfaces;

namespace ParseTheParcel.Models
{
    public class PackageInfo : IPackageInfo
    {
        public int Length { get; private set; }

        public int Breadth { get; private set; }

        public int Height { get; private set; }

        public long Weight { get; private set; }

        public PackageInfo(int length, int breadth, int height, long weight)
        {
            this.Length = length;
            this.Breadth = breadth;
            this.Height = height;
            this.Weight = weight;
        }
    }
}