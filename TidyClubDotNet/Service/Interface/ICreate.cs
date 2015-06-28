namespace TidyClubDotNet.Service.Interface
{
    public interface ICreate<T> 
    {
        T Create(T item);
    }
}