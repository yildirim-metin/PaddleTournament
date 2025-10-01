using PaddleTournament.DAL.Repositories;
using PaddleTournament.DL.Models;

namespace PaddleTournament.DLL.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }
    
}