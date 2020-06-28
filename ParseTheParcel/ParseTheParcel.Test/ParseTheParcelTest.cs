using System;

using Xunit;

using ParseTheParcel.Models;

namespace ParseTheParcel.Test
{
    /*
     *  Package Type    Length  Breadth Height  Cost
        Small           200mm   300mm   150mm   $5.00   9000000
        Medium          300mm   400mm   200mm   $7.50   24000000
        Large           400mm   600mm   250mm   $8.50   60000000
     * */

    public class ParseTheParcelTest
    {
        [Theory]
        [InlineData(-1, -1, -1, 0, PackageTypes.None)]
        [InlineData(0, 0, 0, -1, PackageTypes.None)]
        [InlineData(0, 0, 0, 0, PackageTypes.None)]
        [InlineData(0, 0, 0, 4, PackageTypes.None)]
        [InlineData(0.001, 0, 0, 4, PackageTypes.None)]
        [InlineData(1, 1, 0.1, 4, PackageTypes.None)]
        [InlineData(1, 1, 1, 0, PackageTypes.None)]
        [InlineData(200, 300, 150, 0, PackageTypes.None)]
        [InlineData(1, 1, 1, 5, PackageTypes.Small)]
        [InlineData(1, 1, 9000000, 5, PackageTypes.None)]
        [InlineData(1, 1, 9000000, 26, PackageTypes.None)]
        [InlineData(1, 1, 9000001, 5, PackageTypes.None)]
        [InlineData(200, 300, 150, 5, PackageTypes.Small)]
        [InlineData(200, 300, 150, 25, PackageTypes.Small)]
        [InlineData(200, 300, 150, 26, PackageTypes.None)]
        [InlineData(200, 300, 151, 25, PackageTypes.Medium)]
        [InlineData(300, 400, 200, 15, PackageTypes.Medium)]
        [InlineData(300, 400, 200, 25, PackageTypes.Medium)]
        [InlineData(1, 1, 24000000, 5, PackageTypes.None)]
        [InlineData(1, 1, 24000000, 26, PackageTypes.None)]
        [InlineData(1, 1, 24000001, 5, PackageTypes.None)]
        [InlineData(300, 400, 200, 26, PackageTypes.None)]
        [InlineData(300, 400, 201, 25, PackageTypes.Large)]
        [InlineData(400, 600, 250, 25, PackageTypes.Large)]
        [InlineData(1, 1, 60000000, 5, PackageTypes.None)]
        [InlineData(1, 1, 60000000, 26, PackageTypes.None)]
        [InlineData(1, 1, 60000001, 5, PackageTypes.None)]
        [InlineData(400, 600, 250, 26, PackageTypes.None)]
        [InlineData(9000000, 24000000, 60000000, 26, PackageTypes.None)]
        [InlineData(Int64.MaxValue, Int64.MaxValue, Int64.MaxValue, 26, PackageTypes.None)]
        public void Test1(decimal length, decimal breadth, decimal height, decimal weight, PackageTypes type)
        {
            var parser = new ParseTheParcel(ParcelTypeParserFactory.GetParcelTypeParser());
            var info = new ParcelInfo(length, breadth, height, weight);
            var parcel = parser.CalculateCost(info);
            Assert.Equal(type, parcel.Type);
        }
    }
}