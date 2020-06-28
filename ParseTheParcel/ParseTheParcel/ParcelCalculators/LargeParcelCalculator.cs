using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelCalculators
{
    public class LargeParcelCalculator : BaseParcelCalculator, IParcelCalculator
    {
        public LargeParcelCalculator(ParcelInfo info) :
            base(PackageTypes.Large, info)
        {
        }

        protected override ParcelCost GetParcelCost()
        {
            return new ParcelCost(8.50m);
        }
    }
}