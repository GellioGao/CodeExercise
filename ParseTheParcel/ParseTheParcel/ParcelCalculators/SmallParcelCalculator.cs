using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelCalculators
{
    public class SmallParcelCalculator : BaseParcelCalculator, IParcelCalculator
    {
        public SmallParcelCalculator(ParcelInfo info) :
            base(PackageTypes.Small, info)
        {
        }

        protected override ParcelCost GetParcelCost()
        {
            return new ParcelCost(5.00m);
        }
    }
}