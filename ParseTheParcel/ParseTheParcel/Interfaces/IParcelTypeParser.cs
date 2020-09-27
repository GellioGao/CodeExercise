using ParseTheParcel.Models;

namespace ParseTheParcel.Interfaces
{
    public interface IParcelTypeParser
    {
        Parcel Calculate(ParcelInfo info);
    }
}