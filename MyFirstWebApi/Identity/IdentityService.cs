using Microsoft.Extensions.Logging;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFirstWebApi.Identity
{
    public class IdentityService : IIdentityService
    {
        private static readonly Regex EmailRegex = new Regex(
   @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
   RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
       
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserRepsitory _userRepsitory;
        private readonly IPasswordService _passwordService;

        public IdentityService(ILogger<IdentityService> logger, IUserRepsitory userRepsitory,
            IPasswordService passwordService)
        {
            _logger = logger;
            _userRepsitory = userRepsitory;
            _passwordService = passwordService;
        }

        public void SignUp(SignUp signUp)
        {
            if (!EmailRegex.IsMatch(signUp.Email))
            {
                _logger.LogError($"Invalid email: {signUp.Email}");
                return;
            }

            //sprawdzam resztę danch (firstName, LastName, Password)
            var user = _userRepsitory.GetUserByEmail(signUp.Email);
            if(user is { })
            {
                _logger.LogError($"Email already in use: {signUp.Email}");
                return;
            }

            var password = _passwordService.Hash(signUp.Password);
            user = new User(signUp.Email, password, signUp.FirstName, signUp.LastName);
            _userRepsitory.Add(user);
        }
    }
}
