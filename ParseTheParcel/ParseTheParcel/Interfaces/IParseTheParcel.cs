using ParseTheParcel.Models;

namespace ParseTheParcel.Interfaces
{
    public interface IParseTheParcel
    {
        Parcel CalculateCost(ParcelInfo info);
    }
}