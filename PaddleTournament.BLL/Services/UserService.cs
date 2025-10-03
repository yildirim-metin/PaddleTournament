using Isopoh.Cryptography.Argon2;
using PaddleTournament.BLL.Exceptions;
using PaddleTournament.DAL.Repositories;
using PaddleTournament.DL.Models;

namespace PaddleTournament.BLL.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(string email, string password, string username)
    {
        User user = new User()
        {
            Username = username,
            Email = email,
            PasswordHash = Argon2.Hash(password),
        };
        _userRepository.AddUser(user);
    }

    public User GetUserByEmail(string email, string password)
    {
        User user = _userRepository.GetUserByEmail(email) ?? throw new UserNotFoundException();

        if (!Argon2.Verify(user.PasswordHash, password))
        {
            throw new WrongPasswordException();
        }

        return user;
    }
}