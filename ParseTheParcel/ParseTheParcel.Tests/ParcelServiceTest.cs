using System;

using Xunit;

using ParseTheParcel.Interfaces;
using ParseTheParcel.Services;
using ParseTheParcel.Models;
using ParseTheParcel.Exceptions;

namespace ParseTheParcel.Tests
{
    public class ParcelServiceTest
    {
        private IParcelService parcelService;
        public ParcelServiceTest()
        {
            this.parcelService = new ParcelService(new ParcelSpecificationManager());
        }

        // | Package Type   | Length | Breadth | Height | Cost |
        // | ---            | ---   | ---       | ---   | ---   | --- |
        // | Small          | 200mm | 300mm     | 150mm | $5.00 |
        // | Medium         | 300mm | 400mm     | 200mm | $7.50 |
        // | Large          | 400mm | 600mm     | 250mm | $8.50 |
        [Theory]
        [InlineData(1, 1, 1, (long)(0.5 * 1000))]
        [InlineData(1, 300, 1, (long)(0.5 * 1000))]
        [InlineData(1, 1, 150, (long)(0.5 * 1000))]
        [InlineData(1, 300, 150, (long)(0.5 * 1000))]
        [InlineData(200, 1, 1, (long)(0.5 * 1000))]
        [InlineData(200, 300, 1, (long)(0.5 * 1000))]
        [InlineData(200, 1, 150, (long)(0.5 * 1000))]
        [InlineData(200, 300, 150, (long)(0.5 * 1000))]
        public void TestCalculateInBound_Size_Small(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Small", result.ParcelType);
            Assert.Equal(5.00M, result.Cost);
        }

        [Theory]
        [InlineData(1, 1, 1, (long)(0.001 * 1000))]
        [InlineData(1, 1, 1, (long)(25.00 * 1000))]
        public void TestCalculateInBound_Weight_Small(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Small", result.ParcelType);
            Assert.Equal(5.00M, result.Cost);
        }

        [Theory]
        [InlineData(1, 301, 1, (long)(0.5 * 1000))]
        [InlineData(1, 1, 151, (long)(0.5 * 1000))]
        [InlineData(1, 301, 151, (long)(0.5 * 1000))]
        [InlineData(201, 1, 1, (long)(0.5 * 1000))]
        [InlineData(201, 301, 1, (long)(0.5 * 1000))]
        [InlineData(201, 1, 151, (long)(0.5 * 1000))]
        [InlineData(200, 301, 150, (long)(0.5 * 1000))]
        [InlineData(201, 301, 151, (long)(0.5 * 1000))]
        [InlineData(201, 400, 151, (long)(0.5 * 1000))]
        [InlineData(201, 301, 200, (long)(0.5 * 1000))]
        [InlineData(201, 400, 200, (long)(0.5 * 1000))]
        [InlineData(300, 301, 151, (long)(0.5 * 1000))]
        [InlineData(300, 400, 151, (long)(0.5 * 1000))]
        [InlineData(300, 301, 200, (long)(0.5 * 1000))]
        [InlineData(300, 400, 200, (long)(0.5 * 1000))]
        public void TestCalculateInBound_Size_Medium(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Medium", result.ParcelType);
            Assert.Equal(7.50M, result.Cost);
        }

        [Theory]
        [InlineData(201, 301, 151, (long)(0.001 * 1000))]
        [InlineData(201, 301, 151, (long)(25.00 * 1000))]
        public void TestCalculateInBound_Weight_Medium(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Medium", result.ParcelType);
            Assert.Equal(7.50M, result.Cost);
        }

        [Theory]
        [InlineData(201, 401, 151, (long)(0.5 * 1000))]
        [InlineData(201, 301, 201, (long)(0.5 * 1000))]
        [InlineData(201, 401, 201, (long)(0.5 * 1000))]
        [InlineData(301, 301, 151, (long)(0.5 * 1000))]
        [InlineData(301, 401, 151, (long)(0.5 * 1000))]
        [InlineData(301, 301, 201, (long)(0.5 * 1000))]
        [InlineData(300, 401, 200, (long)(0.5 * 1000))]
        [InlineData(301, 401, 201, (long)(0.5 * 1000))]
        [InlineData(301, 600, 201, (long)(0.5 * 1000))]
        [InlineData(301, 401, 250, (long)(0.5 * 1000))]
        [InlineData(301, 600, 250, (long)(0.5 * 1000))]
        [InlineData(400, 401, 201, (long)(0.5 * 1000))]
        [InlineData(400, 600, 201, (long)(0.5 * 1000))]
        [InlineData(400, 401, 250, (long)(0.5 * 1000))]
        [InlineData(400, 600, 250, (long)(0.5 * 1000))]
        public void TestCalculateInBound_Size_Large(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Large", result.ParcelType);
            Assert.Equal(8.50M, result.Cost);
        }

        [Theory]
        [InlineData(301, 401, 201, (long)(0.001 * 1000))]
        [InlineData(301, 401, 201, (long)(25.00 * 1000))]
        public void TestCalculateInBound_Weight_Large(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var result = this.parcelService.Calculate(info);
            Assert.Equal("Large", result.ParcelType);
            Assert.Equal(8.50M, result.Cost);
        }

