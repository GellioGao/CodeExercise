using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.ParcelCalculators;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class NoneParcelTypeParser : IParcelTypeParser
    {
        public IParcelCalculator Parser(ParcelInfo info)
        {
            return new NoneParcelCalculator();
        }
    }
}