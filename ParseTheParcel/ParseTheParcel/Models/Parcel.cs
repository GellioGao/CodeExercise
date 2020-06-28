namespace ParseTheParcel.Models
{
    public class Parcel
    {
        public PackageTypes Type { get; private set; }
        public ParcelCost Cost { get; private set; }

        public Parcel(PackageTypes type = PackageTypes.None, ParcelCost cost = null)
        {
            this.Type = type;
            this.Cost = cost ?? new ParcelCost(-1m);
        }
    }
}