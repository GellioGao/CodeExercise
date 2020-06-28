using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParseTheParcel.ParcelCalculators
{
    public abstract class BaseParcelCalculator : IParcelCalculator
    {
        public BaseParcelCalculator(PackageTypes type, ParcelInfo info)
        {
            this.ParcelType = type;
            this.ParcelInfo = info;
        }

        public PackageTypes ParcelType { get; }
        public ParcelInfo ParcelInfo { get; }

        public Parcel GetParcel()
        {
            return new Parcel(this.ParcelType, this.GetParcelCost());
        }

        protected abstract ParcelCost GetParcelCost();
    }
}