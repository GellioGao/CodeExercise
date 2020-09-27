using System;

using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.ParcelTypeParsers
{
    public abstract class BaseParcelTypeParser : IParcelTypeParser, INextable
    {
        private const decimal UpperLimit = 25m;

        public IParcelTypeParser Next { get; private set; }

        public BaseParcelTypeParser(IParcelTypeParser next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            this.Next = next;
        }

        public virtual Parcel Calculate(ParcelInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            if (this.IsParcelFitMe(info))
            {
                return this.GetFittingParcel(info);
            }
            return this.Next.Calculate(info);
        }

        protected abstract Parcel GetFittingParcel(ParcelInfo info);

        protected virtual bool IsParcelFitMe(ParcelInfo info)
        {
            return !IsOverWeight(info.Weight) && !IsOverSize(info);
        }

        protected virtual bool IsOverWeight(decimal weight)
        {
            return weight <= 0 || weight > UpperLimit;
        }

        protected virtual bool IsOverSize(ParcelInfo info)
        {
            return info.Length < 1m || info.Breadth < 1m || info.Height < 1m;
        }
    }
}