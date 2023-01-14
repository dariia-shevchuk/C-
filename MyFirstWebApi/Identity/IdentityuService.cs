using Microsoft.Extensions.Logging;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System.Text.RegularExpressions;

namespace MyFirstWebApi.Identity
{
    public class IdentitiyService : IIdentitiyService
    {
        private static readonly Regex EmailRegex = new Regex(
           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
           RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogger<IdentitiyService> _logger;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IJwtProvider _jwtProvider;

        public IdentitiyService(IUserRepository userRepository, IPasswordService passwordService,
            ILogger<IdentitiyService> logger,
            IRefreshTokenService refreshTokenService, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logger = logger;
            _refreshTokenService = refreshTokenService;
            _jwtProvider = jwtProvider;
        }

        public AuthDto SignIn(SignIn command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                _logger.LogError($"Invalid email: {command.Email}");
            }

            var user = _userRepository.GetByEmail(command.Email);

            if (user is null || !_passwordService.IsValid(user.Password, command.Password))
            {
                _logger.LogError($"User with email: {command.Email} was not found.");
            }

            var auth = _jwtProvider.Create(user.Id);
            auth.RefreshToken = _refreshTokenService.Create(user.Id);
            return auth;
        }

        public void SignUp(SignUp command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                _logger.LogError($"Invalid email: {command.Email}");
            }

            var user = _userRepository.GetByEmail(command.Email);

            if (user is { })
            {
                _logger.LogError($"Email already in use: {command.Email}");
            }

            var password = _passwordService.Hash(command.Password);
            user = new User(command.Email, password, command.FirstName, command.LastName);
            _userRepository.Add(user);
        }
    }
}