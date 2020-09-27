using ParseTheParcel.Interfaces;

namespace ParseTheParcel.Models
{
    internal class ParcelResult : IParcelResult
    {
        public string ParcelType { get; private set; }

        public decimal Cost { get; private set; }

        public ParcelResult(string type, decimal cost)
        {
            this.ParcelType = type;
            this.Cost = cost;
        }
    }
}