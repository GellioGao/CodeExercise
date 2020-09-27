using System.Collections.Generic;

namespace ParseTheParcel.Interfaces
{
    public interface IParcelService : IParcelSpecificationGetable
    {
        IParcelResult Calculate(IPackageInfo packageInfo);
    }
}