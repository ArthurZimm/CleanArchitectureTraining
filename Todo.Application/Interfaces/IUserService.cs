using Todo.Application.DTOs;

namespace Todo.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetUsers();
    Task<UserDTO> GetUserById(int id);
    Task<UserDTO> GetUserByName(string name);
    Task Add(UserDTO userDTO);
    Task Update(UserDTO userDTO);
    Task Delete(int id);
}
