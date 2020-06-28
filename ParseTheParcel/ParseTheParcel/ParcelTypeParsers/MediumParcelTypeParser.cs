using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.ParcelCalculators;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class MediumParcelTypeParser : BaseParcelTypeParser, IParcelTypeParser, INextable
    {
        public MediumParcelTypeParser(IParcelTypeParser next)
            : base(next)
        {
        }

        //Package Type    Length        Breadth     Height      Cost
        //Medium	        300mm	    400mm	    200mm	    $7.50
        protected override IParcelCalculator GetFittingCalculator(ParcelInfo info)
        {
            return new MediumParcelCalculator(info);
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 300m || info.Breadth > 400m || info.Height > 200m;
        }
    }
}