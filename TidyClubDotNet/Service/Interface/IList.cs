namespace TidyClubDotNet.Service.Interface
{
    using System.Collections.Generic;

    public interface IList<T> 
    {
        List<T> List(int limit = 0, int offset = 0);
    }
}