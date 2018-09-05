using stormbreaker.api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUser(int id);
        void AddUser(UserDTO userDTO);
        void UpdateUser(int id, UserDTO userDTO);
        void DeleteUser(int id);
    }
}
