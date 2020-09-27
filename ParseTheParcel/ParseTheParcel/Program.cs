using System;

using ParseTheParcel.Exceptions;
using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.Services;

namespace ParseTheParcel
{
    class Program
    {
        private const int ArgumentCount = 4;
        private const double WeightFactor = 1000D;

        static void Main(string[] args)
        {
            if (args.Length != ArgumentCount)
            {
                Usage();
                return;
            }
            IParcelService parcelService = new ParcelService(new ParcelSpecificationManager());
            try
            {
                IPackageInfo packageInfo = GetPackageInfo(args);

                IParcelResult result = parcelService.Calculate(packageInfo);

                Console.WriteLine(string.Format(Constants.MESSAGE_OUTPUT_PARCEL_RESULT, result.ParcelType, result.Cost));
            }
            catch (UnexpectedPackageException unexpected)
            {
                Console.WriteLine(string.Format(Constants.MESSAGE_OUTPUT_PACKAGE_CANNOT_BE_ACCEPTED, unexpected.Message));
            }
            catch (ArgumentNullException nullArgument)
            {
                Console.WriteLine(nullArgument.Message);
            }
            catch (ArgumentException invalidArgument)
            {
                Console.WriteLine(invalidArgument.Message);
                Usage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static IPackageInfo GetPackageInfo(string[] args)
        {
            int length, breadth, height;
            long weight;
            try
            {
                length = int.Parse(args[0]);
                breadth = int.Parse(args[1]);
                height = int.Parse(args[2]);
                weight = (long)(double.Parse(args[3]) * WeightFactor);
            }
            catch (FormatException fe)
            {
                throw new ArgumentException("Inputs: " + string.Join(',', args), fe);
            }
            IPackageInfo packageInfo = new PackageInfo(length, breadth, height, weight);
            return packageInfo;
        }

        private static void Usage()
        {
            Console.WriteLine(Constants.MESSAGE_OUTPUT_USAGE_COMMAND);
            Console.WriteLine(Constants.MESSAGE_OUTPUT_USAGE_ARGUMENTS);
        }
    }
}
