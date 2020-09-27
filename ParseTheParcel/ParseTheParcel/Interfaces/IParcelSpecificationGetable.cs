using System.Collections.Generic;

namespace ParseTheParcel.Interfaces
{
    public interface IParcelSpecificationGetable
    {
        IEnumerable<IParcelSpecification> Specifications { get; }
    }
}