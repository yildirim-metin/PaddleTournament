using Isopoh.Cryptography.Argon2;
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

    public void AddUser(string email, string password,string username)
    {
        User user = new User();
        user.Username = username;
        user.Email = email;
        user.PasswordHash = Argon2.Hash(password);
        _userRepository.AddUser(user);
    }

    public User? GetUserByEmail(string email, string password)
    {

        User? user = _userRepository.GetUserByEmail(email);

        if (user != null)
        {
            if (Argon2.Verify(user.PasswordHash, password))
            {
                return user;
            }
            throw new Exception("password incorrect !");
        }
        return null;
    }
    
}