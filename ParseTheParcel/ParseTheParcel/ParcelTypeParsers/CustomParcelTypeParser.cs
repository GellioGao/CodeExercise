using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelTypeParsers
{
    public class CustomParcelTypeParser : BaseParcelTypeParser, IParcelTypeParser, INextable
    {
        protected decimal LengthUpperLimit { get; private set; }
        protected decimal BreadthUpperLimit { get; private set; }
        protected decimal HeightUpperLimit { get; private set; }
        protected decimal Cost { get; private set; }
        protected PackageTypes Type { get; private set; }

        public CustomParcelTypeParser(PackageTypes type, decimal lengthUpperLimit, decimal breadthUpperLimit, decimal heightUpperLimit, decimal cost, IParcelTypeParser next)
            : base(next)
        {
            this.Type = type;
            this.LengthUpperLimit = lengthUpperLimit;
            this.BreadthUpperLimit = breadthUpperLimit;
            this.HeightUpperLimit = heightUpperLimit;
            this.Cost = cost;
        }

        //Package Type    Length        Breadth     Height      Cost
        //Medium	        300mm	    400mm	    200mm	    $7.50
        protected override Parcel GetFittingParcel(ParcelInfo info)
        {
            return new Parcel(this.Type, new ParcelCost(this.Cost));
        }

        protected override bool IsOverSize(ParcelInfo info)
        {
            return base.IsOverSize(info) || info.Length > LengthUpperLimit || info.Breadth > BreadthUpperLimit || info.Height > HeightUpperLimit;
        }
    }
}