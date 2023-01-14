using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System;

namespace MyFirstWebApi.Identity
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRng _rng;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IJwtProvider jwtProvider, IRng rng)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _rng = rng;
        }

        public string Create(int userId)
        {
            var token = _rng.Generate(30, true);
            var refreshToken = new RefreshToken(Guid.NewGuid(), userId, token, DateTime.UtcNow);
            _refreshTokenRepository.Add(refreshToken);
            return token;
        }

        public AuthDto Use(string refreshToken)
        {
            var token = _refreshTokenRepository.Get(refreshToken);

            //if (token is null)
            //{
            //    throw new InvalidRefreshTokenException();
            //}

            //if (token.Revoked)
            //{
            //    throw new RevokedRefreshTokenException();
            //}

            var user = _userRepository.Get(token.UserId);

            //if (user is null)
            //{
            //    throw new UserNotFoundException(token.UserId);
            //}

            var auth = _jwtProvider.Create(token.UserId);
            auth.RefreshToken = refreshToken;
            return auth;
        }

        public void Revoke(string refreshToken)
        {
            var token = _refreshTokenRepository.Get(refreshToken);
            //if (token is null)
            //{
            //    throw new InvalidRefreshTokenException();
            //}

            token.Revoke(DateTime.UtcNow);
            _refreshTokenRepository.Update(token);
        }
    }
}