        [Theory]
        [InlineData(0, 1, 1, (long)(0.5 * 1000))]
        [InlineData(1, 0, 1, (long)(0.5 * 1000))]
        [InlineData(1, 1, 0, (long)(0.5 * 1000))]
        [InlineData(0, 0, 1, (long)(0.5 * 1000))]
        [InlineData(0, 1, 0, (long)(0.5 * 1000))]
        [InlineData(1, 0, 0, (long)(0.5 * 1000))]
        [InlineData(0, 0, 0, (long)(0.5 * 1000))]
        [InlineData(401, 600, 250, (long)(0.5 * 1000))]
        [InlineData(400, 601, 250, (long)(0.5 * 1000))]
        [InlineData(400, 600, 251, (long)(0.5 * 1000))]
        [InlineData(401, 601, 250, (long)(0.5 * 1000))]
        [InlineData(401, 600, 251, (long)(0.5 * 1000))]
        [InlineData(400, 601, 251, (long)(0.5 * 1000))]
        [InlineData(401, 601, 251, (long)(0.5 * 1000))]
        public void TestCalculateOutBound_Size_UnexpectedPackageException(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
        }

        [Theory]
        [InlineData(1, 1, 1, (long)(0.00 * 1000))]
        [InlineData(200, 300, 150, (long)(0.00 * 1000))]
        [InlineData(400, 600, 250, (long)(0.00 * 1000))]
        [InlineData(1, 1, 1, (long)(25.001 * 1000))]
        [InlineData(200, 300, 150, (long)(25.001 * 1000))]
        [InlineData(400, 600, 250, (long)(25.001 * 1000))]
        [InlineData(1, 1, 1, (long)(25.1 * 1000))]
        [InlineData(200, 300, 150, (long)(25.1 * 1000))]
        [InlineData(400, 600, 250, (long)(25.1 * 1000))]
        [InlineData(1, 1, 1, (long)(120.5 * 1000))]
        [InlineData(200, 300, 150, (long)(120.5 * 1000))]
        [InlineData(400, 600, 250, (long)(120.5 * 1000))]
        public void TestCalculateOutBound_Weight_UnexpectedPackageException(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
        }

        
        [Theory]
        [InlineData(0, 1, 1, (long)(0.5 * 1000))]
        [InlineData(1, 0, 1, (long)(0.5 * 1000))]
        [InlineData(1, 1, 0, (long)(0.5 * 1000))]
        [InlineData(0, 0, 1, (long)(0.5 * 1000))]
        [InlineData(0, 1, 0, (long)(0.5 * 1000))]
        [InlineData(1, 0, 0, (long)(0.5 * 1000))]
        [InlineData(0, 0, 0, (long)(0.5 * 1000))]
        public void TestCalculateOutBound_Size_UnexpectedPackageException_TooSmall(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var unexpected = Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
            Assert.Equal(Constants.PACKAGE_TOO_SMALL_MESSAGE, unexpected.Message);

        }
        
        [Theory]
        [InlineData(401, 600, 250, (long)(0.5 * 1000))]
        [InlineData(400, 601, 250, (long)(0.5 * 1000))]
        [InlineData(400, 600, 251, (long)(0.5 * 1000))]
        [InlineData(401, 601, 250, (long)(0.5 * 1000))]
        [InlineData(401, 600, 251, (long)(0.5 * 1000))]
        [InlineData(400, 601, 251, (long)(0.5 * 1000))]
        [InlineData(401, 601, 251, (long)(0.5 * 1000))]
        public void TestCalculateOutBound_Size_UnexpectedPackageException_TooBig(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var unexpected = Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
            Assert.Equal(Constants.PACKAGE_TOO_BIG_MESSAGE, unexpected.Message);
        }

        [Theory]
        [InlineData(1, 1, 1, (long)(0.00 * 1000))]
        [InlineData(200, 300, 150, (long)(0.00 * 1000))]
        [InlineData(400, 600, 250, (long)(0.00 * 1000))]
        public void TestCalculateOutBound_Weight_UnexpectedPackageException_TooLight(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var unexpected = Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
            Assert.Equal(Constants.PACKAGE_TOO_LIGHT_MESSAGE, unexpected.Message);
        }
        
        [Theory]
        [InlineData(1, 1, 1, (long)(25.001 * 1000))]
        [InlineData(200, 300, 150, (long)(25.001 * 1000))]
        [InlineData(400, 600, 250, (long)(25.001 * 1000))]
        [InlineData(1, 1, 1, (long)(25.1 * 1000))]
        [InlineData(200, 300, 150, (long)(25.1 * 1000))]
        [InlineData(400, 600, 250, (long)(25.1 * 1000))]
        [InlineData(1, 1, 1, (long)(120.5 * 1000))]
        [InlineData(200, 300, 150, (long)(120.5 * 1000))]
        [InlineData(400, 600, 250, (long)(120.5 * 1000))]
        public void TestCalculateOutBound_Weight_UnexpectedPackageException_TooHeavy(int length, int breadth, int height, long weight)
        {
            var info = new PackageInfo(length, breadth, height, weight);
            var unexpected = Assert.Throws<UnexpectedPackageException>(() => this.parcelService.Calculate(info));
            Assert.Equal(Constants.PACKAGE_TOO_HEAVY_MESSAGE, unexpected.Message);
        }
    }
}
