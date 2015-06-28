namespace TidyClubDotNet.Service.RestService.Interface
{
    public interface ICreateRestService<Request, Response> 
    {
        Response Create(Request item);
    }
}