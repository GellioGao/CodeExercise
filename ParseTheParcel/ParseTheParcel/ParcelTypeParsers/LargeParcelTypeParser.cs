using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.ParcelCalculators;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class LargeParcelTypeParser : BaseParcelTypeParser, IParcelTypeParser, INextable
    {
        public LargeParcelTypeParser(IParcelTypeParser next)
            : base(next)
        {
        }

        //Package Type    Length        Breadth     Height      Cost
        //Large	            400mm	    600mm	    250mm	    $8.50
        protected override IParcelCalculator GetFittingCalculator(ParcelInfo info)
        {
            return new LargeParcelCalculator(info);
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 400m || info.Breadth > 600m || info.Height > 250m;
        }
    }
}