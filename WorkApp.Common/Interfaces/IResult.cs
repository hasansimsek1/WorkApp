namespace WorkApp.Common.Interfaces
{
    public interface IResult<T>
    {
        bool HasError { get; }
    }
}
