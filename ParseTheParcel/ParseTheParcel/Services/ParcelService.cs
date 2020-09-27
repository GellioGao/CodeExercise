using System.Collections.Generic;
using System.Linq;

using ParseTheParcel.Exceptions;
using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    public class ParcelService : IParcelService
    {
        private readonly int DeminsionLowerLimit;
        private readonly long WeightLowerLimit;

        private IParcelSpecificationGetable loader;

        public IEnumerable<IParcelSpecification> Specifications => this.loader.Specifications;

        public ParcelService(IParcelSpecificationGetable loader)
        {
            this.WeightLowerLimit = 1L;
            this.DeminsionLowerLimit = 0;
            this.loader = loader;
        }

        public IParcelResult Calculate(IPackageInfo packageInfo)
        {
            var specs = this.loader.Specifications;
            var upperLimit = specs.Max(specs => specs.Weight);

            this.CheckPackageWeight(packageInfo.Weight, upperLimit);
            this.CheckPackageDeminsions(packageInfo);
            
            foreach (var spec in specs)
            {
                if (IsFitTheSpecification(packageInfo, spec))
                {
                    return new ParcelResult(spec.Name, spec.Cost);
                }
            }
            throw new UnexpectedPackageException(Constants.PACKAGE_TOO_BIG_MESSAGE);
        }

        private bool IsFitTheSpecification(IPackageInfo packageInfo, IParcelSpecification spec)
        {
            return packageInfo.Length <= spec.Length
                && packageInfo.Breadth <= spec.Breadth
                && packageInfo.Height <= spec.Height
                && packageInfo.Weight <= spec.Weight;
        }

        private void CheckPackageDeminsions(IPackageInfo packageInfo)
        {
            if (packageInfo.Length <= this.DeminsionLowerLimit
                || packageInfo.Breadth <= this.DeminsionLowerLimit
                || packageInfo.Height <= this.DeminsionLowerLimit)
            {
                throw new UnexpectedPackageException(Constants.PACKAGE_TOO_SMALL_MESSAGE);
            }
        }

        private void CheckPackageWeight(long weight, long upperLimit)
        {
            if (weight < this.WeightLowerLimit)
            {
                throw new UnexpectedPackageException(Constants.PACKAGE_TOO_LIGHT_MESSAGE);
            }
            if (weight > upperLimit)
            {
                throw new UnexpectedPackageException(Constants.PACKAGE_TOO_HEAVY_MESSAGE);
            }
        }
    }
}