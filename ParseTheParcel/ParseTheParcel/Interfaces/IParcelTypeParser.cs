using ParseTheParcel.Models;

namespace ParseTheParcel.Interfaces
{
    public interface IParcelTypeParser
    {
        IParcelCalculator Parser(ParcelInfo info);
    }
}