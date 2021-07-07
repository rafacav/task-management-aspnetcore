using Common.DTO.Auth;
using Repository.Entities;
using Repository.Repositories;
using System;

namespace Service.Auth
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User SignUp(AuthCreateDto authCreateDto)
        {
            var user = new User()
            {
                Username = authCreateDto.Username,
                Password = authCreateDto.Password,
                CreateDate = DateTime.Now
            };

            return _userRepository.CreateUser(user);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }
    }
}
