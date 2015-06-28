namespace TidyClubDotNet.Model
{
    public interface IConversion<T, TResponse, TRequest>
    {
        T CreateFromResponse(TResponse response);

        TRequest CreateRequest();
    }
}
