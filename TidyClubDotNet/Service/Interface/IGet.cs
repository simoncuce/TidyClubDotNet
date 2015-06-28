namespace TidyClubDotNet.Service.Interface
{
    public interface IGet<T>
    {
        T Get(int id);
    }
}