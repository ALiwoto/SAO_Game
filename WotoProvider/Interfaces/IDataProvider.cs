
namespace WotoProvider.Interfaces
{
    public interface IDataProvider<T1>
        where T1 : class
    {
        T1 GetForServer();
    }
}
