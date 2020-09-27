namespace ParseTheParcel.Interfaces
{
    public interface IParcelSpecification : ISizeable, IWeightable
    {
        string Name { get; }
        decimal Cost { get; }
    }
}