namespace WorkApp.Common.Interfaces
{
    /// <summary>
    /// Contract definitions for Result class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult<T>
    {
        /// <summary>
        /// Result must be able to tell the caller if there is error or not.
        /// </summary>
        bool HasError { get; }
    }
}
