using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

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
        protected override Parcel GetFittingParcel(ParcelInfo info)
        {
            return new Parcel(PackageTypes.Small, new ParcelCost(5.00m));
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 200m || info.Breadth > 300m || info.Height > 150m;
        }
    }
}