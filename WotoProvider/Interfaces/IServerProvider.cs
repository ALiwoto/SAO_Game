
namespace WotoProvider.Interfaces
{
    public interface IServerProvider<T1, T2> 
        where T1 : class
        where T2 : class
    {
        T1 ProductHeaderValue { get; }
        T1 Token { get; }
        T1 Owner { get; }
        T1 Repo { get; }
        T1 Branch { get; }
        T2 GetClient();
    }
}
