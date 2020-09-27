using ParseTheParcel.Interfaces;
using ParseTheParcel.Models;
using ParseTheParcel.ParcelTypeParsers;

namespace ParseTheParcel
{
    public class ParcelTypeParserFactory
    {
        public static IParcelTypeParser GetParcelTypeParser()
        {
            var none = new NoneParcelTypeParser();
            // var large = new LargeParcelTypeParser(none);
            // var medium = new MediumParcelTypeParser(large);
            // var small = new SmallParcelTypeParser(medium);
            
            var large = new CustomParcelTypeParser(PackageTypes.Large, 400M, 600M, 250M, 8.50M, none);
            var medium = new CustomParcelTypeParser(PackageTypes.Medium, 300M, 400M, 200M, 7.50M, large);
            var small = new CustomParcelTypeParser(PackageTypes.Small, 200M, 300M, 150M, 5.00M, medium);

            return small;
        }
    }
}