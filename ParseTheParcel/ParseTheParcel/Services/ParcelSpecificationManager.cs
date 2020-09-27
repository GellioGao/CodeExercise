using System.Collections.Generic;
using System.Linq;

using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel
{
    public class ParcelSpecificationManager : IParcelSpecificationGetable, IParcelSpecificationSettable
    {
        public IEnumerable<IParcelSpecification> Specifications { get; set; }

        public ParcelSpecificationManager()
        {
            var specs = new List<IParcelSpecification>
            {
                new ParcelSpecification("Small", 5.00M, 200, 300, 150),
                new ParcelSpecification("Medium", 7.50M, 300, 400, 200),
                new ParcelSpecification("Large", 8.50M, 400, 600, 250),
            };
            this.Specifications = specs
                .OrderBy(spec => spec.Cost)
                .ToList();
        }
    }
}