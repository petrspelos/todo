using System.Threading.Tasks;
using ToDo.WebApi.Entities;

namespace ToDo.WebApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByName(string username);
    }
}
