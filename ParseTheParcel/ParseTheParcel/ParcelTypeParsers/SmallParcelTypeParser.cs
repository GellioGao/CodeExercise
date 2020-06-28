using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.ParcelCalculators;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class SmallParcelTypeParser : BaseParcelTypeParser, IParcelTypeParser, INextable
    {
        public SmallParcelTypeParser(IParcelTypeParser next)
            : base(next)
        {
        }

        //Package Type    Length        Breadth     Height      Cost
        //Small	            200mm	    300mm	    150mm	    $5.00
        protected override IParcelCalculator GetFittingCalculator(ParcelInfo info)
        {
            return new SmallParcelCalculator(info);
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 200m || info.Breadth > 300m || info.Height > 150m;
        }
    }
}