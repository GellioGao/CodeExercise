using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class NoneParcelTypeParser : IParcelTypeParser
    {
        public Parcel Calculate(ParcelInfo info)
        {
            return new Parcel();
        }
    }
}