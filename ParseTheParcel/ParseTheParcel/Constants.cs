using System;

namespace ParseTheParcel
{
    public static class Constants
    {
        public const long DefaultUpperWeightLimit = 25000L;
        public const string RANGE_OF_DIMENSIONS = "The range of the dimensions should be Length:[1mm, 400mm], Breadth:[1mm, 600mm] and Height[1mm, 250mm].";
        public const string RANGE_OF_WEIGHT = "The range of the weight is [0.001kg, 25kg].";
        public const string PACKAGE_TOO_BIG_MESSAGE = "it's too big.\r\n" + RANGE_OF_DIMENSIONS;
        public const string PACKAGE_TOO_SMALL_MESSAGE = "it's too small.\r\n" + RANGE_OF_DIMENSIONS;
        public const string PACKAGE_TOO_HEAVY_MESSAGE = "it's too heavy.\r\n" + RANGE_OF_WEIGHT;
        public const string PACKAGE_TOO_LIGHT_MESSAGE = "it's too light.\r\n" + RANGE_OF_WEIGHT;

        public const string MESSAGE_OUTPUT_PARCEL_RESULT = "A {0} size parcel for your package, it coasts {1:C} NZD.";
        public const string MESSAGE_OUTPUT_PACKAGE_CANNOT_BE_ACCEPTED = "Your package cannot be accepted, because {0}";
        public const string MESSAGE_OUTPUT_USAGE_COMMAND = "Usage: dotnet run -p ./ParseTheParcel/ParseTheParcel.csproj <Length> <Breadth> <Height> <Weight>";
        public const string MESSAGE_OUTPUT_USAGE_ARGUMENTS = "Arguments: <Length>:mm <Breadth>:mm <Height>:mm <Weight>:kg\r\n<Length>, <Breadth>, <Height> are an integer, <Weight> is a float";
    }
}