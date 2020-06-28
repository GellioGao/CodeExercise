using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelCalculators
{
    public class NoneParcelCalculator : IParcelCalculator
    {
        public Parcel GetParcel()
        {
            return new Parcel();
        }
    }
}