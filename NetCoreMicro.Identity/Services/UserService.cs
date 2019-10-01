using NetCoreMicro.Common.Auth;
using NetCoreMicro.Common.Exceptions;
using NetCoreMicro.Services.Identity.Domain.Models;
using NetCoreMicro.Services.Identity.Domain.Repositories;
using NetCoreMicro.Services.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler jwtHandler;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            this.jwtHandler = jwtHandler;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new NetCoreMicroException("email_in_user",
                    $"Email: '{email} is already in use.");
            }

            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new NetCoreMicroException("invalid_credentials",
                    $"Invalid Credentials");
            }
            if(!user.ValidatePassword(password, _encrypter))
            {
                throw new NetCoreMicroException("invalid_credentials",
                    $"Invalid Credentials");
            }

            return jwtHandler.Create(user.Id);
        }

    }
}
