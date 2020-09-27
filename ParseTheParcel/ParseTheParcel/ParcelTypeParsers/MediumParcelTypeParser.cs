using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

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
        protected override Parcel GetFittingParcel(ParcelInfo info)
        {
            return new Parcel(PackageTypes.Medium, new ParcelCost(7.50m));
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 300m || info.Breadth > 400m || info.Height > 200m;
        }
    }
}