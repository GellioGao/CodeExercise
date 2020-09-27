using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

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
        protected override Parcel GetFittingParcel(ParcelInfo info)
        {
            return new Parcel(PackageTypes.Large, new ParcelCost(8.50m));
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > 400m || info.Breadth > 600m || info.Height > 250m;
        }
    }
}