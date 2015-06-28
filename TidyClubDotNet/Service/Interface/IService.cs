namespace TidyClubDotNet.Service.Interface
{
    public interface IService<T> : IList<T>, IDelete, IGet<T>, ICreate<T>, IUpdate<T>
    {
    }
}
