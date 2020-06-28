namespace ParseTheParcel.Models
{
    public class ParcelCost
    {
        public decimal Cost { get; private set; }
        public string Unit { get; private set; }
        public string CostString => $"{Cost} {CostString}";

        public ParcelCost(decimal cost, string unit = "NZD")
        {
            this.Cost = cost;
            this.Unit = unit;
        }
    }
}