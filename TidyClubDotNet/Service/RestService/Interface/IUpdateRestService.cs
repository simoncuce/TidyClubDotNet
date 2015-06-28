namespace TidyClubDotNet.Service.RestService.Interface
{
    public interface IUpdateRestService<TRequest, TResponse> 
    {
        bool Update(TRequest item);
    }
}
