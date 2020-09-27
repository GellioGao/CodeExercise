using System.Collections.Generic;

namespace ParseTheParcel.Interfaces
{
    public interface IParcelSpecificationSettable
    {
        IEnumerable<IParcelSpecification> Specifications { set; }
    }
}