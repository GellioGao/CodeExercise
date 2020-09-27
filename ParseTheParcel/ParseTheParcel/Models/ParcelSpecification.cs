using ParseTheParcel.Interfaces;

namespace ParseTheParcel.Models
{
    public class ParcelSpecification : IParcelSpecification
    {
        public string Name { get; private set; }
        
        public decimal Cost { get; private set; }
        
        public int Length { get; private set; }

        public int Breadth { get; private set; }

        public int Height { get; private set; }

        public long Weight { get; private set; }

        public ParcelSpecification(string name, decimal cost, int length, int breadth, int height, long weight = Constants.DefaultUpperWeightLimit)
        {
            this.Name = name;
            this.Cost = cost;
            this.Length = length;
            this.Breadth = breadth;
            this.Height = height;
            this.Weight = weight;
        }
    }
}