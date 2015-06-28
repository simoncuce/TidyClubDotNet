namespace TidyClubDotNet.Service.Interface
{
    public interface IUpdate<Request> 
    {
        bool Update(Request item);
    }
}
