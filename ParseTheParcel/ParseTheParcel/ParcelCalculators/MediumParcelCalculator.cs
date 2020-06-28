using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelCalculators
{
    public class MediumParcelCalculator : BaseParcelCalculator, IParcelCalculator
    {
        public MediumParcelCalculator(ParcelInfo info) :
            base(PackageTypes.Medium, info)
        {
        }

        protected override ParcelCost GetParcelCost()
        {
            return new ParcelCost(7.50m);
        }
    }
}