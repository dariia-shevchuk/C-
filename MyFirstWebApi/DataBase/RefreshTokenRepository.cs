using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebApi.DataBase
{
    public class RefreshTokenRepository : RepositoryBase, IRefreshTokenRepository
    {
        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

        public RefreshTokenRepository(DatabaseOptions databaseOptions)
            : base(databaseOptions)
        {
        }

        public void Add(RefreshToken token)
        {
            var sql = $"Insert into {nameof(RefreshToken)}(Id, UserId, Token, CreatedAt) " +
                $"values('{token.Id}', {token.UserId}, '{token.Token}', '{token.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}')";
            Execute(sql);
        }

        public RefreshToken Get(string token)
        {
            var sql = $"select * from {nameof(RefreshToken)} where Token = '{token}'";
            return QuerySingle<RefreshToken>(sql);
        }

        public void Update(RefreshToken token)
        {
            var sql = $"update {nameof(RefreshToken)} set RevokedAt = '{token.RevokedAt?.ToString("yyyy-MM-dd HH:mm:ss.fff")}' where Id = {token.Id}";
            Execute(sql);
        }
    }
}