namespace TidyClubDotNet.Service.RestService.Interface
{
    public interface IDeleteRestService<TResponse>
    {
        bool Delete(int id);
    }
}