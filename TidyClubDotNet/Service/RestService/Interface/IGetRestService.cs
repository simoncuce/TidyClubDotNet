namespace TidyClubDotNet.Service.RestService.Interface
{
    public interface IGetRestService<TResponse>
    {
        TResponse Get(int id);
    }
}