
namespace SportShop.DLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);

    }
}
