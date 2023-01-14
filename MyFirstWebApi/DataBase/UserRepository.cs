using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;

namespace MyFirstWebApi.DataBase
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly DatabaseOptions _databaseOptions;

        public UserRepository(DatabaseOptions databaseOptions)
            : base(databaseOptions)
        {
        }

        public void Add(User user)
        {
            var sql = $"Insert into [{nameof(User)}](Email, [Password], FirstName, LastName) " +
                $"values('{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}')";
            Execute(sql);
        }

        public User Get(int id)
        {
            var sql = $"Select * from [{nameof(User)}] where Id = {id}";
            return QuerySingle<User>(sql);
        }

        public User GetByEmail(string email)
        {
            var sql = $"Select * from [{nameof(User)}] where Email = '{email}'";
            return QuerySingle<User>(sql);
        }
    }
}