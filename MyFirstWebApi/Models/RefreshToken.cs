using System;

namespace MyFirstWebApi.Models
{
    public class RefreshToken
    {
        public RefreshToken(Guid id, int userId, string token, DateTime createdAt, DateTime? revokedAt = null)
        {
            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }

        public Guid Id { get; set; }
        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public bool Revoked => RevokedAt is { };

        public void Revoke(DateTime revokedAt)
        {
            //if (Revoked)
            //{
            //    throw new RevokedRefreshTokenException();
            //}
            RevokedAt = revokedAt;
        }
    }
}