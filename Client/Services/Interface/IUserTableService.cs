using MudCRUDlist.Shared.Models;

namespace MudCRUDlist.Client.Services.Interface
{
    public interface IUserTableService
    {
        Task<IEnumerable<UserTable>> GetUsers();
        Task<UserTable> GetUser(string UserId);
        Task<UserTable> AddUser(UserTable entity);
        Task<UserTable> UpdateUser(string UserId, UserTable entity);
        Task<UserTable> DeleteUser(string UserID);
    }
}
