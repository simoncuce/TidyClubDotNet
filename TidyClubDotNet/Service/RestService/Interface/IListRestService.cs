namespace TidyClubDotNet.Service.RestService.Interface
{
    using System.Collections.Generic;

    public interface IListRestService<TResponse> 
    {
        List<TResponse> List(int limit = 0, int offset = 0);
    }
}