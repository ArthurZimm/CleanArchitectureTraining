using AutoMapper;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDTO>> GetUsers()
    {
        return _mapper.Map<IEnumerable<UserDTO>>(await _userRepository.GetAllUsersAsync());
    }
    public async Task<UserDTO> GetUserById(int id)
    {
        return _mapper.Map<UserDTO>(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task<UserDTO> GetUserByName(string name)
    {
        return _mapper.Map<UserDTO>(await (_userRepository.GetUserByNameAsync(name)));
    }

    public async Task Add(UserDTO userDTO)
    {
        var result = _mapper.Map<User>(userDTO);
        await _userRepository.CreateUserAsync(result);

    }

    public async Task Update(UserDTO userDTO)
    {
        await _userRepository.UpdateUserAsync(_mapper.Map<User>(userDTO));
  
    }
    public async Task Delete(int id)
    {
        await _userRepository.DeleteUserAsync(_userRepository.GetUserByIdAsync(id).Result);
    }
}
