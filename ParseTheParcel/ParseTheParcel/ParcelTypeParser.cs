using ParseTheParcel.Interfaces;
using ParseTheParcel.ParcelTypeParsers;

namespace ParseTheParcel
{
    public class ParcelTypeParserFactory
    {
        public static IParcelTypeParser GetParcelTypeParser()
        {
            var none = new NoneParcelTypeParser();
            var large = new LargeParcelTypeParser(none);
            var medium = new MediumParcelTypeParser(large);
            var small = new SmallParcelTypeParser(medium);

            return small;
        }
    }
}